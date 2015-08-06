using System.Collections.Generic;
using OpenQA.Selenium;

namespace Csrm.Test.Selenium.PageObjectModels
{
    interface IPageObjectModel
    {
        string Url { get; }
        string Route();
        void NavigateToUrl();
        void NavigateToUrlWith(string value);

        bool HasNavigatedAtUrl();
        bool HasNavigatedAtUrlWith(string value);

        bool HasRedirectedFromUrl();
        bool HasRedirectedFromUrlWith(string value);

        string ExpectedTitle();

        IList<IWebElement> ErrorNotifications { get; set; }
        IList<IWebElement> SuccessNotifications { get; set; }
        bool SuccessNotificationContains(string message);
        bool ErrorNotificationContains(string message);

        void InitializePageFactory();
    }
}
