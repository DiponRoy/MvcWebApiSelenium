using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Csrm.Test.Selenium.TestSetting;
using Csrm.Test.Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Csrm.Test.Selenium.Helpers
{
    internal class TestingHelpers
    {
        public static bool HasNavigatedAtUrl(IWebDriver webDriver, string url)
        {
            return WaitUntil(webDriver, driver => driver.Url.ToLower().Equals(url.ToLower()));
        }

        public static bool HasNavigatedAtUrlContains(IWebDriver webDriver, string value)
        {
            return WaitUntil(webDriver, driver => driver.Url.ToLower().Contains(value.ToLower()));
        }

        public static bool HasNavigatedAtUrlStartsWith(IWebDriver webDriver, string value)
        {
            return WaitUntil(webDriver, driver => driver.Url.ToLower().StartsWith(value.ToLower()));
        }

        public static bool WaitUntil(IWebDriver webDriver, Func<IWebDriver, bool> prediction)
        {
            return webDriver.WaitUntil(prediction, TestSettings.Timeouts.Explicit);
        }

        public static void WaitForJqueryAjaxs(IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, TestSettings.Timeouts.Explicit);
            wait.Until(d => (bool)d.AsJsExecutor().ExecuteScript("return jQuery.active == 0"));
        }
    }
}
