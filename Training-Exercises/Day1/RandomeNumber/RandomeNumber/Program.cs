using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int target = random.Next(1, 101);
            Console.WriteLine("enter Your gues");
            int guess = Convert.ToInt32(Console.ReadLine());

            while (guess != target)
                {
                if (guess > target)
                    {
                        Console.WriteLine("Too high");
                    }
                    else if (guess < target)
                    {
                        Console.WriteLine("Too low");
                    }
                Console.WriteLine("enter Your gues");
                guess = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"the target number: {target}");
            Console.ReadKey();
        }
    }
}
