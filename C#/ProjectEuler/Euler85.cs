using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler85
  {
    public static void Go()
    {
      Console.WriteLine("Euler 85");

      int limit = 2000000;

      List<int> tri = new List<int>();
      tri.Add(0);

      int i = 1;
      int sum = 1;

      do
      {
        tri.Add(sum);

        i++;
        sum += i;
      } while (sum < limit);

      int nearest = 0;
      int area = 0;

      for (int x = 1; x < tri.Count; x++)
      {
        for (int y = x; y < tri.Count; y++)
        {
          int nrSquare = tri[x] * tri[y];

          if (Math.Abs(nrSquare - limit) < Math.Abs(nearest - limit))
          {
            nearest = nrSquare;
            area = x * y;
          }
        }
      }

      Console.WriteLine("area " + area);
      Console.WriteLine("near " + nearest);

    }

  }
}
