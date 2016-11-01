using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler112
  {
    private static bool IsBouncy(int value)
    {
      //List<int> digits = new List<int>(value.ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())));

      //bool isAcsending = true;

      //for (int i = 1; i < digits.Count; i++)
      //{
      //  if (digits[i - 1] > digits[i])
      //  {
      //    isAcsending = false;
      //  }
      //}
      //bool isDesending = true;

      //for (int j = 1; j < digits.Count; j++)
      //{
      //  if (digits[j - 1] < digits[j])
      //  {
      //    isDesending = false;
      //  }
      //}
      //return (!isAcsending && !isDesending); 

      int test = 0;
      int p = value % 10;
      int v = value /10;

      // test up
      while (v> 0)
      {
        if (p > v % 10) {
          test ++;
          break;
        }

        p = v % 10;
        v = v/10;
      }

      p = value % 10;
      v = value /10;

      // test down
      while (v> 0)
      {
        if (p < v % 10) {
          return (test == 1);
        }

        p = v % 10;
        v = v / 10;
      }

      return false;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 112");

      int count = 0;
      int limit = 2179000;
      for (int i = 1; i < limit; i++)
      {
        if (IsBouncy(i))
        {
          count++;

          if (i % 1000 == 0)
          {
            Console.WriteLine(i + " - " + (double)count / i);
          }

          if (count * 100 == i * 99)
          {
            Console.WriteLine("99% at " + i);
            break;
          }

        }
      }

      Console.WriteLine("nr bouncy: " + count);
      Console.WriteLine("percent " + (double)count / limit);
    }
  }
}
