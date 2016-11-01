using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler63
  {
    public static void Go()
    {
      Console.WriteLine("Euler 63");

      int count = 0;

      for (int i = 1; i < 100; i++)
      {
        for (int n = 1; n < 10000; n++)
        {
          BigInteger pow = BigInteger.Pow(n, i);

          string s = pow.ToString();

          if (s.Length > i)
          {
            break;
          }

          if (s.Length == i)
          {
            Console.WriteLine(s);
            count++;
          }
        }
      }

      Console.WriteLine("count is " + count);
    }

  }
}
