using System;
using OpenQA.Selenium;

namespace Csrm.Test.Selenium.Utilities
{
    /// <summary>
    /// Fluent API for chaining parts of a test.
    /// </summary>
    public class Gherkin : IDisposable
    {
        private readonly IWebDriver _driver;

        private bool _given;

        private bool _when;

        public Gherkin(IWebDriver driver)
        {
            _driver = driver;
        }

        public Gherkin Given(Action<IWebDriver> a)
        {
            a.Invoke(_driver);
            _given = true;
            return this;
        }

        public Gherkin When(Action<IWebDriver> a)
        {
            if (!_given)
            {
                throw new InvalidOperationException("Start with Given()");
            }

            a.Invoke(_driver);
            _when = true;
            return this;
        }

        public Gherkin And(Action<IWebDriver> a)
        {
            if (!_given || !_when)
            {
                throw new InvalidOperationException("Start with Given() and When()");
            }

            a.Invoke(_driver);
            return this;
        }

        public void Then(Action<IWebDriver> action)
        {
            action.Invoke(_driver);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
