using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler436
  {
    public static void Go2()
    {
      Console.WriteLine("Euler 436");

      Random rand = new Random();
      long winl2 = 0;
      long limit = 100000000000;

      for (long i = 0; i < limit; i++)
      {
        double sum = 0;
        double l1 = 0;
        double l2 = 0;

        while (sum < 1) {
          l1 = rand.NextDouble();
          sum += l1;
        }
        while (sum < 2) {
          l2 = rand.NextDouble();
          sum += l2;
        }

        if (l2 > l1)
        {
          winl2++;
        }
        
      }

      Console.WriteLine("chance " + ((double)winl2 / limit));
    }


    private static int bucketSize = 100000000;
    private static double[] current = new double[bucketSize];
    private static double[] next = new double[bucketSize];
    private static double[] result1 = new double[bucketSize];
    private static double[] result2 = new double[bucketSize];
    private static double[] start2 = new double[bucketSize];


    public static void Go()
    {
      Console.WriteLine("Euler 436");

      Stopwatch sw = new Stopwatch();
      sw.Start();

      current[0] = 1;
      while (current.Sum() > 1E-18)
      {
        Array.Clear(next, 0, next.Length);

        for (int i = 0; i < bucketSize; i++)
        {
          double step = current[i] / bucketSize;
          if (current[i] < 1E-15)
          {
            continue;
          }

          for (int j = 0; j < bucketSize; j++)
          {
            if ((i + j) < bucketSize)
            {
              next[i + j] += step;
            }
            else
            {
              result1[j] += step;
              start2[i + j - bucketSize] += step;
            }
          }
        }
        Array.Copy(next, current, next.Length);
      }

      // to 2
      Array.Copy(start2, current, start2.Length);

      while (current.Sum() > 1E-18)
      {
        Array.Clear(next, 0, next.Length);

        for (int i = 0; i < bucketSize; i++)
        {
          double step = current[i] / bucketSize;
          if (current[i] < 1E-15)
          {
            continue;
          }

          for (int j = 0; j < bucketSize; j++)
          {
            if ((i + j) < bucketSize)
            {
              next[i + j] += step;
            }
            else
            {
              result2[j] += step;
            }
          }
        }
        Array.Copy(next, current, next.Length);
      }

      double sum2wins = 0;
      double sumequal = 0;

      for (int i = 1; i < bucketSize; i++)
      {
        for (int j = 0; j < i; j++)
        {
          sum2wins += result2[i] * result1[j];
        }
      }

      for (int i = 1; i < bucketSize; i++)
      {
        sumequal += result2[i] * result1[i];
      }

      Console.WriteLine("elapsed: " + sw.Elapsed);

      Console.WriteLine("change 2 wins " + sum2wins);
      Console.WriteLine("Equals " + sumequal);
      Console.WriteLine("avg w win " + (sum2wins + 0.5 * sumequal));

    }
  }
}
