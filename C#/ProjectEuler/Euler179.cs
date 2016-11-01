using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler179
  {

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

    private static int getNrDivisors(int value)
    {
      int count = 0;

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
        return 2;
      }

      int sqrtValue = (int)Math.Floor(Math.Sqrt(value));

      if (sqrtValue * sqrtValue == value)
      {
        count = 1;
        sqrtValue = sqrtValue - 1;
      }

      for (int i = 2; i <= sqrtValue; i++)
      {
        if ((value % i) == 0)
        {
          count += 2;
        }
      }

      // one and self
      count += 2;

      return count;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 179");

      BuildPrimes(10000000);
      Console.WriteLine("primed");

      int nrPair = 0;
      int nrDivLast = getNrDivisors(2);

      for (int i = 3; i < 10000000; i++)
      {
        int nrDiv = getNrDivisors(i);

        if (nrDiv == nrDivLast)
        {
          nrPair++;
        }

        nrDivLast = nrDiv;
      }

      Console.WriteLine("NrPairs : " + nrPair);
    }

  }
}
