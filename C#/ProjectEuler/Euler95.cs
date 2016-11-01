using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler95
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
          sum += (value / i);
        }
      }

      // one and self
      sum += 1 + value;

      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 23");

      BuildPrimes(1000000);

      Console.WriteLine("primes...");

      int limit = 1000000;
      int[] sumdiv = new int[limit];

      for (int i = 1; i< limit; i++)  {
        sumdiv[i] = getDividerSum(i) - i;
      }

      Console.WriteLine("dividers...");

      int MaxLoop = 0;
      int MaxStart = 0;

      for (int i = 1; i < limit; i++)
      {
        int start = i;
        int loop = 0;
        int walk = i;


        while (true)
        {
          walk = sumdiv[walk];
          loop++;

          if (loop > 1000) {
            break;
          }

          if (walk >= limit)
          {
            break;
          }

          if (walk < start)
          {
            break;
          }

          if (walk == start)
          {
            if (loop > MaxLoop)
            {
              MaxLoop = loop;
              MaxStart = start;
            }

            break;
          }

        }


      }

      Console.WriteLine("Start " + MaxStart + " Loop " + MaxLoop);
      
    }

  }
}
