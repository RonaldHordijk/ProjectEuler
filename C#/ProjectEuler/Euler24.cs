using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class Euler24
	{
		private static int bufsize = 10;
		private static Stack<int>[] buffer = new Stack<int>[bufsize];

		private static void FillBuffer(int start)
		{
			for (int i = start; i < bufsize; i++)
			{
				for (int possibleNum = bufsize - 1; possibleNum >= 0; possibleNum--) {
					// test used
					bool used = false;
					for (int j = 0; j < i; j++)
					{
						if (possibleNum == buffer[j].Peek())
						{
							used = true;
							break;
						}
					}

					if (!used)
					{
						buffer[i].Push(possibleNum);
					}
				}
			}
		}

		private static bool NextStep()
		{
			int start = bufsize - 1;

			while ((start >= 0) && (buffer[start].Count == 1))
			{
				buffer[start].Pop();
				start--;
			}

			if (start < 0)
			{
				//done
				return false;
			}

			buffer[start].Pop();

			FillBuffer(start + 1);

			return true;
		}

		private static void PrintBuffer()
		{
			for (int i = 0; i < bufsize; i++)
			{
				Console.Write(buffer[i].Peek());
			}

			Console.WriteLine();
		}


		public static void Go()
		{
			Console.WriteLine("Euler 22");

			for (int i = 0; i < bufsize; i++)
			{
				buffer[i] = new Stack<int>();
			}


			FillBuffer(0);

      int count = 1;
			while (NextStep())
			{
				count++;
				if (count == 1000000)
				{
					PrintBuffer();
				}
				if (count == 1000001)
				{
					PrintBuffer();
					break;
				}
				if (count == 999999)
				{
					PrintBuffer();
				}
			}



		}
	}
}
