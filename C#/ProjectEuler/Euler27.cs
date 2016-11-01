using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler27
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
      Console.WriteLine("Euler 27");

      BuildPrimes(1000000);

      HashSet<int> hsprime = new HashSet<int>(primes);

      for (int b = -999; b < 1000; b++)
      {
          for (int a = -999; a < 1000; a++)
          {
          int n = 0;

          while (true)
          {
            int testvalue = n*n + a*n + b;

            if (!hsprime.Contains(testvalue)) {
              break;
            }
            n++;
          }

          if (n > 20) {
            Console.WriteLine("n " + n + " a = " + a + " b = " + b);
          }

        }
      }

    }

  }
}
