using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AppCore.PageObject
{
    public class Catalogo
    {
        private readonly string Password = "pass";
        private readonly string Inicia = "u_0_2";

        private IWebDriver _driver;
        public Catalogo(IWebDriver driver)
        {
            if (driver.Title != "All products | Books to Scrape - Sandbox")
            {
                throw new ArgumentException("El titulo no corresponde a una pagina del catalogo");
            }
            _driver = driver;
        }

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            var links = _driver.FindElements(By.CssSelector("#default > div > div > div > aside > div.side_categories > ul > li > ul > li > a"));
            foreach (var item in links)
            {
                if (item.Text.Length > 0)
                {
                    var url = item.GetAttribute("href");
                    var inicio = url.LastIndexOf('_') + 1;
                    var largo = url.LastIndexOf('/') - inicio;
                    var category = new Categoria()
                    {
                        CategoriaId = Convert.ToInt32(url.Substring(inicio, largo)),
                        Nombre = item.Text,
                        Url = item.GetAttribute("href")
                    };
                    categorias.Add(category);
                }
            }
            return categorias;
        }

        public List<string> ObtenerUrlLibros()
        {
            List<string> urls = new List<string>();
            var links = _driver.FindElements(By.XPath("//*[@id='default']/div/div/div/div/section/div/ol/li/article/h3/a"));
            foreach (var link in links)
            {
                urls.Add(link.GetAttribute("href"));
            }
            return urls;
        }

        public IEnumerable<char> GetTitulo()
        {
            return _driver.FindElement(By.TagName("title")).Text;
        }

        public void Siguiente()
        {
            var siguiente = _driver.FindElement(By.CssSelector("#default > div > div > div > div > section > div:nth-child(2) > div > ul > li.next > a"));
            siguiente.Click();
        }

        public void Anterior()
        {
            var anterior = _driver.FindElement(By.CssSelector("#default > div > div > div > div > section > div:nth-child(2) > div > ul > li.previous > a"));
            anterior.Click();
        }
    }
}
