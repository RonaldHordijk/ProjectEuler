using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler124
  {

    struct data
    {
      public int value;
      public int rad;
    };

    private static List<int> primes = new List<int>();
    private static HashSet<int> primesHS;

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

      primesHS = new HashSet<int>(primes);
    }

    private static int getDividerSum(int value)
    {
      if (primesHS.Contains(value))
      {
        return value;
      }

      int sum = 1;

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
        sum *= primes[i];
      }

      if (value > 1)
      {
        sum *= value; 
      }

      return sum;
    }

    private static int CompareRad(data x, data y)
    {
      if (x.rad == y.rad)
      {
        return x.value - y.value;
      }
      else
      {
        return x.rad - y.rad;
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 124");

      int limit = 100001;
      BuildPrimes(limit);
      List<data> rad = new List<data>();

      for (int i = 1; i < limit; i++)
      {
        data d;
        d.value = i;
        d.rad = getDividerSum(i);

        rad.Add(d);
      }

      rad.Sort(CompareRad);

      Console.WriteLine("E(10000) " + rad[10000-1].value);
    }
  }
}
