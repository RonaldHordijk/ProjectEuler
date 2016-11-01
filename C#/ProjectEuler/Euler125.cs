using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler125
  {
    private static bool isPalidrome(string s)
    {
      for (int i = 0; i < (s.Length / 2); i++)
      {
        if (s[i] != s[s.Length - i - 1])
        {
          return false;
        }
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 125");

      int limit = 100000000;
      List<int> squares = new List<int>();
      HashSet<int> solutions = new HashSet<int>();

      double endValue = Math.Sqrt(limit);

      for (int i = 0; i < endValue + 10; i++)
      {
        squares.Add(i * i);
      }

      long sum = 0;

      for (int i = 1; i <= endValue; i++)
      {
        int ints = squares[i] + squares[i + 1];
        int j = i + 2;

        while (ints < limit)
        {
          if (isPalidrome(ints.ToString()) && (!solutions.Contains(ints)))
          {
            sum += ints;
            solutions.Add(ints);
            Console.WriteLine(ints);
          }
          
          ints += squares[j];
          j++;
        }
      }

      Console.WriteLine("sum :" + sum);
    }
  }
}
