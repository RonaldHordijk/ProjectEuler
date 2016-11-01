using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler35
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

    private static List<int> GetAllCircleValues(int value) 
    {
      List<int> result = new List<int>();
      StringBuilder s = new StringBuilder(value.ToString());

      for (int i = 0; i< s.Length; i++)
      {
        result.Add(Int32.Parse(s.ToString()));

        s.Append(s[0]);
        s.Remove(0, 1);
      }

      return result;
    }

    private static bool HasEvenDigit(int value)
    {
      return value.ToString().ToCharArray().Any(x => (Int32.Parse(x.ToString()) % 2) == 0);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 35");

      BuildPrimes(1000000);

      int nrCircPrime = 0;

      HashSet<int> hsprime = new HashSet<int>(primes);

      foreach (int p in primes)
      {
        if (HasEvenDigit(p)) {
          continue;
        }

        List<int> circ = GetAllCircleValues(p);

        bool allprime = true;
        foreach (int c in circ)
        {
          if (!hsprime.Contains(c))
          {
            allprime = false;
            break;
          }
        }

        if (allprime)
        {
          nrCircPrime++;
        }

      }

      Console.WriteLine("nr circPrime " + (nrCircPrime + 1)); //1 for the value 2
    }

  }
}
