using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	class Euler20
	{
		private static BigInteger factorial(int value)
		{
			BigInteger res = 1;
			for (int i = 2; i <= value; i++)
			{
				res *= i;
			}

			return res;
		}

		public static void Go()
		{
			Console.WriteLine("Euler 20");

			BigInteger fac100 = factorial(100);
			Console.WriteLine("fac100 = " + fac100);
			Console.WriteLine("sum = " + fac100.ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum());
		}

	}
}
