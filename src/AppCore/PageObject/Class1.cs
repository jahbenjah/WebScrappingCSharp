using OpenQA.Selenium;
using System.Collections.Generic;

namespace AppCore.PageObject
{
    public class ListaArticulos
    {
        private readonly string Url = "https://aspnetcoremaster.com/";
        private readonly string Password = "pass";
        private readonly string Inicia = "u_0_2";


        private IWebDriver _driver;
        public ListaArticulos(IWebDriver driver)
        {
            _driver = driver;
        }

      
        public void IngresarPassword(string password)
        {
            var passwordElement = _driver.FindElement(By.Id(Password));
            passwordElement.SendKeys(password);
        }

        public IEnumerable<char> GetTitulo()
        {
            _driver.Navigate().GoToUrl(Url);
            _driver.Manage().Window.Maximize();
            return _driver.FindElement(By.TagName("title")).Text;
        }

        public void IniciarSesion()
        {
            var iniciarSesionElement = _driver.FindElement(By.Id(Inicia));
            iniciarSesionElement.Click();
        }
    }
}
