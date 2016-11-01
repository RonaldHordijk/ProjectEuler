using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace ProjectEuler
{
  class Euler441
  {
    private static int limit = 10001;
    private static double[] SS = new double[limit];
    private static double SN;
    private static double[] R = new double[limit];


    private static int GCD(int a, int b)
    {
      int r = a % b;
      while (r > 0)
      {
        a = b;
        b = r;

        r = a % b;
      }
      return b;
    }

    private static void AddLayer(int value) {
      double sum = 0;

      if ((value % 2) == 0)
      {
        for (int i = 1; i < value; i += 2)
        {
          if (GCD(i, value) == 1)
          {
            double v = 1.0 / (value * i);
            sum += v;

            if (value + i < limit)
            {
              SS[value + i] += v;
            }
          }
        }
      }
      else
      {
        for (int i = 1; i < value; i += 1)
        {
          if (GCD(i, value) == 1)
          {
            double v = 1.0 / (value * i);
            sum += v;

            if (value + i < limit)
            {
              SS[value + i] += v;
            }
          }
        }
      }

      R[value] = R[value - 1] + sum - SS[value - 1];
      SN += R[value];
    }

    public static void Go()
    {
      Console.WriteLine("Euler 440");

      Stopwatch sw = new Stopwatch();
      sw.Start();

      for (int i = 2; i < limit; i++)
      {
        AddLayer(i);

//        Console.WriteLine("S[" + i + "]= " + SN);
      }

      Console.WriteLine("S[" + (limit - 1) + "]= " + SN);
      Console.WriteLine("elapsed: " + sw.Elapsed);
    }
  }
}
