using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectEuler
{
  class Euler437
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

    private static List<int> buildFactorList(int value)
    {
      List<int> result = new List<int>();

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

    private static bool isFPRCombo(int value, long root, List<int> factors)
    {
      if (((root * root) % value) != (root + 1))
      {
        return false;
      }

      foreach (int factor in factors)
      {
        if (BigInteger.ModPow(root, factor, value) == 1)
        {
          return false;
        }
      }

      return true;
    }

    private static bool isFPRCombo2(int value, long root, List<int> factors)
    {
      if (((root * root) % value) != (root + 1))
      {
        return false;
      }

      long otherOne = value + 1 - root;
      if (((otherOne * otherOne) % value) != (otherOne + 1))
      {
        return false;
      }

      foreach (int factor in factors)
      {
        if (BigInteger.ModPow(root, factor, value) == 1)
        {
          return false;
        }
      }

      return true;
    }

    private static bool isFPR(int value)
    {
      int mod10 = value % 10;

      if ((mod10 != 1) && (mod10 != 9))
      {
        return false;
      }

      List<int> factors = buildFactorList(value - 1);
      factors = new List<int>(factors.Select(x => (value - 1) / x));

      int endtest = value - 1;
      if (value % 4 == 1)
      {
        endtest = (value + 1) / 2;
      }

        for (int i = 2; i <= endtest; i++)
        {
          if (isFPRCombo(value, i, factors))
          {
            return true;
          }
        }
      

      return false;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 437");

      Stopwatch sw = new Stopwatch();
      
      int limit = 1000000000;

      BuildPrimes(limit);

      sw.Start();
      long sum = 5;

      Parallel.For(3, primes.Count, i =>
      {
        if (isFPR(primes[i]))
        {
          if (i % 100 == 0)
          {
            Console.WriteLine(i);
          }
          Interlocked.Add(ref sum, primes[i]);
        }
      }
      );

      Console.WriteLine("elapsed " + sw.Elapsed);
      Console.WriteLine("sum " + sum );
    }

  }
}
