using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler5
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


    static Dictionary<int, int> Factorize(long value)
    {
      Dictionary<int, int> res = new Dictionary<int, int>();
      long orgValue = value;
      int i = 0;

      while (i < primes.Count)
      {
        if (value % primes[i] == 0)
        {
          res.Add(primes[i], 1);
          value = value / primes[i];

          while (value % primes[i] == 0)
          {
            res[primes[i]] += 1;
            value = value / primes[i];
          }
        }

        i++;
      }

      Console.Write("factors of " + orgValue);

      foreach (int key in res.Keys)
      {
        Console.Write("  " + res[key] + " * " + key);
      }
      Console.WriteLine();

      return res;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 5");

      BuildPrimes(21);

      int[] map = new int[21];

      for (int i = 1; i <= 20; i++)
      {
        Dictionary<int, int> factors = Factorize(i);
        foreach (int key in factors.Keys)
        {
          map[key] = Math.Max(map[key], factors[key]);
        }
      }

      int product = 1;
      for (int i = 1; i <= 20; i++)
      {
        for (int j = 0; j < map[i]; j++)
        {
          product *= i;
        }
      }

      Console.Write("product = " + product);

    }

  }
}
