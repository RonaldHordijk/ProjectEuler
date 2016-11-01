using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler43
  {
    private static int bufsize = 10;
    private static Stack<int>[] buffer = new Stack<int>[bufsize];

    private static int Test()
    {
      int num = 100 * buffer[2].Peek() + 10 * buffer[1].Peek() + buffer[0].Peek();

      if (num % 17 != 0)
      {
        return 2;
      }

      num = 100 * buffer[3].Peek() + 10 * buffer[2].Peek() + buffer[1].Peek();

      if (num % 13 != 0)
      {
        return 3;
      }

      num = 100 * buffer[4].Peek() + 10 * buffer[3].Peek() + buffer[2].Peek();

      if (num % 11 != 0)
      {
        return 4;
      }

      num = 100 * buffer[5].Peek() + 10 * buffer[4].Peek() + buffer[3].Peek();

      if (num % 7 != 0)
      {
        return 5;
      }

      num = 100 * buffer[6].Peek() + 10 * buffer[5].Peek() + buffer[4].Peek();

      if (num % 5 != 0)
      {
        return 6;
      }

      num = 100 * buffer[7].Peek() + 10 * buffer[6].Peek() + buffer[5].Peek();

      if (num % 3 != 0)
      {
        return 7;
      }

      num = 100 * buffer[8].Peek() + 10 * buffer[7].Peek() + buffer[6].Peek();

      if (num % 2 != 0)
      {
        return 8;
      }

      return -1;
    }

    private static void FillBuffer(int start)
    {
      for (int i = start; i < bufsize; i++)
      {
        for (int possibleNum = bufsize - 1; possibleNum >= 0; possibleNum--)
        {
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

    private static bool NextStep(int start)
    {
      //int start = bufsize - 1;

      for (int i = start + 1; i < bufsize; i++)
      {
        buffer[i].Clear();
      }

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
      for (int i = bufsize - 1; i>=0 ; i--)
      {
        Console.Write(buffer[i].Peek());
      }

      Console.WriteLine();
    }

    public static void Go()
    {
      Console.WriteLine("Euler 43");

      for (int i = 0; i < bufsize; i++)
      {
        buffer[i] = new Stack<int>();
      }

      FillBuffer(0);

      int errorPos = 0;
      long sum = 0;
      do
      {
        errorPos = Test();

//        PrintBuffer();
//        Console.WriteLine(errorPos);
        if (errorPos == -1)
        {
          PrintBuffer();
          string s = "";
          for (int i = bufsize - 1; i >= 0; i--)
          {
            s = s + buffer[i].Peek().ToString();
          }
          sum += Int64.Parse(s);


          errorPos = bufsize - 1;
        }

      } while (NextStep(errorPos));

      Console.WriteLine("sum : " + sum);
    }
  }
}
