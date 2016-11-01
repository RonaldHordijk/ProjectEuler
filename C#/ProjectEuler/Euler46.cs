using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler46
  {
    private static HashSet<int> doubleSquares = new HashSet<int>();
    private static int limit = 10000;
		private static List<int> primes = new List<int>();

		static void BuildPrimes(int maxValue)
		{
			bool[] map = new bool[maxValue];

			for (int i = 0; i < maxValue; i++)
			{
				map[i] = true;
			}

			for (int i = 2; i < maxValue; i++)
			{
				if (map[i] == true)
				{
					primes.Add(i);

					int wipe = i * 2;
					while (wipe < maxValue)
					{
						map[wipe] = false;
						wipe += i;
					}
				}
			}
		}

    private static void BuildDoubleSquares() {
      for (int i = 0; i< Math.Sqrt(limit); i++) 
      {
        doubleSquares.Add(2 * i * i);
      }
    }
    
    public static void Go()
    {
      Console.WriteLine("Euler 46");

      BuildDoubleSquares();
      BuildPrimes(limit);
      primes.RemoveAt(0); // remove the 2

      HashSet<int> primesHS = new HashSet<int>(primes);

      for (int i = 3; i < limit; i += 2)
      {
        bool found = false;

        if (primesHS.Contains(i))
        {
          continue;
        }

        foreach( int p in primes) {
          if (p >= i) {
            break;
          }

          if (doubleSquares.Contains(i - p)) {
            found = true;
            break;
          }
        }

        if (!found) {
          Console.WriteLine("not found " + i);
        }
      }

      Console.WriteLine("finished");

    }
  }
}
