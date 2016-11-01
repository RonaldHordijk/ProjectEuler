using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler126
  {
    private static int limit = 20000;
    private static int[] C = new int[limit];

    private static long FirstLayer(int h, int l, int d)
    {
      int top = l * d;
      int contour = 2 * l + 2 * d;

      return  2 * top + h * contour;
    }

    private static bool BuildLayers(int h, int l, int d)
    {
      int top = l * d;
      int contour = 2 * l + 2 * d;

      int nrCubes = 2 * top + h * contour;
      if (nrCubes > limit)
      {
        return false;
      }

      while (nrCubes < limit)
      {
        C[nrCubes]++;

        top += contour;
        contour  += 4;

        nrCubes = 2 * top + h * contour;
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 126");

//      BuildLayers(1, 2, 3);

      for (int h = 1; FirstLayer(h,1,1) < limit; h++)
      {
        for (int l = h; FirstLayer(h, l, 1) < limit; l++)
        {
          for (int d = l; FirstLayer(h, l, d) < limit; d++)
          {

            if (!BuildLayers(h, l, d))
            {
              break;
            }
          }
        }
      }

      for (int i = 0; i < limit; i++)
      {
        if ((C[i] > 990) && (C[i] < 1010))
        {
          Console.WriteLine(i + " - " + C[i]);
        }
      }
      Console.WriteLine("done");

    }

  }
}
