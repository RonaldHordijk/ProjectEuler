using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler188
  {
    public static void Go()
    {
      Console.WriteLine("Euler 188");

      BigInteger v = 1;

      for (int i = 0; i < 1855; i++)
      {
        v = BigInteger.ModPow(1777, v, 100000000);
      }

      Console.WriteLine("result " + v);

    }
  }
}
