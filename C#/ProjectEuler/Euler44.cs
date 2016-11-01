using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler44
  {
    public static void Go()
    {
      Console.WriteLine("Euler 44");


      const int limit = 10000;
      List<long> petagonList = new List<long>();

      for (long i = 1; i <= limit + 2; i++)
      {
        petagonList.Add((i * (3 * i - 1)) / 2);
      }

      HashSet<long> petagonHS = new HashSet<long>(petagonList);

      bool found = false;

      for (int i = 0; i < limit; i++)
      {
        if (found) {
          break;
        }

        for (int j = i - 1; j > 0; j--)
        {
          if (petagonHS.Contains(petagonList[j] + petagonList[i]) &&
              petagonHS.Contains(petagonList[i] - petagonList[j]))
          {
            Console.WriteLine("delta = " + (petagonList[i] - petagonList[j]));
            Console.WriteLine("v1 = " + petagonList[i]);
            Console.WriteLine("v2 = " + petagonList[j]);
            found = true;
          }
        }
      }

      if (!found) {
        Console.WriteLine("not found");
      }
    }

  }
}
