using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler66
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
      Console.WriteLine("Euler 66");

      BigInteger max = 0;
      int maxd = 0;

      for (int d = 2; d < 1000; d++)
      {
        BigInteger limit = (int)Math.Sqrt(d);
        if (limit * limit == d)
        {
          continue;
        }

//        BigInteger a = 

        

      }

      Console.WriteLine("max d: " + maxd);
    }

  }
}
