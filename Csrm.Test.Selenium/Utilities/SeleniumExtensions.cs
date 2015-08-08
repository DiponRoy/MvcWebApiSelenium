using System;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Cookie = OpenQA.Selenium.Cookie;

namespace Csrm.Test.Selenium.Utilities
{
    public static class SeleniumExtensions
    {
        public static IJavaScriptExecutor AsJsExecutor(this IWebDriver webDriver)
        {
            if (webDriver == null)
            {
                throw new NullReferenceException("webDriver is null, cann't convert as IJavaScriptExecutor.");
            }
            return (IJavaScriptExecutor)webDriver;
        }

        public static TSource ExecuteScriptForData<TSource>(this IJavaScriptExecutor javaScriptExecutor,
            string script,
            params object[] args)
        {
            if (!script.TrimStart().StartsWith("return", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("script should start with word 'return'.");
            }

            object result = javaScriptExecutor.ExecuteScript(script, args);
            TSource source;
            if (typeof (TSource) == typeof (string))
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string resultString = JsonConvert.SerializeObject(result, settings);
                source = JsonConvert.DeserializeObject<TSource>(resultString, settings);
            }
            else
            {
                string resultString = (result is string) ? result as string : JsonConvert.SerializeObject(result);
                source = JsonConvert.DeserializeObject<TSource>(resultString);
            }

            return source;
        }

        public static byte[] Download(this IWebDriver webDriver, string downloadUrl)
        {
            byte[] downloadedData;
            ReadOnlyCollection<Cookie> cookies = webDriver.Manage().Cookies.AllCookies;
            using (var wc = new WebClient())
            {
                foreach (Cookie cookie in cookies)
                {
                    string cookieText = cookie.Name + "=" + cookie.Value;
                    wc.Headers.Add(HttpRequestHeader.Cookie, cookieText);
                }
                downloadedData = wc.DownloadData(new Uri(downloadUrl));
            }

            return downloadedData;
        }

        public static bool TryToDownload(this IWebDriver webDriver, string downloadUrl, out byte[] downloadedData)
        {
            bool isDownloaded = false;
            try
            {
                downloadedData = Download(webDriver, downloadUrl);
                isDownloaded = true;
            }
            catch
            {
                downloadedData = null;
                isDownloaded = false;
            }

            return isDownloaded;
        }

        public static void Value(this IWebElement webElement, string value, IWebDriver webDriver)
        {
            webDriver.AsJsExecutor().ExecuteScript(String.Format("arguments[0].value = '{0}'", value), webElement);
        }

        public static string Value(this IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }

        public static void SetAttribute(this IWebElement webElement,
            string attributeName,
            string value,
            IWebDriver webDriver)
        {
            webDriver.AsJsExecutor()
                .ExecuteScript(String.Format("arguments[0].setAttribute('{0}', '{1}')", attributeName, value),
                    webElement);
        }

        public static void Html(this IWebElement webElement, string html, IWebDriver webDriver)
        {
            webDriver.AsJsExecutor().ExecuteScript(String.Format("arguments[0].innerHTML = '{0}'", html), webElement);
        }

        public static string Html(this IWebElement webElement)
        {
            return webElement.GetAttribute("innerHTML");
        }


        public static bool WaitUntil(this IWebDriver webDriver,
            Func<IWebDriver, bool> prediction,
            TimeSpan waitingTimeSpan)
        {
            bool wasAsPredicted;
            try
            {
                new WebDriverWait(webDriver, waitingTimeSpan).Until(prediction);
                wasAsPredicted = true;
            }
            catch
            {
                wasAsPredicted = false;
            }
            return wasAsPredicted;
        }

        public static void OpenLinkAtNewTab(this IWebDriver webDriver, IWebElement linkWebElement)
        {
            var action = new Actions(webDriver);
            action.KeyDown(Keys.Control)
                .KeyDown(Keys.Shift)
                .Click(linkWebElement)
                .KeyUp(Keys.Control)
                .KeyUp(Keys.Shift)
                .Build()
                .Perform();
        }

        public static void Destroy(this IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver.Close();
                webDriver.Quit();
                webDriver.Dispose();
                webDriver = null;
            }
        }
    }
}
