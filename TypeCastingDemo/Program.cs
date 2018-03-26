using System;

namespace TypeCastingDemo
{
    internal class Program
    {
        private static void Main()
        {
            var z = new Complex(im: 10); // 0 + 10i
            Console.WriteLine($"z = {z};");

            Complex complex = 10;
            var re = -10 + complex + 14;

            if (z == complex)
                Console.WriteLine("complex numbers are equal");

        }
    }
}
