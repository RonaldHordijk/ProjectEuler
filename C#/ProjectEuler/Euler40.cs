using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler40
  {
    public static void Go()
    {
      Console.WriteLine("Euler 40");
      
      StringBuilder sb = new StringBuilder(120000);

      int i = 1;
      while (sb.Length < 1000000) {
        sb.Append(i.ToString());
        i++;
      }

      int p = Int32.Parse(sb[1 - 1].ToString()) * 
        Int32.Parse(sb[10 - 1].ToString()) *
        Int32.Parse(sb[100 - 1].ToString()) *
        Int32.Parse(sb[1000 - 1].ToString()) *
        Int32.Parse(sb[10000 - 1].ToString()) *
        Int32.Parse(sb[100000 - 1].ToString()) *
        Int32.Parse(sb[1000000 - 1].ToString());

      Console.WriteLine("product is :" + p);

    }
  }
}
