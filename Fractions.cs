using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        //private fields         
        private int numerator;
        private int denominator;
        private Fraction fract;
        /*************************************      * Public Constructors      * ***********************************/
        public Fraction()
        {
            //this is the default constructor             
            numerator = 0;
            denominator = 0;
        }
        public Fraction(int numerator, int denominator)
        {
            //this constructor takes in the numerator and denominator             
            //as integers             
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public Fraction(string fractionString)
        {
            //this constructor takes in a string of the format             
            // "2/3" it locates the division symbol and returns             
            //the number before it as an int, and the number after             
            //as an int             
            int divider = fractionString.IndexOf('/');
            string num = fractionString.Substring(0, divider);
            string den = fractionString.Substring(divider + 1);
            //this is a place where this could fail, if the string is             
            //in the wrong format             
            try
            {
                numerator = int.Parse(num);
                denominator = int.Parse(den);
            }
            catch
            {
                Exception ex = new Exception("Fraction string is in the wrong format");

                throw ex;
            }
        }
        public Fraction(Fraction f)
        {             //this constructor takes a fraction as parameter             
            fract = f;
        }
        /*******************************************          
        * Math operators + - * /          
        * *****************************************/
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction f3 = new Fraction();
            Fraction f4; //these recieve values from the out parameters             
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                //the denominators don't match                 
                //get the greatest common denominator                 
                //the out parameters provide a way of returning                 
                //more than one value from a method                 
                f3.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                //if they do match we still need to assign                 
                //the values to the new fractions so we                 
                //can do the math below                 
                f4 = f1;
                f5 = f2;
            }
            f3.denominator = f4.denominator;
            f3.numerator = f4.numerator + f5.numerator;
            //reduce the resulting fraction
            f3 = f3.ReduceFraction(f3);
            return f3;
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction f3 = new Fraction();
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f3.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;

                f5 = f2;
            }
            f3.denominator = f4.denominator;
            f3.numerator = f4.numerator - f5.numerator;
            f3 = f3.ReduceFraction(f3);
            return f3;
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            Fraction f3 = new Fraction();
            f3.numerator = f1.numerator * f2.numerator;
            f3.denominator = f1.denominator * f2.denominator;
            f3 = f.ReduceFraction(f3);
            return f3;
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            Fraction f3 = new Fraction(f2.denominator, f2.numerator);
            Fraction f4 = new Fraction();
            f4.numerator = f1.numerator * f3.numerator;
            f4.denominator = f1.denominator * f3.denominator;
            f4 = f.ReduceFraction(f4);
            return f4;
        }
        /*****************************************          
        * boolean comparision operators          
        * ==, !=, <, >, >=, <=          * 
        ***************************************/
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator == f5.numerator)
            {
                result = true;
            }
            return result;

        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator != f5.numerator)
            {
                result = true;
            }
            return result;
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator > f5.numerator)
            {
                result = true;
            }
            return result;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {

                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator < f5.numerator)
            {
                result = true;
            }
            return result;
        }
        public static bool operator >= (Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator >= f5.numerator)
            {
                result = true;
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            Fraction f1 = new Fraction(this.numerator, this.denominator);
            Fraction f2 = (Fraction)obj;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator == f5.numerator)
            {
                result = true;
            }
            return result;

        }
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            bool result = false;
            Fraction f4;
            Fraction f5;
            if (f1.denominator != f2.denominator)
            {
                f1.GreatestCommonDenominator(f1, f2, out f4, out f5);
            }
            else
            {
                f4 = f1;
                f5 = f2;
            }
            if (f4.numerator <= f5.numerator)
            {
                result = true;
            }
            return result;
        }
        /******************************************          
        * Helper and additional Functions          
        * ****************************************/
        public Fraction ReduceFraction(Fraction f)
        {
            Fraction fraction = f;
            Fraction f3 = new Fraction();
            int x = 2;
            while (x <= fraction.numerator)
            {
                if (fraction.numerator % x == 0 && fraction.denominator % x == 0)
                {
                    fraction.numerator /= x;
                    fraction.denominator /= x;
                }
                x++;
            }
            return fraction;
        }
        public override string ToString()
        {             //check to see if numerator is bigger than denominator             
                      //if it is seperate out the integer and concatinate it             
                      //to the base fraction string in the pattern of 3 1/2                         
            string fString = null;
            if (numerator > denominator)
            {
                int n = numerator / denominator;
                numerator = numerator % denominator;
                fString = n.ToString() + " " + numerator.ToString() + "/" + denominator.ToString();
            }
            else
            {
                fString = numerator.ToString() + "/" + denominator.ToString();
            }
            return fString;
        }
        private void GreatestCommonDenominator(Fraction f1, Fraction f2, out Fraction f4, out Fraction f5)
        {
            f1.numerator *= f2.denominator;
            f2.numerator *= f1.denominator;
            f1.denominator *= f2.denominator;
            f2.denominator = f1.denominator;
            f4 = f1;
            f5 = f2;
        }
        public int GetNumerator()
        {
            return numerator;
        }
        public int GetDenominator()
        {
            return denominator;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
