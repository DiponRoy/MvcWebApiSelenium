using System;
using Csrm.Test.Selenium.Utilities;
using OpenQA.Selenium;

namespace Csrm.Test.Selenium.JslibHelpers
{
    public class JqueryJsHelper
    {
        public static void Val(IWebElement webElement, string value, IWebDriver webDriver)
        {
            webDriver.AsJsExecutor().ExecuteScript(String.Format("$(arguments[0]).val('{0}')", value), webElement);
        }

        public static string Val(IWebElement webElement, IWebDriver webDriver)
        {
            return (string)webDriver.AsJsExecutor().ExecuteScript("return $(arguments[0]).val()", webElement);
        }

        /*
         * this could not be same when using angular
         * http://stackoverflow.com/questions/6201425/wait-for-an-ajax-call-to-complete-with-selenium-2-web-driver
         */
        public static bool HasActiveAjaxCall(IWebDriver webDriver)
        {
            return (bool)webDriver.AsJsExecutor().ExecuteScript("return jQuery.active != 0");   /*zero means no active ajax*/
        }
    }
}
