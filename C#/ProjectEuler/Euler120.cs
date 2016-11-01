using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler120
  {
    public static void Go()
    {
      Console.WriteLine("Euler 120");

      int sumRemainder = 0;
      for (int i = 3; i <= 1000; i++) {
        int remainder = ((1 -1) * (i +1)) % (i * i);

        for (int n = 3; n < 10 * i; n+= 2) {
          remainder = Math.Max(remainder, (2 * i * n) % (i * i));
        }
        Console.WriteLine(i + " - " + remainder);
        sumRemainder += remainder;
      }

      Console.WriteLine("sum: " + sumRemainder);
    }

  }
}
