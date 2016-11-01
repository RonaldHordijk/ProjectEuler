using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler9
  {
    public static void Go()
    {
      Console.WriteLine("Euler 9");

      int product = 0;

      int[] squares = new int[1001];
      for (int i = 1; i <= 1000; i++)
      {
        squares[i] = i * i;
      }


      for (int a = 1; a < 334; a++)
      {
        for (int b = a + 1; b < 500; b++)
        {
          int c = 1000 - a - b;

          if ((squares[a] + squares[b] - squares[c]) == 0)
          {
            product = a * b * c;
          }

        }
      }

      Console.WriteLine("product  = " + product);
    }

  }
}
