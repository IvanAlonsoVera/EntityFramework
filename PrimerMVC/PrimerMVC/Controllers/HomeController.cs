using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PrimerMVC.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navegar a una URL para probar esto";
        }
        public ViewResult Autoproperty()
        {
            Product product = new Product();
            product.Name = "Kayak";
            return View("Index",(object)string.Format("Product Name {0}",product.Name));
        }
        public ViewResult createProduct()
        {
            Product product = new Product();
            product.ProductID = 1;
            product.Name = "kayak";
            product.Descripcion = "a boat";
            product.Price = 254M;
            product.Category = "watersports";

            return View("Index", (object)String.Format("Product Description {0}", product.Descripcion));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int>intList = new List<int> { 1, 2, 3 };
            Dictionary<string, int> myDict = new Dictionary<string, int>()
            {
                { "apple",1},
                { "orange",2},
                { "plum", 3}
            };
            return View("Index", (object)string.Format("{0}", myDict["orange"]));
        }
        public ViewResult CreateListFilter()
        {
            Product[] productArray =
            {
                new Product()
                {
                    Name="Kayak",
                    Category="WaterSports",
                    Price=275M
                },
                new Product()
                {
                    Name="LifeJacket",
                    Category="WaterSports",
                    Price=48.95M
                },
                new Product()
                {
                    Name="Soccer Ball ",
                    Category="Soccer",
                    Price=19.5M
                },
                new Product()
                {
                    Name="Corner",
                    Category="Soccer",
                    Price=15M
                }
            };
            decimal total = 0;

            foreach (var product in productArray.Where(prod => prod.Category == "Soccer"))
            {
                total += product.Price;
            }
            return View("Index",(object)string.Format("total Soccer: {0}",total));
        }
        public ViewResult FindProducts()
        {
            Product[] productArray =
            {
                new Product()
                {
                    Name="Kayak",
                    Category="WaterSports",
                    Price=275M
                },
                new Product()
                {
                    Name="LifeJacket",
                    Category="WaterSports",
                    Price=48.95M
                },
                new Product()
                {
                    Name="Soccer Ball ",
                    Category="Soccer",
                    Price=19.5M
                },
                new Product()
                {
                    Name="Corner",
                    Category="Soccer",
                    Price=15M
                }
            };
            //var foundProducts = (from match in productArray
            //                     orderby match.Price descending
            //                     select new
            //                     {
            //                         match.Name,
            //                         match.Price
            //                     }).Take(3);

            var results = productArray.Sum(e => e.Price);

            productArray[2] = new Product { Name = "Stadium", Price = 79600M };
            StringBuilder result = new StringBuilder();
            //foreach (var item in foundProducts)
            //{
            //    result.AppendFormat("Price: {0}" , item.Price);
            //}
            return View("Index", (object)result.ToString());
        }
    }
}