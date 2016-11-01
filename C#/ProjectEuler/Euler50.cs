using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler50
	{
		private static List<int> primes = new List<int>();
		private static int Limit = 1000000;

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

		public static void Go()
		{
			Console.WriteLine("Euler 50");

			BuildPrimes(Limit);

			int maxSequence = 0;
			int prime = 0;
			int start = 0;
			int end = 0;

			for (int i = primes.Count - 1; i >= 0; i--)
			{
				int sum = primes[i];

				int j = i;

				while ((sum < Limit) && (j > 0))
				{

					if ((i - j) > maxSequence)
					{
						if (primes.IndexOf(sum) >= 0)
						{
							maxSequence = i - j;
							prime = sum;
							start = primes[j];
							end = primes[i];
						}
					}
					
					j--;
					sum += primes[j];

				}
			}

			Console.WriteLine("Highest seq : " + maxSequence  + 1);
			Console.WriteLine("Value : " + prime + " [" + start + " - " + end + "]");
		}
	}
}
