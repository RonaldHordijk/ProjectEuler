using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler
{
  class Euler23
  {
    private static List<int> primes = new List<int>();
    private static HashSet<int> primesHS;

    private static List<int> nonabundant = new List<int>();
    private static HashSet<int> nonabundantHS;

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

    private static int getDividerSum2(int value)
    {
      if (primesHS.Contains(value))
      {
        return value + 1;
      }

      int prod = 1;

      for (int i = 0; primes[i] * primes[i] <= value; i++)
      {
        int p = 1;
        while (value % primes[i] == 0)
        {
          p = p * primes[i] + 1;
          value /= primes[i];
        }
        prod *= p;
      }
      
      if (value > 1)
      {
        prod = prod * (1 + value);
      }

      return prod;
    }

    private static int getDividerSum(int value)
    {
      int sum = 0;

      if (value <= 0)
      {
        return 0;
      }

      if (value == 1)
      {
        return 1;
      }

      if (primesHS.Contains(value))
      {
        return value + 1;
      }

      int sqrtValue = (int)Math.Floor(Math.Sqrt(value));

      if (sqrtValue * sqrtValue == value)
      {
        sum = sqrtValue;
        sqrtValue = sqrtValue - 1;
      }

      for (int i = 2; i <= sqrtValue; i++)
      {
        if ((value % i) == 0)
        {
          sum += i;
          sum += (value /i);
        }
      }

      // one and self
      sum += 1 + value;

      return sum;
    }


    static bool isNonAbundant(int value) {
      return getDividerSum2(value) > 2 * value;
    }


    static void BuildNonAbundant(int maxValue)
    {
      for (int i = 12; i < maxValue; i++)
      {
        if (isNonAbundant(i)) {
          nonabundant.Add(i);
        }
      }

      nonabundantHS = new HashSet<int>(nonabundant);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 23");

      BuildPrimes(28123);

      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      
      BuildNonAbundant(28123);

      stopwatch.Stop();
      Console.WriteLine("Time elapsed: {0}",
          stopwatch.Elapsed);

      int sum = 0;

      for (int i = 1; i <= 28123; i++)
      {
        bool canBeSummed = false;

        for (int nab = 0; nab < nonabundant.Count; nab++)
        {
          if (nonabundant[nab] > i)
          {
            break;
          }

          if (nonabundantHS.Contains(i - nonabundant[nab]))
          {
            canBeSummed = true;
            break;
          }
        }

        if (!canBeSummed) {
          sum += i;
        }
      }

      Console.WriteLine("total sum " + sum);
    }

  }
}
