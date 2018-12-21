using OpenQA.Selenium;
using System;
using Xunit;

namespace AppTest
{
    public class BooksToScrape : IDisposable
    {
        private IWebDriver _driver;
        public BooksToScrape(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Dispose()
        {
            _driver.Close();
        }

        [Fact]
        public void Test1()
        {

        }

    }
}
