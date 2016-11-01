using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler206
  {
    public static void Go()
    {
      Console.WriteLine("Euler 206");

      for (int i = 1010101010; i<1389026624;i+= 10){
        BigInteger sqr = BigInteger.Pow(i, 2);
        string s = sqr.ToString();

        if ((s[0] == '1') && (s[2] == '2') && (s[4] == '3') &&
          (s[6] == '4') && (s[8] == '5') && (s[10] == '6') &&
          (s[12] == '7') && (s[14] == '8') && (s[16] == '9') && (s[18] == '0'))
        {
          Console.WriteLine("found " + i);
          break;
        }

      }
      Console.WriteLine("done");


    }
  }
}
