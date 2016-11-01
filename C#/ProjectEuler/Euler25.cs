using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	class Euler25
	{

		public static void Go()
		{
			Console.WriteLine("Euler 25");


			BigInteger[] fib = {BigInteger.Parse("1"), BigInteger.Parse("1")};			
			BigInteger limit = BigInteger.Pow(BigInteger.Parse("10"), 999);
			int count = 2;
			int last = 0;

//			while (count < 13)
	  	while (fib[last] < limit)
  		{
				last = 1 - last;
				fib[last] = fib[0] + fib[1];

				count++;

			}

			Console.WriteLine("The count is: " + count);
			Console.WriteLine("The last one is: " + fib[last]);

			Console.ReadKey();
		}
	}
}
