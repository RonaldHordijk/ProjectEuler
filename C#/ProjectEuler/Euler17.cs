using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler17
	{

		static private string EnglishValue(int value)
		{
			string[] undertwenty = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			string[] tens = {"zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

			if (value < 20)
			{
				return undertwenty[value];
			}

			if (value < 100) {
				if (value % 10 == 0)
				{
					return tens[value / 10];
				}
				else
				{
					return tens[value / 10] + EnglishValue(value % 10);
				}
			}

			if (value < 1000)
			{
				if (value % 100 == 0)
				{
					return EnglishValue(value / 100) + "hundred";
				}
				else
				{
					return EnglishValue(value / 100) + "hundredand" + EnglishValue(value % 100);
				}
			}

			if (value % 1000 == 0)
			{
				return EnglishValue(value / 1000) + "thousand";
			}
			else
			{
				return EnglishValue(value / 1000) + "thousandand" + EnglishValue(value % 1000);
			}
		}


		public static void Go()
		{
			Console.WriteLine("Euler 17");

			int sum = 0;

			for (int i = 1; i <= 1000; i++)
			{
				sum += EnglishValue(i).Length;
			}

			Console.WriteLine("342: " + EnglishValue(342));
			Console.WriteLine("115: " + EnglishValue(115));
			Console.WriteLine("sum: " + sum);

		}
	}
}
