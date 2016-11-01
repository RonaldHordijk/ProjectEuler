using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler29
  {
    private static HashSet<BigInteger> allvalues = new HashSet<BigInteger>();
    
    public static void Go()
    {
      Console.WriteLine("Euler 29");

      for(int a = 2; a<=100;a++){
        for(int b = 2; b<=100;b++){
          BigInteger val = BigInteger.Pow(a,b);

          if (!allvalues.Contains(val))
          {
            allvalues.Add(val);
          }

        }

      }

      Console.WriteLine("NrItems = " + allvalues.Count);
    }
  }
}
