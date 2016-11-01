using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler114
  {
    private static long[] block = new long[51];

    private static long GetBlockSize(int size)
    {
      if (block[size] > 0) {
        return block[size];
      }

      if (size < 3)
      {
        return 1;
      }

      // space + one smaller
      long sum = block[size - 1];
      // block + black + rest
      for (int i = 0; i < size - 3; i++) {
        sum += block[i];
      }
      // whole block red
      sum += 1;


      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 114");

      block[0] = 1;

      for (int i = 0; i < 51; i++){
        block[i] = GetBlockSize(i);
        Console.WriteLine(i + " - " + block[i]);
      }

      


    }
  }
}
