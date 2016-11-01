using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler19
	{
		public static void Go()
		{
			Console.WriteLine("Euler 18");

			int count = 0;

			for (int year = 1901; year <= 2000; year++)
			{
				for (int month = 0; month < 12; month++)
				{
					DateTime day = new DateTime(year, month + 1, 1);
					if (day.DayOfWeek == DayOfWeek.Sunday)
					{
						count++;
					}
				}
			}

			Console.WriteLine("Nr sunday = " + count);
		}

	}
}
