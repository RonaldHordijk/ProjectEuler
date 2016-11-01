using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler34
  {
    public static void Go()
    {
      Console.WriteLine("Euler 34");

      int[] fac = new int[10];

      fac[0] = 1;
      fac[1] = 1;

      for (int i = 2; i < 10; i++)
      {
        fac[i] = i * fac[i - 1];
      }

      long sum = 0;

      for (int i = 3; i < 2540161; i++)
      {
        int sumfac = i.ToString().ToCharArray().Sum(x => fac[Int32.Parse(x.ToString())]);

        if (i == sumfac)
        {
          sum += i;

          Console.WriteLine(i);
        }
      }

      Console.WriteLine("sum = " + sum);
    }
  }
}
