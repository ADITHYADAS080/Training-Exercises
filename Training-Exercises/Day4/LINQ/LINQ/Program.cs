using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Product
    {
        public string Name { set; get; }
        public string Category { set; get; }
        public double Price { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product {Name = "laptop" , Category= "Electronics", Price= 45000},
                new Product {Name = "mobile" , Category= "Electronics", Price= 32000},
                new Product {Name = "Dress" , Category= "Styles", Price= 800},
                new Product {Name = "Backpack" , Category= "Styles", Price= 2000},
                new Product {Name = "Hair gell" , Category= "Health care", Price= 45000},
            };
            string itemToserach = Console.ReadLine();
            var category = from item in products
                           where item.Category == itemToserach
                           select item;
            Console.WriteLine("itemToserach");
            foreach (var item in category)
            {
                Console.WriteLine($" Name:{item.Name}  Price: {item.Price}");
            }

            var averagePrice = (from item in products
                                where item.Category == itemToserach
                                select item.Price).Average();

            Console.WriteLine(averagePrice);
        }
    }
}
