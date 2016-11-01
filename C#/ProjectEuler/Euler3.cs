using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler3
  {
    private const long target = 600851475143;
    //		private const long target = 13195;

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

    static void Factorize(long value)
    {
      Console.WriteLine("target: ");
      Console.Write("factors: ");
      for (int i = 0; i < primes.Count; i++)
      {
        if (value % primes[i] == 0)
        {
          Console.Write(primes[i] + " ");
        }
      }
      Console.WriteLine();
    }

    public static void Go()
    {
      Console.WriteLine("Euler 3");

      buildPrimes((int)Math.Sqrt(target) + 1);

      Console.Write("primes: ");
      for (int i = 0; i < primes.Count; i++)
      {
        //				Console.Write(primes[i] + " ");
      }
      Console.WriteLine();
      Console.WriteLine();

      Factorize(target);

      Console.ReadKey();

    }

  }
}
