using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler123
  {

    private static List<int> primes = new List<int>();

    static void BuildPrimes(int maxValue)
    {
      bool[] map = new bool[maxValue];

      for (int i = 0; i < maxValue; i++)
      {
        map[i] = true;
      }

      for (int i = 2; i < maxValue; i++)
      {
        if (map[i] == true)
        {
          primes.Add(i);

          int wipe = i * 2;
          while (wipe < maxValue)
          {
            map[wipe] = false;
            wipe += i;
          }
        }
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 123");

      BigInteger limit = BigInteger.Pow(10,10);

      BuildPrimes(1000000);

      for (int i = 0; i < primes.Count; i++)
      {
        BigInteger p = new BigInteger(primes[i]);
        BigInteger sqr = p * p;
        BigInteger rem = (BigInteger.ModPow(p + 1, i + 1, sqr) + BigInteger.ModPow(p - 1, i + 1, sqr));
        rem = rem % sqr;

        if (rem > limit)
        {
          Console.WriteLine("limit reached at " + (i + 1));
          break;
        }
      }

      Console.WriteLine("at end");

    }

  }
}
