using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler138
  {
    public static BigInteger SqRtN(BigInteger N)
    {
      /*++
       *  Using Newton Raphson method we calculate the
       *  square root (N/g + g)/2
       */
      BigInteger rootN = N;
      int count = 0;
      int bitLength = 1; // There is a bug in finding bit length hence we start with 1 not 0
      while (rootN / 2 != 0)
      {
        rootN /= 2;
        bitLength++;
      }
      bitLength = (bitLength + 1) / 2;
      rootN = N >> bitLength;

      BigInteger lastRoot = BigInteger.Zero;
      do
      {
        if (lastRoot > rootN)
        {
          if (count++ > 1000)                   // Work around for the bug where it gets into an infinite loop
          {
            return rootN;
          }
        }
        lastRoot = rootN;
        rootN = (BigInteger.Divide(N, rootN) + rootN) >> 1;
      }
      while (!((rootN ^ lastRoot).ToString() == "0"));
      return rootN;
    } // SqRtN

    public static void Go()
    {
      Console.WriteLine("Euler 138");

      BigInteger h;
      BigInteger sum;
      BigInteger l;
      BigInteger lsum = 0;
      int cnt = 0;

      for (BigInteger b = 2;; b += 2)
      {
        h = b + 1;
        sum = (b * b) / 4 + h * h;
        l = SqRtN(sum);
        if (l * l == sum)
        {
          Console.WriteLine("B = " + b + " ,L = " + l + " ,H = " + h);
          lsum += l;
          cnt++;
          if (cnt == 12)
          {
            break;
          }
        }

        h = b - 1;
        sum = (b * b) / 4 + h * h;
        l = SqRtN(sum);
        if (l * l == sum)
        {
          Console.WriteLine("B = " + b + " ,L = " + l + " ,H = " + h);
          lsum += l;
          cnt++;
          if (cnt == 12)
          {
            break;
          }
        }

      }
      Console.WriteLine("Lsum " + lsum);
      Console.WriteLine("done");
    }

  }
}
