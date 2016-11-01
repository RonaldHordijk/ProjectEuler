using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler145
  {
    public static void Go()
    {
      Console.WriteLine("Euler 145");

      long count = 0;

      for (long i = 1; i < 1000000000; i++)
      {
        if (i%10 == 0) {
          continue;
        }

        long v = i;
        long r = 0;
        while (v > 0)
        {
          r = r * 10 + v % 10;
          v = v / 10;
        }

        r = r + i;
        bool isOdd = true;
        while (r > 0)
        {
          if (r % 2 == 0)
          {
            isOdd = false;
            break;
          }
          r = r / 10;
        }

        if (isOdd)
        {
          count++;
        }
      }

      Console.WriteLine("Nr reversable " + count);
    }
  }
}
