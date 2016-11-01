using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler116
  {
    private static long[] block = new long[51];

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
      // block + rest
      long sum = GetBlockSize(size - 1, minBlocksize) + GetBlockSize(size - minBlocksize, minBlocksize);

      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 116");

      long sum = 0;

      for (int i = 0; i < 51; i++)
      {
        block[i] = GetBlockSize(i, 2);
        Console.WriteLine(i + " - " + block[i]);
      }

      sum += block[50] - 1;

      Array.Clear(block, 0, 51);
      for (int i = 0; i < 51; i++)
      {
        block[i] = GetBlockSize(i, 3);
        Console.WriteLine(i + " - " + block[i]);
      }

      sum += block[50] - 1;

      Array.Clear(block,0, 51);
      for (int i = 0; i < 51; i++)
      {
        block[i] = GetBlockSize(i, 4);
        Console.WriteLine(i + " - " + block[i]);
      }

      sum += block[50] - 1;

      Console.WriteLine("total " + sum);

    }

  }
}
