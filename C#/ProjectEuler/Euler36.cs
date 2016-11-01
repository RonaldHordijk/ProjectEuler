using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler36
  {
    private static string GetBinString(int value)
    {
      StringBuilder sb = new StringBuilder();

      while (value > 0)
      {
        if (value % 2 == 0)
        {
          sb.Insert(0, '0');
        }
        else
        {
          sb.Insert(0, '1');
        }

        value = value / 2;
      }

      return sb.ToString();
    }

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
      Console.WriteLine("Euler 36");

      int sum = 0;

      for (int i = 1; i < 1000000; i++)
      {

        if (isPalidrome(i.ToString())) {
          string s = GetBinString(i);
          if (isPalidrome(s)) {
            sum += i;
          }
        }
      }

      Console.WriteLine("sum : " + sum);
    } 

  }
}
