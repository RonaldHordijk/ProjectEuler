using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler37
  {
    private static List<int> primes = new List<int>();
    private static HashSet<int> primesHS;

    static void BuildPrimes(int maxValue)
    {
      bool[] map = new bool[maxValue];
//      BitArray map = new BitArray(maxValue);

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

    private static void Attempt1()
    {
      int[] prefix = { 2, 3, 5, 7 };
      int[] postfix = { 3, 7 };

      List<int> truncPrimes = new List<int>();

      foreach (int p1 in prefix)
      {
        foreach (int p2 in postfix)
        {
          int testvalue = 10 * p1 + p2;

          if (primes.Contains(testvalue))
          {
            truncPrimes.Add(testvalue);
          }
        }
      }

      bool added = true;

      while (added)
      {
        added = false;

        foreach (int p in postfix)
        {
          for (int i = 0; i < truncPrimes.Count; i++)
          {
            {
              int testvalue = 10 * truncPrimes[i] + p;

              if (primes.Contains(testvalue) && !truncPrimes.Contains(testvalue))
              {
                truncPrimes.Add(testvalue);
                added = true;
              }
            }
          }
        }

        foreach (int p in prefix)
        {
          for (int i = 0; i < truncPrimes.Count; i++)
          {
            {
              int testvalue = Int32.Parse(p.ToString() + truncPrimes[i].ToString());

              if (primes.Contains(testvalue) && !truncPrimes.Contains(testvalue))
              {
                truncPrimes.Add(testvalue);
                added = true;
              }
            }
          }
        }
      }

      Console.Write("result ");
      foreach (int i in truncPrimes)
      {
        Console.WriteLine(i);
      }
      Console.WriteLine();
    }

    private static bool isTruncable(int value)
    {
      int v = value;

      while (v > 10)
      {
        v = v / 10;
        if (!primesHS.Contains(v))
        {
          return false;
        }
      }

      v = value;
      while (v > 10)
      {
        StringBuilder sb = new StringBuilder(v.ToString());
        sb[0] = ' ';
        v = Int32.Parse(sb.ToString());
        if (!primesHS.Contains(v))
        {
          return false;
        }
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 37");

      BuildPrimes(1000000);

//      Attempt1();

      for (int i = 0; i < primes.Count; i++)
      {
        if (isTruncable(primes[i]))
        {
          Console.WriteLine(primes[i]);
        }
      }
      


    }

  }
}
