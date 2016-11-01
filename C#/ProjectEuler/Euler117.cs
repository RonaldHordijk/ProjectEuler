using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler117
  {
    private static long[] block = new long[51];

    private static long GetBlockSize(int size)
    {
      if (block[size] > 0)
      {
        return block[size];
      }

      if (size < 2)
      {
        return 1;
      }

      // space + one smaller
      long sum = GetBlockSize(size - 1);
      // red + rest
      sum += GetBlockSize(size - 2);
      // green + rest
      if (size >= 3)
      {
        sum += GetBlockSize(size - 3);
      }
      // blue + rest
      if (size >= 4)
      {
        sum += GetBlockSize(size - 4);
      }

      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 117");

      for (int i = 0; i < 51; i++)
      {
        block[i] = GetBlockSize(i);
        Console.WriteLine(i + " - " + block[i]);
      }

    }
  }
}
