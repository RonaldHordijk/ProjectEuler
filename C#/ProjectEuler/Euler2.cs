using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler2
  {
    private const int LimitValue = 4000000;

    public static void Go()
    {
      Console.WriteLine("Euler 2");

      int[] fib = { 0, 1 };
      int last = 0;
      int sum = 0;

      while (fib[last] < LimitValue)
      {
        Console.WriteLine(fib[last]);
        if (fib[last] % 2 == 0)
        {
          sum += fib[last];
        }

        last = 1 - last;
        fib[last] = fib[0] + fib[1];

      }

      Console.WriteLine("The sum is: " + sum);
    }
  }
}
