using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler401
  {
    public static void Go()
    {
      Console.WriteLine("Euler 138");

      long sum = 0;
      long limit = (long)Math.Pow(10, 15);
      limit = 99;

      sum = limit * limit * (limit + 1) / 2;

      for (long i = 1; i <= limit; i++)
      {
        long n = limit / i;
        long r = limit % i;
//        sum += i * i * n;
//        sum += i * i * n;
        long a = i * i * n;
        long b = i * limit;

        sum = sum - r * i;
        sum = sum % 1000000000;

        Console.WriteLine(i + " - " + r);

      }

      Console.WriteLine("sum " + sum);

      //99 - 394148
    }


  }
}
