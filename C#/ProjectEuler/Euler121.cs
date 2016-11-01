using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler121
  {
    public static void Go()
    {
      Console.WriteLine("Euler 121");

      long nrWin = 0;
      long nrLose = 0;

      for (int i = 0; i < 32768; i++)
      {
        int v = i;
        long chance = 1;
        int nrRed = 0;
        for (int d = 0; d < 15; d++)
        {
          if (v % 2 == 1)
          {
            // red
            chance *= (d + 1);
            nrRed++;
          }

          v = v / 2;
        }

        if (nrRed <= 7)
        {
          nrWin += chance;
        }
        else
        {
          nrLose += chance;
        }
      }

      Console.WriteLine("Win: " + nrWin);
      Console.WriteLine("Lose: " + nrLose);
      Console.WriteLine("Price: " + (1.0 * (nrWin + nrLose) /nrWin));

    }  

  }
}
