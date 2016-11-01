using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler171
  {
    public static void Go()
    {
      Console.WriteLine("Euler 171");

      long sum = 0;
      BigInteger sqr;

      for (BigInteger l = 1; l < 1000000000; l++)
      {
        sqr = l * l;

        while (sqr > 0)
        {
          int digit = (int)(sqr % 10);
          sum += digit * digit;

          sqr = sqr / 10;
        }
      }

      Console.Write("sum: " + sum);
    }

  }
}
