using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 10;
            int myInt2 = 12;
            double myDouble = 12.2D;
            char myChar = 'a';
            string myString = "hello";
            bool x = true;

            //Performing rithmetic operation
            int sum = myInt + 12;
            Console.WriteLine(sum);

            // checking which number is the large nmber
            if (myInt > myInt2)
            {
                Console.WriteLine($"{myInt} is the large number");
            }
            else
            {
                Console.WriteLine($"{myInt2} is the large number");
            }

            if(myInt<7 && myInt<5)
            {
                Console.WriteLine(myInt);
            }

            if(myInt>5 || myInt < 7)
            {
                Console.WriteLine(myInt);
            }
            if (!(myInt < 7 && myInt < 5))
            {
                Console.WriteLine(myInt);
            }

        }
    }
}
