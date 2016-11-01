using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler14
  {
    //collatz
    private const int maxNum = 1000000;
    private static int[] sequenceSize = new int[maxNum + 1];

    static int getCollatzSequenseSize(int start)
    {
      int count = 0;
      long value = start;

      while ((value > maxNum) || (sequenceSize[value] == 0))
      {
        if (value % 2 == 0)
        {
          value = value / 2;
        }
        else
        {
          value = 3 * value + 1;
        }

        count++;
      }

      return count + sequenceSize[value];
    }

    public static void Go()
    {
      Console.WriteLine("Euler 14");

      sequenceSize[1] = 1;

      for (int i = 2; i < maxNum; i++)
      {
        sequenceSize[i] = getCollatzSequenseSize(i);
      }

      Console.WriteLine("size[13] = " + sequenceSize[13]);

      int max = sequenceSize.Max();

      Console.WriteLine("max = " + max);
      for (int i = 2; i < maxNum; i++)
      {
        if (sequenceSize[i] == max)
        {
          Console.WriteLine("starting from " + i);
        }

      }

    }
  }
}
