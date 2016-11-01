using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler92
  {
    public static void Go()
    {
      Console.WriteLine("Euler 92");

      int limit = 10000000;
      int[] map = new int[limit];
      map[1] = 1;
      map[89] = 89;

      for (int i = 1; i < limit; i++)
      {
        int walkValue = i;
        List<int> path = new List<int>();

        while (true)
        {
          path.Add(walkValue);

          if ((walkValue < limit) && (map[walkValue] != 0))
          {
            foreach (int p in path)
            {
              if (p < limit)
              {
                map[p] = map[walkValue];
              }
            }

            break;
          }

          int sum = 0;
          while (walkValue > 0)
          {
            sum += (walkValue % 10) * (walkValue % 10);
            walkValue = walkValue / 10;
          }
          walkValue = sum;
          //walkValue = walkValue.ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum(x => x * x);
        }
      }

      int count = 0;
      for (int i = 1; i < limit; i++)
      {
        if (map[i] == 89)
        {
          count++;
        }
      }
      
      Console.WriteLine("count " + count);
    }
  }
}
