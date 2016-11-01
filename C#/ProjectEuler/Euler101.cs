using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler101
  {
    public static void Go()
    {
      Console.WriteLine("Euler 101");

      for (long i = 1; i < 12; i++)
      {
        long value = 1 - i + i * i - (long)Math.Pow(i, 3) + (long)Math.Pow(i, 4) - (long)Math.Pow(i, 5) + (long)Math.Pow(i, 6) - (long)Math.Pow(i, 7) + (long)Math.Pow(i, 8) - (long)Math.Pow(i, 9) + (long)Math.Pow(i, 10);
        Console.WriteLine(i+ " - " + value);
      }

      long sum = 1;
      Console.WriteLine(1 + " - " + 1);
      //682 x-681
      long v = 682 * 3 - 681;
      sum += v;
      Console.WriteLine(2 + " - " + v);
      //21461 x^2-63701 x+42241
      v = 21461 * 16 - 63701 * 4 + 42241;
      sum += v;
      Console.WriteLine(3 + " - " + v);
      //118008 x^3-686587 x^2+1234387 x-665807
      v = 118008 * (long)Math.Pow(5, 3) - 686587 * 25 + 1234387 * 5 - 665807;
      sum += v;
      Console.WriteLine(4 + " - " + v);
      //210232 x^4-1984312 x^3+6671533 x^2-9277213 x+4379761
      v = 210232 * (long)Math.Pow(6, 4) - 1984312 * (long)Math.Pow(6, 3) + 6671533 * 36 - 9277213 * 6 + 4379761;
      sum += v;
      Console.WriteLine(5 + " - " + v);
      sum += 205015603;
      Console.WriteLine(6 + " - " + 205015603);
      sum += 898165577;
      Console.WriteLine(7 + " - " + 898165577);
      sum += 3093310441;
      Console.WriteLine(8 + " - " + 3093310441);
      sum += 9071313571;
      Console.WriteLine(9 + " - " + 9071313571);
      sum += 23772343751;
      Console.WriteLine(10 + " - " + 23772343751);

      Console.WriteLine("sum - " + sum);
    }

  }
}
