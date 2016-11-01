using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler16
  {
    public static void Go()
    {
      Console.WriteLine("Euler 16");

      BigInteger powBase = new BigInteger(2);
      BigInteger bigValue = BigInteger.Pow(powBase, 1000);

      string s = bigValue.ToString();
      int sum = 0;

      for (int i = 0; i < s.Length; i++)
      {
        sum += Convert.ToInt32(s[i].ToString());
      }

      Console.WriteLine("value  = " + bigValue);
      Console.WriteLine("sum  = " + sum);

    }
  }
}
