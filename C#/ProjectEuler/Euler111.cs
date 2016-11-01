using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler111
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

    private static bool IsPrime(long value)
    {
      foreach (int p in primes)
      {
        if ((value % p) == 0)
        {
          return false;
        }

        if (((long)p * p) > value)
        {
          break;
        }
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 111");

      BuildPrimes(100000);

      int digits = 10;
      long totalsum = 0;
      StringBuilder sb = new StringBuilder();

      for (int v = 0; v < 10; v++)
      {
        int count = 0;
        long sum = 0;

        // initialize string
        sb.Clear();
        for (int d = 0; d < digits; d++)
        {
          sb.Append(v.ToString());
        }

        for (int d = 0; d < digits; d++) 
        {
          if ((v != 0) && (v != 2) && (v != 8))
          {
            continue;
          }

          for (int i = 0; i < 10; i++)
          {
            if (i == v)
            {
              continue;
            }

            sb[d] = i.ToString()[0];

            for (int d2 = d + 1; d2 < digits; d2++)
            {
              for (int j = 0; j < 10; j++)
              {
                if (j == v)
                {
                  continue;
                }

                sb[d2] = j.ToString()[0];

                if (sb[0] == '0')
                {
                  continue;
                }
                if (IsPrime(Int64.Parse(sb.ToString())))
                {
                  count++;
                  sum += Int64.Parse(sb.ToString());
//                  Console.WriteLine(sb.ToString());
                }
              }
              sb[d2] = v.ToString()[0];
            }
          }

          sb[d] = v.ToString()[0];
        }


        for (int d = 0; d < digits; d++)
        {
          if ((v == 0) || (v == 2) || (v == 8))
          {
            continue;
          }

          for (int i = 0; i < 10; i++)
          {
            if (i == v)
            {
              continue;
            }

            sb[d] = i.ToString()[0];
            if (sb[0] == '0')
            {
              continue;
            }
            if (IsPrime(Int64.Parse(sb.ToString())))
            {
              count ++;
              sum += Int64.Parse(sb.ToString());
            }
          }
          sb[d] = v.ToString()[0];
        }

        Console.WriteLine(v + " - " + count + " - "  + sum);
        totalsum += sum;
      }

      Console.WriteLine("totalsum " + totalsum);
    }

  }
}
