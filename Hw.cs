using System;

namespace Hw
{
    class Program
    {
        static void Main(string[] argc)
        {

            double a = double.PositiveInfinity;
            Console.WriteLine("+"+a+" + +"+a);

            a = double.NegativeInfinity;
            Console.WriteLine(a+" + "+a);

            a = double.MaxValue / double.PositiveInfinity;
            Console.WriteLine(a);

        }
    }
}