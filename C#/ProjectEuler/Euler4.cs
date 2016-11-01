using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler4
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

    static void Filter3DigitPrimes()
    {
      primes = primes.FindAll(x => x >= 100);
    }
    static void Filter2DigitPrimes()
    {
      primes = primes.FindAll(x => x >= 10);
    }

    static bool IsPalidrome(int testValue)
    {
      string s = testValue.ToString();

      switch (s.Length)
      {
        case 0:
          return true;
        case 1:
          return true;
        case 2:
          return (s[0] == s[1]);
        case 3:
          return (s[0] == s[2]);
        case 4:
          return ((s[0] == s[3]) && (s[1] == s[2]));
        case 5:
          return ((s[0] == s[4]) && (s[1] == s[3]));
        case 6:
          return ((s[0] == s[5]) && (s[1] == s[4]) && (s[2] == s[3]));
        case 7:
          return ((s[0] == s[6]) && (s[1] == s[5]) && (s[2] == s[4]));
        default:
          return false;
      }
    }

    static void BuildMaxPalidrome()
    {
      int maxPalidrome = 0;

      for (int i = 999; i >= 100; i--)
      {
        for (int j = i - 1; j >= 010; j--)
        {
          int testValue = i * j;

          if (IsPalidrome(testValue))
          {
            if (testValue > maxPalidrome)
            {
              maxPalidrome = testValue;
            }
          }
        }
      }

      Console.Write("maxPalidrome: " + maxPalidrome);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 4");

      //			BuildPrimes(999);
      //			Filter3DigitPrimes();
      BuildPrimes(99);
      Filter2DigitPrimes();

      BuildMaxPalidrome();

    }
  }
}
