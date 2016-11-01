using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
  class Euler55
  {

    private static bool isPalidrome(string s)
    {
      for (int i = 0; i < (s.Length / 2); i++)
      {
        if (s[i] != s[s.Length - i - 1])
        {
          return false;
        }
      }

      return true;
    }

    private static bool isLychrelNumber(int value){
      BigInteger val = new BigInteger(value);


      for (int i = 0; i< 50; i++)
      {
        char[] cs = val.ToString().ToCharArray();
        Array.Reverse(cs);
        string reverse = new string(cs);

        val = val + BigInteger.Parse(reverse);

        if (isPalidrome(val.ToString())) {
          return false;
        }
      }

      return true;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 55");

      int Counter = 0;

      for (int i = 1; i <= 10000; i++)
      {
        if (isLychrelNumber(i))
        {
          Counter++;
          Console.WriteLine(i);
        }
      }

      Console.WriteLine("Nr Lychel numbers is " + Counter);
    }
  }
}
