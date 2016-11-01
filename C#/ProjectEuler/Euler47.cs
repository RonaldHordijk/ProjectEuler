using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler47
  {
    private static List<int> primes = new List<int>();

    static void buildPrimes(int maxValue)
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

    static int FactorizeCount(long value)
    {
      int count = 0;
      double end  = value / 2;

      for (int i = 0; i < primes.Count; i++)
      {
        if (primes[i] > end)
        {
          break;
        }

        if (value % primes[i] == 0)
        {
          count++;
        }
      }

      return count;
    }



    public static void Go()
    {
      Console.WriteLine("Euler 47");

      int limit = 1000000;

      buildPrimes(Convert.ToInt32(Math.Sqrt(limit)));

      int sequence = 0;

      for (int i = 3; i < limit; i++)
      {
        if (i % 10000 == 0)
        {
          Console.Write('.');
        }

        if (FactorizeCount(i) == 4)
        {
          sequence++;
        }
        else
        {
          sequence = 0;
        }

        if (sequence == 4)
        {
          Console.WriteLine("found sequence starting at " + (i - sequence + 1));
          break;
        }

      }



    }
  }
}
