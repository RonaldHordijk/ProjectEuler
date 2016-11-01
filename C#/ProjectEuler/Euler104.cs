using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler104
  {

    private static bool IsPandigital(string s)
    {
      int[] digits = new int[10];
      for (int i = 0; i < 9; i++)
      {
        int c = (int)s[i] - 48;

        if (c == 0)
        {
          return false;
        }

        if (digits[c] > 0)
        {
          return false;
        }

        digits[c] = 1;
      }

      return true;
    }

    private static bool HasPanDigitalEnd(BigInteger v)
    {
      int vi = (int)(v % 1000000000L);

      int[] digits = new int[10];
      for (int i = 0; i < 9; i++)
      {
        int c = vi % 10;

        if (c == 0)
        {
          return false;
        }

        if (digits[c] > 0)
        {
          return false;
        }

        digits[c] = 1;

        vi = vi / 10;
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 104");

      BigInteger[] fib = { BigInteger.Parse("1"), BigInteger.Parse("1") };
      int count = 2;
      int last = 0;

      while (true)
      {

        if (HasPanDigitalEnd(fib[last]))
        {
          Console.WriteLine("fib " + count + " has pandigial end");

          string s = fib[last].ToString();
          if (IsPandigital(s.Substring(0, 9)))
          {
            Console.WriteLine("fib " + count + " has pandigial start and end");
            break;
          }
        }

        last = 1 - last;
        fib[last] = fib[0] + fib[1];

        count++;

      }
    }
  }
}
