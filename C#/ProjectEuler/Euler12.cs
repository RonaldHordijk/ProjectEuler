using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler12
	{
		private static int getNrDivisors(int value)
		{
			int count = 0;

			if (value <= 0) {
				return 0;
			}

			if (value == 1) {
				return 1;
			}

			int sqrtValue = (int) Math.Floor(Math.Sqrt(value));

			if (sqrtValue * sqrtValue == value)
			{
				count = 1;
				sqrtValue = sqrtValue - 1;
			}

			for (int i = 2; i <= sqrtValue; i++)
			{
				if ((value % i) == 0)
				{
					count += 2;
				}
			}

			// one and self
			count += 2;

			return count;
		}


		public static void Go()
		{
			Console.WriteLine("Euler 12");

			int triangle = 0;

			for (int i = 1; i < 100000; i++)
			{
				triangle += i;
				int nrDivisors = getNrDivisors(triangle);

				Console.WriteLine(i + " - " + triangle + " : " + nrDivisors);

				if (nrDivisors > 500)
				{
					break;
				}
			}
		}
	}
}
