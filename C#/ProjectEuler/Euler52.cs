using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler52
  {
    private static string SortString(int value)
    {
      char[] ca = value.ToString().ToCharArray();
      Array.Sort(ca);
      return new string(ca);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 52");

      string s1, s2, s3, s4, s5, s6;

      for (int i = 10; i < 1000000; i++)
      {
        s1 = SortString(i);

        s6 = SortString(i * 6);
        if (s1.Length != s6.Length) {
          continue;
        }

        if (s1 != s6) {
          continue;
        }

        s5 = SortString(i * 5);

        if (s1 != s5)
        {
          continue;
        }

        s4 = SortString(i * 4);
        if (s1 != s4)
        {
          continue;
        }

        s3 = SortString(i * 3);
        if (s1 != s3)
        {
          continue;
        }

        s2 = SortString(i * 2);
        if (s1 != s2)
        {
          continue;
        }

        Console.WriteLine("found " + i);
        break;
      }

      Console.WriteLine("at end ");
    }
  }
}
