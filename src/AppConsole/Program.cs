using AppCore.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using  static System.Console;
using System.Linq;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = GetDriver();
            driver.Manage().Window.Maximize();
           
            foreach (var url in GetCatalogoUrls().Take(1))
            {

                WriteLine(url);
                driver.Navigate().GoToUrl(url);
                Catalogo catalogo = new Catalogo(driver);
                WriteLine(catalogo.GetTitulo());
                catalogo.Siguiente();
                catalogo.Anterior();
                catalogo.ObtenerCategorias();
            }
            ReadLine();
        }

        public static IWebDriver GetDriver()
        {
            var user_agent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.50 Safari/537.36";
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument($"user_agent={user_agent}"); //Especifies user Agent
            options.AddArgument("--ignore-certificate-errors");
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            return driver;
        }

        public static List<string> GetCatalogoUrls()
        {
            List<string> urls = new List<string>();
            for (int i = 1; i <= 50; i++)
            {
                urls.Add($@"http://books.toscrape.com/catalogue/page-{i}.html");
            }
            return urls;
        }
    }
}
