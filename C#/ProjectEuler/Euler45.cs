using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler45
  {
    public static void Go()
    {
      Console.WriteLine("Euler 45");
                   
      long limit = 10000000000;
//      List<long> tri = new List<long>();
//      HashSet<long> triHS;
      List<long> pent = new List<long>();
      HashSet<long> pentHS;

      //for (long i = 0; i < limit; i++)
      //{
      //  tri.Add(i*(i+ 1) / 2 );
      //  if (tri.Last() > limit)
      //  {
      //    break;
      //  }
      //}
      //triHS = new HashSet<long>(tri);

      for (long i = 0; i < limit; i++)
      {
        pent.Add(i * (3 * i - 1) / 2);
        if (pent.Last() > limit)
        {
          break;
        }
      }
      pentHS = new HashSet<long>(pent);

      for (long i = 0; i < limit; i++)
      {
        long val = i * (2 * i - 1);

//        if (triHS.Contains(val) && pentHS.Contains(val))
        if (pentHS.Contains(val))
        {
          Console.WriteLine(val);
        }

        if (val > limit)
        {
          break;
        }
      }



    }

  }
}
