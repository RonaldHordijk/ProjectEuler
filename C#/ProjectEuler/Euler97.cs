using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	class Euler97
	{
		public static void Go()
		{
			Console.WriteLine("Euler 97");

			long value = 1;

			for (int i = 0; i < 7830457; i++)
			{
				value *= 2;
				value = value % 10000000000;
			}

			value *= 28433;
			value += 1;

			Console.WriteLine("value = " + value);

//			BigInteger res = BigInteger.Pow(2, 7830457) * 28433 + 1;
//			Console.WriteLine("value = " + res);
		}
	}
}
