using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling_Practice
{
    class Program
    {
        public static int MyDivision(int num1, int num2)
        {
            try
            {
                return num1 / num2;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enther the second number");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int result = MyDivision(num1, num2);
                Console.WriteLine("result=" + result);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
