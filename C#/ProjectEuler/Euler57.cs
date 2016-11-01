using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler57
  {
    public static void Go()
    {    
      Console.WriteLine("Euler 57");

      BigInteger denominator = 2;
      BigInteger numerator = 3;

      int counter = 0;

      for (int i = 1; i < 1000; i++)
      {
        BigInteger temp = denominator;

        denominator = denominator + numerator;
        numerator = numerator + 2 * temp;

        if (numerator.ToString().Length > denominator.ToString().Length)
        {
          counter++;
        }

      }

      Console.WriteLine("result " + counter);

    }
  }
}
