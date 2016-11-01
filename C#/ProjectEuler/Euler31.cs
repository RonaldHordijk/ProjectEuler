using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler31
  {
    private static int[] coins = { 200, 100, 50, 20, 10, 5, 2, 1 };

    private static int CountFit(int value, int start)
    {
      // fit
      if (value == 0)
      {
        return 1;
      }

      // cent also fit
      if (start == coins.Length - 1) {
        return 1;
      }

      // no fit try smaller coins
      if (value < coins[start])
      {
        return CountFit(value, start + 1);
      }

      int sum = 0;
      while (value >= 0)
      {
        sum += CountFit(value, start + 1);

        value -= coins[start];
      }

      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 31");

      Console.WriteLine("nrFits " + CountFit(200, 0));
    }

  }
}
