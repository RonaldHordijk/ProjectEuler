using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler205
  {
    public static void Go()
    {
      Console.WriteLine("Euler 205");

      long max4die = (int)Math.Pow(4, 9);
      int[] nrpos4die = new int[37];

      for (int i = 0; i < max4die; i++)
      {
        int v = i;
        int count = 9;
        while (v > 0)
        {
          count += v % 4;
          v = v / 4;
        }
        nrpos4die[count]++;
      }

      long max6die = (int)Math.Pow(6, 6);
      int[] nrpos6die = new int[37];

      for (int i = 0; i < max6die; i++)
      {
        int v = i;
        int count = 6;
        while (v > 0)
        {
          count += v % 6;
          v = v / 6;
        }
        nrpos6die[count]++;
      }

      long total9win = 0;

      for (int c4 = 9; c4 <= 36; c4++)
      {
        for (int c6 = 6; c6 < c4; c6++)
        {
          total9win += nrpos4die[c4] * nrpos6die[c6];
        }
      }

      double winchange = (double)total9win / (max4die * max6die);

      Console.WriteLine("change = " + winchange);
    }
  }
}
