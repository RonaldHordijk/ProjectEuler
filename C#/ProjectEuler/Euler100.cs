using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler100
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

    private void BF1()
    {
      BigInteger i = BigInteger.Parse("1000000000000");
      while (true)
      {
        i++;

        BigInteger sq = 8 * (i * i - i) + 4;
        BigInteger sqt = SqRtN(sq);
        if (sqt * sqt != sq)
        {
          continue;
        }

        sqt += 2;

        if (sqt % 4 != 0)
        {
          continue;
        }


        Console.WriteLine("nr blue " + (sqt / 4));
        break;
      }
    }

    public static void Go()
    {
      Console.WriteLine("Euler 100");

      double sqrt2 = Math.Sqrt(2.0);
      double posv = 3.0 + 2* sqrt2;
      double negv = 3.0 - 2* sqrt2;



      for (long m = 2; m < 30; m++)
      {
        double n = 0.25 * (-Math.Pow(negv, m) - sqrt2 * Math.Pow(negv, m) - Math.Pow(posv, m) + sqrt2 * Math.Pow(posv, m) + 2);
        Console.WriteLine(m + ", n = " + n);
        double b = 0.125 * (2 * Math.Pow(negv, m) + sqrt2 * Math.Pow(negv, m) + 2 * Math.Pow(posv, m) - sqrt2 * Math.Pow(posv, m) + 4);
        Console.WriteLine(m + ", b = " + b);
        if (n > 1E12)
        {
          break;
        }
      }

    }

  }
}
