using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler115
  {
    private static long[] block = new long[501];

    private static long GetBlockSize(int size, int minBlocksize)
    {
      if (block[size] > 0)
      {
        return block[size];
      }

      if (size < minBlocksize)
      {
        return 1;
      }

      // space + one smaller
      long sum = block[size - 1];
      // block + black + rest
      for (int i = 0; i < size - minBlocksize; i++)
      {
        sum += block[i];
      }
      // whole block red
      sum += 1;


      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 115");

      block[0] = 1;

      for (int i = 0; i < 501; i++)
      {
        block[i] = GetBlockSize(i, 50);
        Console.WriteLine(i + " - " + block[i]);
        if (block[i] > 1000000)
        {
          break;
        }
      }

    }

  }
}
