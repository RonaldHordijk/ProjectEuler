using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler21
	{
		private static int getSumDividers(int value) {
			int sum = 1;

			if (value <= 0)
			{
				return 0;
			}

			if (value == 1)
			{
				return 1;
			}

			int sqrtValue = (int)Math.Floor(Math.Sqrt(value));

			if (sqrtValue * sqrtValue == value)
			{
				sum = sqrtValue;
				sqrtValue = sqrtValue - 1;
			}

			for (int i = 2; i <= sqrtValue; i++)
			{
				if ((value % i) == 0)
				{
					sum += i;
					sum += (value / i);
				}
			}

			return sum;
		}

		public static void Go()
		{
			Console.WriteLine("Euler 21");

			int[] sums = new int[10000];

			for (int i = 1; i < 10000; i++)
			{
				if (i == 220)
				{
					Console.WriteLine(getSumDividers(i));
				}

				sums[i] = getSumDividers(i);
			}

			int sum = 0;
			for (int i = 1; i < 10000; i++)
			{
				if ((sums[i]> i) && (sums[i] < 10000) && (sums[sums[i]] == i)) {
					sum += i;
					sum += sums[i];
					Console.WriteLine("set " + i + " - " + sums[i]);
				}
			}

			Console.WriteLine("sum =  " + sum);

		}

	}
}
