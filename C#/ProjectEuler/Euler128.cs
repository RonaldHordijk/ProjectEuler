using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler128
  {
    private static List<int> primes = new List<int>();
    private static HashSet<int> primesHS;
    private static int primeLimit = 10000000;

    static void BuildPrimes(int maxValue)
    {
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
      primesHS = new HashSet<int>(primes);
    }

    private static List<long> P3 = new List<long>();

    private static bool isPrime(long value)
    {
      if (value < primeLimit)
      {
        return (primesHS.Contains((int)value));
      }

      for (int i = 0; i < primes.Count; i++)
      {
        long p = primes[i];

        if (p * p > value)
        {
          return true;
        }

        if (value % p  == 0)
        {
          return false;
        }
      }

      return true;
    }

    private static void testPrimes(long current, long v1, long v2, long v3)
    {
      if (!isPrime(v1))
      {
        return;
      }
      if (!isPrime(v2))
      {
        return;
      }
      if (!isPrime(v3))
      {
        return;
      }

      P3.Add(current);
      Console.WriteLine(P3.Count + " - " + current);
    }

    private static void testNeighbours(long current, long[] neighbours)
    {
      int count = 0;

      foreach (long v in neighbours)
      {
        if (v == 0)
        {
          continue;
        }

        if (isPrime(Math.Abs(v - current)))
        {
          count++;
        }
      }

      if (count == 3) {
        P3.Add(current);
        Console.WriteLine(P3.Count + " - " + current);
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 128");

      BuildPrimes(primeLimit);

      long[] neigh = new long[6];

      long nextCircle = 6;
      long prevCircle = 2;
      long sideLength = 0;
      long current = 1;

      // circle 0
      neigh[0] = 2;
      neigh[1] = 3;
      neigh[2] = 4;
      neigh[3] = 5;
      neigh[4] = 6;
      neigh[5] = 7;

      testNeighbours(1, neigh);
      /*
            // HC 7
            neigh[0] = 1;
            neigh[1] = 2;
            neigh[2] = 6;
            neigh[3] = 17;
            neigh[4] = 18;
            neigh[5] = 19;

           testNeighbours(7, neigh);

            for (long ring = 1; ; ring++)
            {
              if (P3.Count > 10)
              {
                break;
              }

              //neigh[0] = ring * 6 + 1;
              //neigh[1] = ring * 12 + 5;
              //neigh[2] = ring * 6 - 1;
              //neigh[3] = 0;
              //neigh[4] = 0;
              //neigh[5] = 0;

              testPrimes(ring * (ring - 1) * 3 + 2, ring * 6 + 1, ring * 6 - 1, ring * 12 + 5);

              //neigh[0] = ring * 6 + 5;
              //neigh[1] = (ring - 1) * 12 + 5;
              //neigh[2] = (ring * 6 +1 ) - 1;
              //neigh[3] = 0;
              //neigh[4] = 0;
              //neigh[5] = 0;

              testPrimes(ring * (ring + 1) * 3 + 1, ring * 6 + 5, (ring - 1) * 12 + 5, (ring * 6 + 1) - 1);
            }
      */


      for (int circle = 1; ; circle++)
      {
        if (P3.Count > 2000)
        {
          break;
        }

        prevCircle = 6 * (circle - 1);
        if (circle == 1)
        {
          prevCircle = 1;
        }

        for (int i = 0; i < 6; i++)
        {
          current++;
          neigh[0] = current + nextCircle;

          if (i == 0)
          {
            neigh[1] = neigh[0] + ((circle + 1) * 6 - 1);
            neigh[2] = current + (circle * 6 - 1);
          }
          else
          {
            neigh[1] = neigh[0] - 1;
            neigh[2] = current - 1;
          }

          neigh[3] = current - prevCircle;
          if ((i == 5) && (circle == 1))
          {
            neigh[4] = current - (circle * 6 - 1);
            neigh[5] = neigh[0] + 1;
          }
          else
          {
            neigh[4] = current + 1;
            neigh[5] = neigh[0] + 1;
          }
          testNeighbours(current, neigh);

          for (int side = 0; side < sideLength; side++)
          {
            current++;

            neigh[0] = current - prevCircle - 1;
            neigh[1] = neigh[0] + 1;
            neigh[2] = current - 1;
            neigh[3] = current + 1;
            neigh[4] = current + nextCircle;
            neigh[5] = neigh[4] + 1;

            if ((i == 5) && (side == sideLength - 1))
            {
              neigh[1] = neigh[1] - ((circle - 1) * 6);
              neigh[3] = neigh[3] - (circle * 6);
            }

            testNeighbours(current, neigh);
          }

          nextCircle++;
          prevCircle++;

        }

        sideLength++;
      }

      Console.WriteLine("P3[10] = " + P3[9]);
      Console.WriteLine("P3[2000] = " + P3[1999]);

    }

  }
}
