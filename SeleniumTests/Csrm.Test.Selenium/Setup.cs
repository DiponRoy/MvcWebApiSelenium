using Csrm.Test.Selenium.TestSetting;
using Csrm.Test.Selenium.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace Csrm.Test.Selenium
{
    [SetUpFixture]
    public class Setup
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver ?? (_driver = PhantomDriver());
            }
        }

        private static IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); /*maximized window*/
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitlyWait(TestSettings.Timeouts.Implicit); /*strange, if not used this one, test don't even get started*/
            return driver;
        }

        private static IWebDriver PhantomDriver()
        {
            return new PhantomJSDriver();
        }

        private static IWebDriver FireFoxDriver()
        {
            return new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Destroy();
        }
    }
}