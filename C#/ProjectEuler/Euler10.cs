using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler10
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
      Console.WriteLine("Euler 10");
      BuildPrimes(2000000);

      long sum = 0;

      foreach (int p in primes)
      {
        sum += p;
      }

      //			long sum = primes.Sum(x => x);

      Console.WriteLine("sum primes = " + sum);
    }
  }
}
