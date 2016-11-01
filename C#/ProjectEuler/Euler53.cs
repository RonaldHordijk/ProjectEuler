using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler53
  {
    private static List<BigInteger> factorials = new List<BigInteger>();

    private static void buildFactorials(int max)
    {
      factorials.Add(new BigInteger(1));
      for (int i = 1; i <= max; i++)
      {
        factorials.Add(i * factorials[i-1]);
      }
    }
    

    public static void Go()
    {
      Console.WriteLine("Euler 53");

      buildFactorials(100);
      int nrBig = 0;

      for (int n = 1; n <= 100; n++)
      {
        for (int r = 0; r <= n; r++)
        {
          BigInteger sum = factorials[n] / (factorials[r] * factorials[n - r]);
          if (sum > 1000000)
          {
            nrBig++;
          }

        }
      }

      Console.WriteLine("nr big " + nrBig);
    }
  }
}
