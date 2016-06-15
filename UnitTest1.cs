using System;
using Fractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionTestProject
{
 

        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void AdditionTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);
                Fraction f3 = f1 + f2;
                Assert.AreEqual("5/6", f3.ToString());

            }

            [TestMethod]
            public void SubtractionTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);
                Fraction f3 = f1 - f2;
                Assert.AreEqual("1/6", f3.ToString());

            }

            [TestMethod]
            public void MultiplicationTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);
                Fraction f3 = f1 * f2;
                Assert.AreEqual("1/6", f3.ToString());

            }
            [TestMethod]
            public void DivisionTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);
                Fraction f3 = f1 / f2;
                Assert.AreEqual("3/2", f3.ToString());

            }

            [TestMethod]
            public void GreaterThanTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);

                Assert.IsTrue(f1 > f2);
            }

            [TestMethod]
            public void LessThanTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);

                Assert.IsTrue(f1 < f2);

            }

            [TestMethod]
            public void EqualToTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);

                Assert.IsTrue(f1 == f2);

            }

            [TestMethod]
            public void NotEqualToTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);

                Assert.IsTrue(f1 != f2);

            }

            

            [TestMethod]
            public void LessThanToTestMethod()
            {
                Fraction f1 = new Fraction("1/2");
                Fraction f2 = new Fraction(1, 3);
                
                Assert.IsTrue(f1 <= f2);

            }
        }

    }

