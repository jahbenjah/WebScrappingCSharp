using AppCore.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = GetDriver();
            driver.Manage().Window.Maximize();
            GuardarCategorias(driver);
            ExtraerLibros(driver);
            ReadLine();
        }

        private static void ExtraerLibros(IWebDriver driver)
        {
            foreach (var url in GetCatalogoUrls().Skip(1))
            {
                driver.Navigate().GoToUrl(url);
                Catalogo catalogo = new Catalogo(driver);
                var links = catalogo.ObtenerUrlLibros();
                foreach (var link in links)
                {
                    driver.Navigate().GoToUrl(link);
                    DetalleLibro detalleLibro = new DetalleLibro(driver);
                    using (var db = new AppData.AppContext())
                    {
                        db.Libros.Add(detalleLibro.GetDetallesLibro());
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Abre el navegador Chrome y visita cada una de las páginas del catalago de
        /// http://books.toscrape.com/
        /// </summary>
        public static void NavagarPorElCatalogo()
        {
            var driver = GetDriver();
            driver.Manage().Window.Maximize();

            foreach (var url in GetCatalogoUrls())
            {
                driver.Navigate().GoToUrl(url);
            }
        }
        
        /// <summary>
        /// Configura el driver para Chrome
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetDriver()
        {
            var user_agent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.50 Safari/537.36";
            ChromeOptions options = new ChromeOptions();
            //Descomenta esta linea para usar el mode HeadLess de Chrome
            //options.AddArgument("--headless"); 
            options.AddArgument("--disable-gpu");
            options.AddArgument($"user_agent={user_agent}");
            options.AddArgument("--ignore-certificate-errors");
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            return driver;
        }

        /// <summary>
        ///  Genera las url de las 50 paginas del catalogo de libros de http://books.toscrape.com/
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCatalogoUrls()
        {
            List<string> urls = new List<string>();
            for (int i = 1; i <= 50; i++)
            {
                urls.Add($@"http://books.toscrape.com/catalogue/page-{i}.html");
            }
            return urls;
        }

        public static void GuardarCategorias(IWebDriver driver)
        {
            foreach (var url in GetCatalogoUrls().Take(1))
            {
                driver.Navigate().GoToUrl(url);
                Catalogo catalogo = new Catalogo(driver);
                var cate = catalogo.ObtenerCategorias();
                using (var db = new AppData.AppContext())
                {
                    foreach (var cat in cate)
                    {
                        db.Categorias.Add(cat);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
