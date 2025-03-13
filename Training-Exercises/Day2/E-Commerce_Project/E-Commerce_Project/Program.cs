using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerse
{
    class Product
    {
        public int id;
        public string name;
        public double price;
        public int quantity;

        public Product(int id, string name, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public void DisplayItems()
        {
            Console.WriteLine("id:" + id + " Name: " + name + " Price: " + price + " Quantity: " + quantity);
        }
    }
    class ShoppingCart
    {
        Product[] cartItems = new Product[5];
        int count = 0;

        public void AddToCart(Product product)
        {
            if (count < 5)
            {
                cartItems[count] = product;
                count++;
                Console.WriteLine("Item added  " + product.name);

            }
            else
            {
                Console.WriteLine("cart is full");
            }
        }

        public void RemoveItem(int romoveId )
        {
            if (count == 0)
            {
                Console.WriteLine("cart is Empty");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (cartItems[i].id == romoveId)
                    {
                        cartItems[i] = null;
                        count--;
                    }
                }
            }
        }

        public double CalculateTotal()
        {
        double total = 0;
            for (int i = 0; i < count; i++)
            {
                total += cartItems[i].price * cartItems[i].quantity;
            }
            return total;
        }
        public void ViewCart()
        {
            if (count == 0 )
            {
                Console.WriteLine("cart is Empty");
            }
            else
            {
                for (int i = 0; i< count; i++)
                {
                    cartItems[i].DisplayItems();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[3];
            products[0] = new Product(1, "apple", 15.5, 20);
            products[1] = new Product(2, "banana", 12, 10);
            products[2] = new Product(3, "pinapple", 20.00, 15);

            ShoppingCart cart = new ShoppingCart();
            int choice;
            do
            {
                Console.WriteLine("1.View Products");
                Console.WriteLine("2.Add To Cart");
                Console.WriteLine("3.View Cart");
                Console.WriteLine("4.Remove Cart");
                Console.WriteLine("5.Checkout");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter Your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" Available Products");
                        for (int i = 0; i < products.Length; i++)
                        {
                            products[i].DisplayItems();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the Product ID");
                        int prouctId = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].id == prouctId)
                            {
                                cart.AddToCart(products[i]);
                            }
                        }
                            break;

                    case 3:
                        Console.WriteLine("Cart Items \n");
                        cart.ViewCart();
                        break;

                    case 4:
                        Console.WriteLine("Enter ProdectID of the item to remove \n");
                        int RemoveId = Convert.ToInt32(Console.ReadLine());
                        cart.RemoveItem(RemoveId);
                        break;

                    case 5:
                        double total = cart.CalculateTotal();
                        Console.WriteLine(total);
                        break;

                    case 6:
                        Console.WriteLine("Exiting the application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }   
            } while (choice!=6);
        }
    }
}