using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler39
  {
    private static int[] squares = new int[1001];

    private static void initSquares()
    {
      for (int i = 1; i <= 1000; i++)
      {
        squares[i] = i * i;
      }
    }

    private static int CountTri(int sum)
    {
      int result = 0;

      for (int a = 1; a <= (sum / 3); a++)
      {
        for (int b = a + 1; b <= ((sum - a) /2); b++)
        {
          int c = sum - a - b;

          if ((squares[a] + squares[b] - squares[c]) == 0)
          {
            result++;
          }

        }
      }

      return result;
    }

    
    public static void Go()
    {
      Console.WriteLine("Euler 39");

      initSquares();

      int maxSol = 0;
      int maxSum = 0;

      for (int i = 1; i <= 1000; i++)
      {
        int nrSol = CountTri(i);

        if (nrSol > 2) {
          Console.WriteLine(i + " - " + nrSol);
        }

        if (nrSol > maxSol) {
          maxSol = nrSol;
          maxSum = i;
        }
      }


      Console.WriteLine(maxSum + " - " + maxSol);
    }
  }
}
