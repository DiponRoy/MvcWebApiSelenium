using System;
using Csrm.Test.Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Csrm.Test.Selenium.PageObjectModels.Pages
{
    public class GooglePom : WebPageObjectModel, IPageObjectModel
    {
        public override string Url
        {
            get
            {
                return "https://www.google.com";
            }
        }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement TxtSearch { get; set; }

        public GooglePom(IWebDriver driver) : base(driver)
        {
        }

        public void Search(string searchString)
        {
            TxtSearch.Value(searchString, WebDriver);
        }

        public override string Route()
        {
            throw new NotImplementedException();
        }

        public string ExpectedTitle()
        {
            throw new NotImplementedException();
        }

        public override void InitializePageFactory()
        {
            PageFactory.InitElements(WebDriver, this);
        }
    }
}
