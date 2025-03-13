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
    class Program
    {

        //Deligate Methods
        delegate int Calculate(int a, int b);

        static int Addition(int a, int b) => a + b;
        static int Subtraction(int a, int b) => a - b;
        static int Divistion(int a, int b) => a / b;
        static int Multiplication(int a, int b) => a * b;

        static void Main(string[] args)
        {

            //Deligate

            Calculate add = Addition;
            Calculate subtract = Subtraction;
            Calculate divide = Divistion;
            Calculate Mmultiply = Multiplication;

            Console.WriteLine("Addition :" + add(10, 5));
            Console.WriteLine("Subtraction :" + subtract(6, 44));
            Console.WriteLine("Divistion :" + divide(42, 8));
            Console.WriteLine("Multiplication :" + Mmultiply(8, 4));




            Console.ReadKey();
        }

    }
}
