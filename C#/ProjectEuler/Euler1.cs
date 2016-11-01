using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler1
	{
		private const int MaxNumber = 1000;

		static bool IsValid(int value)
		{
			bool canDividBy3 = ((value % 3) == 0);
			bool canDividBy5 = ((value % 5) == 0);

			return (canDividBy3 || canDividBy5);
		}

		static void Counting()
		{
			int sum = 0;
			for (int i = 1; i < MaxNumber; i++)
			{
				if (IsValid(i))
				{
					//					Console.WriteLine(i);

					sum += i;
				}
			}

			Console.WriteLine("The sum is: " + sum);
		}

		static int SumValuesDividedBy(int divider)
		{
			int nrValues = (MaxNumber - 1) / divider;

			return (divider * nrValues * (nrValues + 1)) / 2;
		}

		static void Calc()
		{
			int sum = SumValuesDividedBy(3) + SumValuesDividedBy(5) - SumValuesDividedBy(15);

			Console.WriteLine("The sum is: " + sum);
		}

		public static void Go()
		{
			Console.WriteLine("Euler 1");
			Counting();
			Calc();
		}

	}
}
