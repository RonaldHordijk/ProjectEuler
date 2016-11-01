using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler30
  {
    public static void Go()
    {
      Console.WriteLine("Euler 30");

      int[] powers = new int[10];

      for (int i = 0; i < 10; i++)
      {
        powers[i] = Convert.ToInt32( Math.Pow(i, 5));
      }

      int totSum = 0;

      for (int i = 2; i < 354295; i++)
      {
        int sum = i.ToString().ToCharArray().Sum(x => powers[Int32.Parse(x.ToString())]);

        if (sum == i)
        {
          totSum += i;
          Console.WriteLine(i);
        }
      }

      Console.WriteLine("sum =  " + totSum);

    }
  }
}
