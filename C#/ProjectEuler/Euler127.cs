using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler127
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

    private static int GCD(int a, int b)
    {
      int r = a % b;
      while (r > 0 ) {
        a = b;
        b = r;

        r = a % b;
      }
      return b;
    }

    private static long rad3(int a, int b, int c)
    {
      long prod = 1;

      for (int i = 0; primes[i] * primes[i] <= Math.Max(a, Math.Max(b, c)); i++)
      {
        if ((a % primes[i] != 0) && (b % primes[i] != 0) && (c % primes[i] != 0))
        {
          continue;
        }

        while (a % primes[i] == 0)
        {
          a /= primes[i];
        }
        while (b % primes[i] == 0)
        {
          b /= primes[i];
        }
        while (c % primes[i] == 0)
        {
          c /= primes[i];
        }
        prod *= primes[i];
      }

      if (a > 1)
      {
        prod *= a;
      }
      if ((b > 1) && (b != a))
      {
        prod *= b;
      }
      if ((c > 1) && (c != a) && (c != b))
      {
        prod *= c;
      }

      return prod;
    }

    private static int rad(int value)
    {
      int prod = 1;

      for (int i = 0; primes[i] * primes[i] <= value; i++)
      {
        if (value % primes[i] != 0)
        {
          continue;
        }

        while (value % primes[i] == 0)
        {
          value /= primes[i];
        }
        prod *= primes[i];
      }

      if (value > 1)
      {
        prod *= value;
      }

      return prod;
    }

    private static int[] rads;

    private static void BuildRadTable(int maxValue) {
      rads = new int[maxValue];

      for (int i = 0; i < maxValue; i++) {
        rads[i] = rad(i);
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 127");

      int limit = 120000;
      long csum = 0;

      BuildPrimes(limit);
      BuildRadTable(limit);

      for (int a = 1; a < limit /2; a++)
      {
        for (int b = a + 1; b < limit; b++)
        {
          int c = a + b;

          if (c >= limit)
          {
            continue;
          }

          if (((long)rads[a] * rads[b] * rads[c]) >= c)
          {
            continue;
          }

          if (GCD(a, b) != 1)
          {
            continue;
          }

          csum += c;
        }
      }

      Console.WriteLine("csum = " + csum);

    }

  }
}
