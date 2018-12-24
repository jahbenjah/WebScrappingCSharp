using OpenQA.Selenium;
using System;

namespace AppCore.PageObject
{
    public class DetalleLibro
    {
        private IWebDriver _driver;
        public DetalleLibro(IWebDriver driver)
        {
            if (!driver.Title.Contains("| Books to Scrape - Sandbox"))
            {
                throw new ArgumentException("El titulo no corresponde a una pagina del catalogo");
            }
            _driver = driver;
        }

        public string GetTitulo()
        {
            return _driver.FindElement(By.CssSelector("#content_inner > article > div.row > div.col-sm-6.product_main > h1")).Text;
        }

        public string GetPrecio()
        {
            return _driver.FindElement(By.ClassName("price_color")).Text;
        }

        public string GetUrlImagen()
        {
            return _driver.FindElement(By.CssSelector("#product_gallery > div > div > div > img")).GetAttribute("src");
        }
    }
}
