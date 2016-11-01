using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler69
  {
    private static int limit = 1000001;

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

    private static List<int> buildFactorList(int value)
    {
      List<int> result = new List<int>();

      //if (primesHS.Contains(value))
      //{
      //  return result;
      //}

      for (int i = 0; primes[i] * primes[i] <= value; i++)
      {
        if (value % primes[i] == 0)
        {
          result.Add(primes[i]);

          do
          {
            value /= primes[i];
          } while (value % primes[i] == 0);
        }
      }

      if (value > 1)
      {
        result.Add(value);
      }

      return result;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 69");

      double maxPhi = 0;
      int maxi = 0;

      BuildPrimes(limit);
      for (int i = 2; i < limit; i++)
      {
        if (primesHS.Contains(i))
        {
          continue;
        }

        List<int> factors = buildFactorList(i);

        double count = i;

        foreach (int factor in factors)
        {
          count = count * (1.0 - 1.0/factor);
        }


        double Phi = i;
        Phi = Phi / count;

        if (Phi > maxPhi)
        {
          maxPhi = Phi;
          maxi = i;
        }

      }

      Console.WriteLine("MaxPhi " + maxPhi + " for " + maxi);

    }
  }
}
