using System;
using Csrm.Test.Selenium.PageObjectModels.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Csrm.Test.Selenium.Tests
{
    [TestFixture]
    public class GooglePageTest
    {
        [Test]
        public void LoadPage()
        {
            var dirver = Setup.Driver;

            var page = new GooglePom(dirver);
            page.NavigateToUrl();
            page.Search("Selenium test in c#");

            var wait = new WebDriverWait(dirver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Name("btnG")));
        }
    }
}
