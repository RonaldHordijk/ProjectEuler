using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler119
  {

    private static int SumDigits(BigInteger v)
    {
      int sum = 0;
      while (v > 0)
      {
        sum += (int)(v % 10);
        v = v / 10;
      }

      return sum;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 119");

      List<BigInteger> solutions = new List<BigInteger>();

      long limit = 1000000000000000L;

      for (int power = 2; power < 65; power++)
      {
        for (int basev = 2; basev < 100000; basev++)
        {
          BigInteger v = BigInteger.Pow(basev,power);
          if (v> limit) {
            break;
          }

          if (SumDigits(v) == basev) {
            solutions.Add(v);
            Console.WriteLine(v);
          }
        }
      }

      solutions.Sort();
      Console.WriteLine("solutions");
      for(int i = 0; i <solutions.Count(); i++){
        Console.WriteLine(i + " - " + solutions[i]);
      }
    }
  }
}
