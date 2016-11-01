using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler118
  {
    private static List<int> primes = new List<int>();
    private static List<int> primesf = new List<int>();

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

    private static void FilterPrimes() {
      for (int i = 0; i < primes.Count(); ++i)
      {
        int[] digits = new int[10];
        int v = primes[i];

        bool canUse = true;
        while (v > 0)
        {
          int p = v % 10;

          if (p == 0)
          {
            canUse = false;
            break;
          }
          if (digits[p] != 0)
          {
            canUse = false;
            break;
          }

          digits[p] = 1;
          v = v / 10;
        }

        if (canUse)
        {
          primesf.Add(primes[i]);
        }
      }

    }

    private static int[] digits = new int[10];
    private static int digitsLeft = 9;
    private static Stack<int> solutions = new Stack<int>();
    private static int count = 0;

    private static void DisplayRes() 
    {
      foreach(int v in solutions) {
        Console.Write(v + ", ");
      }

      Console.WriteLine();

      count++;
    }

    private static void AddPrimes(int start) 
    {
      int maxValue = (int)Math.Pow(10, digitsLeft);

      for (int i = start; i < primesf.Count(); i++)
      {
        int v = primesf[i];

        if (v> maxValue) {
          return;
        }

        // test
        bool canUse = true;
        while (v > 0) {
          int p = v % 10;

          if (digits[p] != 0) {
            canUse = false;
            break;
          }

          v = v/10;
        }

        if (!canUse)
        {
          continue;
        }
                
        // set
        v = primesf[i];
        int nrdigits = 0;
        while (v > 0) {
          digits[v % 10] = 1;

          nrdigits++;
          v = v/10;
        }
        digitsLeft -= nrdigits;
        solutions.Push(primesf[i]);

        if (digitsLeft == 0) {
          DisplayRes();
        }
        
        AddPrimes(i+1);

        solutions.Pop();

        // remove
        v = primesf[i];
        digitsLeft += nrdigits;
        while (v > 0) {
          digits[v % 10] = 0;
          v = v/10;
        }
      }

    }

    public static void Go()
    {
      Console.WriteLine("Euler 118");

      BuildPrimes(100000000);
      FilterPrimes();

      digits[0] = 1;

      AddPrimes(0);
      
      Console.WriteLine("count " + count);
    }

  }
}
