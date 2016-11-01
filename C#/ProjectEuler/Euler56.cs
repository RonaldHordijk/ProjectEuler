using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler56
  {
    public static void Go()
    {
      Console.WriteLine("Euler 57");

      int maxsum = 0;

      for (int a = 1; a < 100; a++)
      {
        for (int b = 1; b < 100; b++)
        {
          BigInteger bi = BigInteger.Pow(a, b);
          int digitsum = bi.ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum();

          if (digitsum > maxsum)
          {
            maxsum = digitsum;
          }
        }
      }

      Console.WriteLine("maxdigits " + maxsum);
    }

  }
}
