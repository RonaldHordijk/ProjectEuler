using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler32
  {

    private static bool DigitIn(int digit, int value)
    {
      while (value > 0)
      {
        if (digit == value % 10)
        {
          return true;
        }
        value = value / 10;
      }

      return false;
    }

    private static bool isPandigital(string s)
    {
      HashSet<int> t = new HashSet<int>(s.ToCharArray().Select(x => Int32.Parse(x.ToString())));

      return (t.Count == 9) && (t.Min() == 1);
    }

    private static bool IsPandigitial(int a, int b, int c)
    {
      return isPandigital(a.ToString() + b.ToString() + c.ToString());
    }


    public static void Go()
    {
      Console.WriteLine("Euler 32");

      HashSet<int> products = new HashSet<int>();

      // A * BBBB = CCCC
      for (int i = 2; i < 10; i++)
      {
        for (int j = 1234; j <= 9876; j++)
        {
          if (DigitIn(i, j))
          {
            continue;
          }

          int proc = i * j;

          if (proc >= 10000)
          {
            continue;
          }

          if (IsPandigitial(i, j, proc) && (!products.Contains(proc)))
          {
            products.Add(proc);
            Console.WriteLine(i + " * " + j + " = " + proc);
          }
        }
      }

      // AA * BBB = CCCC
      for (int i = 12; i < 98; i++)
      {
        for (int j = 123; j <= 987; j++)
        {
          if (DigitIn(i % 10, j) || DigitIn(i / 10, j))
          {
            continue;
          }

          int proc = i * j;

          if (proc >= 10000)
          {
            continue;
          }

          if (IsPandigitial(i, j, proc)  && (!products.Contains(proc)))
          {
            products.Add(proc);
            Console.WriteLine(i + " * " + j + " = " + proc);
          }
        }
      }

     
      Console.WriteLine("sum " + products.Sum());

    }

  }
}
