using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler58
  {
    private static List<int> primes = new List<int>();

    static void BuildPrimes(int maxValue)
    {
      //bool[] map = new bool[maxValue];
      BitArray map = new BitArray(maxValue);

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
      Console.WriteLine("Euler 58");

      BuildPrimes(800000000);
      HashSet<int> primesHS = new HashSet<int>(primes);

      int current = 1;
      int step = 2;
      int length = 1;
      int nrPrimes = 0;

      while (true)
      {
        length += 2;

        current += step;
        if (primesHS.Contains(current)) {
          nrPrimes++;
        }

        current += step;
        if (primesHS.Contains(current))
        {
          nrPrimes++;
        }

        current += step;
        if (primesHS.Contains(current))
        {
          nrPrimes++;
        }

        current += step;
        if (primesHS.Contains(current))
        {
          nrPrimes++;
        }

        step += 2;

        double percentage = Convert.ToDouble(nrPrimes) / ((4 * (length - 1) / 2) + 1);

        Console.WriteLine("level: " + length + " precent prime " + percentage);

        if (percentage < 0.1)
        {
          Console.WriteLine("last value " + current);
          break;
        }
      }

      Console.WriteLine("res = " + length);
    }

  }
}
