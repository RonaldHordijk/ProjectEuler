using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler435
  {
    public static void Go()
    {
      Console.WriteLine("Euler 435");

      BigInteger bigSum = 0;
      long ModValue = 1307674368000L;
      long[] fib = new long[] { 0, 1 };
      BigInteger[] powers = new BigInteger[101];
      int last = 1;

      //1 
      for (int i = 1; i <= 100; i++)
      {
        bigSum += i;
        powers[i] = i;
      }

      // n
//      BigInteger n = new BigInteger(2);
//      BigInteger end = BigInteger.Pow(10,5);
      long n = 2;
      long end = 1000000000000000L;
//      long end = 100000L;

      while (n <= end) {
        if (n % 100000 == 0)
        {
          Console.Write('.');
        }

        for (int i = 1; i <= 100; i++)
        {
          powers[i] *= i;
          powers[i] = powers[i] % ModValue;

          bigSum += powers[i] * fib[last];
        }
        bigSum = bigSum % ModValue;

        last = 1 - last;
        fib[last] = fib[0] + fib[1];
        fib[last] = fib[last] % ModValue;     
 
        n++;
      }

      Console.WriteLine("sum is " + bigSum);
    }
  }
}
