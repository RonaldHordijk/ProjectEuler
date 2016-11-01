﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace ProjectEuler
{
  class Euler441
  {
    private static int limit = 10000001;
//    private static int limit = 100001;
//    private static double[] SS = new double[limit];
    private static decimal SN;
//    private static double[] R = new double[limit];
    private static List<int> primes = new List<int>();
    private static HashSet<int> primesHS;
    private static bool[] GCDMap = new bool[limit];

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

    private static void BuildGCDMap(int value)
    {
      for (int i = 0; i < value; i++)
      {
        GCDMap[i] = true;
      }

      if (primesHS.Contains(value)) {
        return;
      }

      foreach (int p in primes)
      {
        if (p >= value)
        {
          break;
        }

        if (value % p == 0)
        {
          for (int i = p; i < value; i += p)
          {
            GCDMap[i] = false;
          }
        }
      }

    }

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
//      double sum = 0;

      BuildGCDMap(value);

      for (int i = 1; i < value; i += 1)
      {
        if (GCDMap[i])
        {
          decimal v = 1.0M / value;
          v = v / i;

          SN += Math.Min(limit - value,  i + 1) * v;
        }
      }
/*
      for (int i = 1; i < value; i += 1)
      {
        if (GCDMap[i])
        {
          double v = 1.0 / value;
          v = v / i;

          sum += v;

          if (value + i < limit)
          {
            SS[value + i] += v;
          }
        }
      }
*/      
/*
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
            */
//      R[value] = R[value - 1] + sum - SS[value - 1];
//      SN += R[value];
    }

    public static void Go()
    {
      Console.WriteLine("Euler 440");

      BuildPrimes(limit);

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
