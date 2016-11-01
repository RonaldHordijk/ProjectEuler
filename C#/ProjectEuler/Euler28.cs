using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler28
	{
		public static void Go()
		{
			Console.WriteLine("Euler 28");
	
			int squaresize = 1001;
			int sum = 1;
			int current = 1;
			int step = 2;
			for (int i = 0 ; i< (squaresize /2) ; i++) {
				current += step;
				sum += current;
				current += step;
				sum += current;
				current += step;
				sum += current;
				current += step;
				sum += current;
				step += 2;
			}

			Console.WriteLine("sum = " + sum);
		}
	}
}
