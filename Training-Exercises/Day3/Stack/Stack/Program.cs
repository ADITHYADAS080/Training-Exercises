using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace Practice3
{
    class Stack<T>
    {
        private List<T> items = new List<T>();
        int top = -1;
        public void Push(T item)
        {
            items.Add(item);
            top++;
        }

        public T Peek()
        {
            return items[top];
        }

        public T Pop()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            T element = items[top];
            items.RemoveAt(top);
            top--;
            return element;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            //Stack

            Stack<int> stackItem = new Stack<int>();
            int choice;
            do
            {
                Console.WriteLine("1 : Push");
                Console.WriteLine("2 : Peek");
                Console.WriteLine("3 : Pop");
                Console.WriteLine("4 : exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter the number");
                        int no = Convert.ToInt32(Console.ReadLine());
                        stackItem.Push(no);
                        break;
                    case 2:
                        Console.WriteLine($" Item : {stackItem.Peek()}");
                        break;
                    case 3:
                        Console.WriteLine("element deleted :" + stackItem.Pop());
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!");
                        break;
                }
            } while (choice != 0);


            Console.ReadKey();
        }
    }
}
