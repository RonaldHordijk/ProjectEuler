using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler204
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
      Console.WriteLine("Euler 204");

      int limit = 100000000;
      BuildPrimes(6);

      List<int> newValues;
      List<int> oldValues = new List<int>();
      oldValues.Add(1);

      foreach(int p in primes) {
        newValues = new List<int>();
        foreach (int v in oldValues)
        {
          long value = v;
          while (value < limit)
          {
            newValues.Add((int)value);
            value *= p;
          }
        }

        oldValues = newValues;
      }

      Console.WriteLine("count: " + oldValues.Count);
    }
  }
}
