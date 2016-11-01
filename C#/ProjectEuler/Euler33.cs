using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  struct Fraction {
    public int numerator;
    public int denominator;

    public void reduce()
    {
      for (int i = 2; (i <= numerator) && (i <= denominator); i++)
      {
        while (((numerator % i) == 0) && ((denominator % i) == 0))
        {
          numerator = numerator / i;
          denominator = denominator / i;
        }
      }
    }
  }

  class Euler33
  {

    public static void Go()
    {
      Console.WriteLine("Euler 33");

      Fraction f1, f2;

      Fraction sum;
      sum.denominator = 1;
      sum.numerator = 1;

      for (int i = 10; i < 100; i++)
      {
        for (int j = i + 1; j < 100; j++)
        {
          f1.numerator = i;
          f1.denominator = j;
          if ((f1.numerator % 10) != (f1.denominator / 10))
          {
            continue;
          }


          f2.numerator = i / 10;
          f2.denominator = j % 10;

          f1.reduce();
          f2.reduce();

          if ((f1.numerator == f2.numerator) && (f1.denominator == f2.denominator))
          {
            sum.numerator *= f1.numerator;
            sum.denominator *= f1.denominator;

            Console.WriteLine("- " + i + " " + j);
          }
        }
      }

      sum.reduce();
      Console.WriteLine("res " + sum.denominator);



    }
  }
}
