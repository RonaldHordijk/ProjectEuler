using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler109
  {
    private static int[] values = new int[100];
    private static List<int> doubles = new List<int>();
    private static int[] scores2darts = new int[100];


    private static void FillArrays()
    {
      for (int i = 1; i <= 20; i++)
      {
        values[i]++;
        values[2 * i]++;
        values[3 * i]++;

        doubles.Add(2 * i);
      }

      values[25]++;
      values[50]++;
      doubles.Add(50);

      // one throw
      for (int i = 0; i < 100; i++)
      {
        scores2darts[i] = values[i];
      }

      // two throw
      for (int i = 1; i < 100; i++)
      {
        if (values[i] == 0)
        {
          continue;
        }

        if (i + i < 100)
        {
          if (values[i] == 3)
          {
            scores2darts[i + i] += 6;
          }
          else if (values[i] == 2)
          {
            scores2darts[i + i] += 3;
          }
          else
          {
            scores2darts[i + i]++;
          }
        }

        for (int j = i + 1; j < 100; j++)
        {
          if (i + j < 100)
          {
            scores2darts[i + j] += values[i] * values[j];
          }
        }
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 109");

      FillArrays();

      int sum = 0;

      for (int i = 2; i < 100; i++)
      {
        int sumcurrent = 0;

        foreach (int d in doubles)
        {
          if (d > i)
          {
            break;
          }
          if (d == i)
          {
            sumcurrent++;
          }
          else
          {
            sumcurrent += scores2darts[i - d];
          }
        }

        sum += sumcurrent;
      }

      Console.WriteLine("possible outs " + sum);
    }

  }
}
