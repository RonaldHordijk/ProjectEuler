using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler38
  {
    private static bool isPandigital(string s)
    {
      HashSet<int> t = new HashSet<int>(s.ToCharArray().Select(x => Int32.Parse(x.ToString())));

      return (t.Count == 9) && (t.Min() == 1);
    }

    public static void Go()
    {
      Console.WriteLine("Euler 38");

      int biggestPandigit = 0;

      for (int i = 2; i < 99; i++)
      {
        string strnum = "";
        for (int j = 1; j < 6; j++)
        {
          strnum += (i * j).ToString();
        }

        if ((strnum.Length == 9) && (isPandigital(strnum)))
        {
          Console.WriteLine(strnum);

          if (Int32.Parse(strnum) > biggestPandigit)
          {
            biggestPandigit = Int32.Parse(strnum);
          }
        }
      }

      for (int i = 2; i < 99; i++)
      {
        string strnum = "";
        for (int j = 1; j < 5; j++)
        {
          strnum += (i * j).ToString();
        }

        if ((strnum.Length == 9) && (isPandigital(strnum)))
        {
          Console.WriteLine(strnum);

          if (Int32.Parse(strnum) > biggestPandigit)
          {
            biggestPandigit = Int32.Parse(strnum);
          }
        }
      }

      for (int i = 2; i < 999; i++)
      {
        string strnum = "";
        for (int j = 1; j < 4; j++)
        {
          strnum += (i * j).ToString();
        }

        if ((strnum.Length == 9) && (isPandigital(strnum)))
        {
          Console.WriteLine(strnum);

          if (Int32.Parse(strnum) > biggestPandigit)
          {
            biggestPandigit = Int32.Parse(strnum);
          }
        }
      }


      for (int i = 2; i < 99999; i++)
      {
        string strnum = "";
        for (int j = 1; j < 3; j++)
        {
          strnum += (i * j).ToString();
        }

        if ((strnum.Length == 9) && (isPandigital(strnum)))
        {
          Console.WriteLine(strnum);

          if (Int32.Parse(strnum) > biggestPandigit)
          {
            biggestPandigit = Int32.Parse(strnum);
          }
        }
      }

      Console.WriteLine("biggest: " + biggestPandigit);
    }

  }
}
