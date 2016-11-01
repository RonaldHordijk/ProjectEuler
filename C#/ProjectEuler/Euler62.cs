using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  struct twoint
  {
    public int count;
    public long value;
  };

  class Euler62
  {
    private static Dictionary<string, twoint> solutions = new Dictionary<string, twoint>();

    public static void Go()
    {
      Console.WriteLine("Euler 62");

      for (long i = 1; i < 20000; i++)
      {
        long cube = i * i * i;

        string s = cube.ToString();
        char[] ca = s.ToCharArray();
        Array.Sort(ca);
        s = new string(ca);

        if (solutions.ContainsKey(s))
        {
          twoint a = solutions[s];
          a.count++;
          solutions[s] = a;

          if (solutions[s].count >= 5)
          {
            Console.WriteLine("value " + solutions[s].value + " times " + solutions[s].count);
          }
        }
        else
        {
          twoint a;
          a.value = cube;
          a.count = 1;
          solutions.Add(s, a);
        }
      }


    }

  }
}
