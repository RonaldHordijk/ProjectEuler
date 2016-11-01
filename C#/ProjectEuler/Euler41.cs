using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler41
  {
    private static List<int> primes = new List<int>();

    static void BuildPrimes(int maxValue)
    {
//      bool[] map = new bool[maxValue];
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

    private static bool IsPandigital(int value)
    {
      string s = value.ToString();
      HashSet<int> hs = new HashSet<int>(s.ToCharArray().Select(x => Int32.Parse(x.ToString())));

      return (s.Length == hs.Count) && (hs.Min() == 1) && (hs.Max() == hs.Count);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 41");
                     
      BuildPrimes(1000000000);

      Console.WriteLine("primed");


      for (int i = primes.Count - 1; i > 0; i--)
      {
        if (IsPandigital(primes[i]))
        {
          Console.WriteLine("pandigital : " + primes[i]);
        }
      }
    }
  }
}
