using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	 
	class Euler15
	{
		private static BigInteger factorial(int value)
		{
			BigInteger res = 1;
			for (int i = 2; i <= value; i++)
			{
				res *=  i;
			}

			return res;
  	}

		public static void Go()
		{
			Console.WriteLine("Euler 15");

			// 40!/(20!*20!)

			BigInteger fac20 = factorial(20);
			Console.WriteLine("res = " + factorial(40) / (fac20 * fac20));
		}
	}
}
