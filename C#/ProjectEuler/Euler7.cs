using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler7
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
      Console.WriteLine("Euler 7");

      BuildPrimes(120000);

      Console.WriteLine("nrprimes = " + primes.Count);
      Console.WriteLine("nrprimes[6] = " + primes[6 - 1]);
      Console.WriteLine("nrprimes[6] = " + primes[10001 - 1]);    
    }

  }
}
