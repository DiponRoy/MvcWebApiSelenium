using System;
using OpenQA.Selenium;

namespace Csrm.Test.Selenium.PageObjectModels
{
    internal interface ILoginPom
    {
        IWebElement Email { get; set; }

        IWebElement Password { get; set; }

        IWebElement BtnLogin { get; set; }

        void SubminCredentials(String email, String password);
    }
}
