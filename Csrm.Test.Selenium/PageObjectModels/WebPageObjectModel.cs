using System;
using System.Collections.Generic;
using System.Linq;
using Csrm.Test.Selenium.Helpers;
using Csrm.Test.Selenium.TestSetting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Csrm.Test.Selenium.PageObjectModels
{
    public abstract class WebPageObjectModel
    {
        public readonly IWebDriver WebDriver;

        [FindsBy(How = How.ClassName, Using = "snapError")]
        public virtual IList<IWebElement> ErrorNotifications { get; set; }

        [FindsBy(How = How.ClassName, Using = "snapSuccess")]
        public virtual IList<IWebElement> SuccessNotifications { get; set; }

        public virtual string Url
        {
            get { return String.Format("{0}/{1}", TestSettings.Datas.BaseUrl, Route()); }
        }

        public abstract string Route();

        protected WebPageObjectModel(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            InitializePageFactory();
        }

        public abstract void InitializePageFactory();

        public virtual void NavigateToUrl()
        {
            NavigateToUrlWith("");
        }

        public virtual void NavigateToUrlWith(string value)
        {
            string newUrl = Url + value;
            WebDriver.Navigate().GoToUrl(newUrl);
        }

        public virtual bool HasNavigatedAtUrl()
        {
            return HasNavigatedAtUrlWith("");
        }

        public virtual bool HasNavigatedAtUrlWith(string value)
        {
            string expectedUrl = Url + value;
            return TestingHelpers.WaitUntil(WebDriver, driver => driver.Url.ToLower().Equals(expectedUrl.ToLower()));
        }

        public virtual bool HasRedirectedFromUrl()
        {
            return HasRedirectedFromUrlWith("");
        }

        public virtual bool HasRedirectedFromUrlWith(string value)
        {
            string expectedUrl = Url + value;
            return TestingHelpers.WaitUntil(WebDriver, driver => !driver.Url.ToLower().Equals(expectedUrl.ToLower()));
        }

        public virtual bool ErrorNotificationContains(string message = "")
        {
            return TestingHelpers.WaitUntil(WebDriver, d => ErrorNotifications.Any(x => x.Displayed && x.Text.Contains(message)));
        }

        public virtual bool SuccessNotificationContains(string message = "")
        {
            return TestingHelpers.WaitUntil(WebDriver, d => SuccessNotifications.Any(x => x.Displayed && x.Text.Contains(message)));
        }
    }
}
