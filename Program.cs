
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
     class Program
    {
        public static void Main(string[] args)
        {
            
            Fraction f1 = new Fraction("1/2");
            Fraction f2 = new Fraction(1, 3);
            Fraction f3 = f1 + f2;

            Console.WriteLine(f1.ToString() + " + " + f2.ToString() + " = " + f3.ToString());
            Console.ReadKey();

        }

    }
}
