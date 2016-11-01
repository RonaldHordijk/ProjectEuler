using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler26
  {
    private static int GetRepCycle(int denominator)
    {
      List<int> values = new List<int>();

      int value = 1;
      values.Add(value);

      while (true)
      {
         
        if (value > denominator)
        {
          value = value % denominator;
        }

        if (value == 0)
        {
          return 0;
        }

        value *= 10;

        if (values.Contains(value)) {
          return (values.Count - values.IndexOf(value));
        }

        values.Add(value);
      }

    }

    public static void Go()
    {
      Console.WriteLine("Euler 26");

      int MaxCycle = 0;

      for (int i = 2; i < 1000; i++)
      {
        int cycle = GetRepCycle(i);
        if (cycle > MaxCycle)
        {
          Console.WriteLine(i + " = " + cycle);
          MaxCycle = cycle;
        }
      }
    }

  }
}
