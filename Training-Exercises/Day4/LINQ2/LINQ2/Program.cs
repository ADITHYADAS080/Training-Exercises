using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }                           

    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>()
            {

                new Product { Name = "Laptop", Category = "Electronics", Price = 65999 },
                new Product { Name = "Shirt", Category = "Styles" },
                new Product { Name = "mobile", Category = "Electronics" },
                new Product { Name = "Shoes", Category = "Styles" },
                new Product { Name = "Shampoo", Category = "Health Care" }
            };


            var groupByCategory = from p in products
                                  group p by p.Category into g
                                  select new
                                  {
                                      Category = g.Key,
                                      Count = g.Count()
                                  };


            foreach (var group in groupByCategory)
            {
                Console.WriteLine($"Category: {group.Category} \t Count: {group.Count}");
            }


        }
    }
}
