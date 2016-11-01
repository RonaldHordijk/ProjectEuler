using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	class Euler48
	{
		public static void Go()
		{
			Console.WriteLine("Euler 48");

			BigInteger sum = new BigInteger(0);

			for (int i = 1; i <= 1000; i++)
			{
				sum += BigInteger.Pow(i, i);
			}

			Console.WriteLine("sum = " +sum);
		}


	}
}
