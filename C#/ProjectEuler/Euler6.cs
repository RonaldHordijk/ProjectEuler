using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler6
  {
    private const long limit = 10;

    public static void Go()
    {
      Console.WriteLine("Euler 6");

      long sum = 0;
      long sumsqrs = 0;

      for (int i = 1; i <= limit; i++)
      {
        sum += i;
        sumsqrs += (i * i);
      }

      // quick
      //sum = limit*(limit + 1)/2;
      //sumsqrs = ((2*limit + 1)*(limit + 1)*limit)/6;
      Console.Write("result = " + (sum * sum - sumsqrs));
    }
  }
}
