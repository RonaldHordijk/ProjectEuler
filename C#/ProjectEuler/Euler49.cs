using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
  class Euler49
  {

    private static List<int> primes = new List<int>();

    static void BuildPrimes(int maxValue)
    {
      bool[] map = new bool[maxValue];

      for (int i = 0; i < maxValue; i++)
      {
        map[i] = true;
      }

      for (int i = 2; i < maxValue; i++)
      {
        if (map[i] == true)
        {
          primes.Add(i);

          int wipe = i * 2;
          while (wipe < maxValue)
          {
            map[wipe] = false;
            wipe += i;
          }
        }
      }
    }

    private static string[] perm4 = {
"0132",
"0213",
"0231",
"0312",
"0321",
"1023",
"1032",
"1203",
"1230",
"1302",
"1320",
"2013",
"2031",
"2103",
"2130",
"2301",
"2310",
"3012",
"3021",
"3102",
"3120",
"3201",
"3210"};

    private static List<int> getPermValues(int value)
    {

      List<int> result = new List<int>();
      string valueString = value.ToString();

      foreach (string perm in perm4)
      {
        char[] chars = perm.ToCharArray();

        int permvalue = 0;

        foreach(char c in perm.ToCharArray()){
          permvalue *= 10;
          permvalue += Int32.Parse(valueString[Int32.Parse(c.ToString())].ToString());
        }

        if ((permvalue >= value))
        {
          if (!result.Contains(permvalue))
          {
            result.Add(permvalue);
          }
        }
      }

      return result;
    }

    public static void Go()
    {
      Console.WriteLine("Euler 49");

      BuildPrimes(9999);

      HashSet<int> tp = new HashSet<int>(primes.Where(x => x > 1000)); 
      
      foreach (int value in tp) {
        List<int> perms = getPermValues(value);
        perms.Sort();
        perms = new List<int>(perms.Where(x => tp.Contains(x)));

        for (int i = 0; i < perms.Count - 2; i++)
        {
          for (int j = i + 1; j < perms.Count - 1; j++)
          {
            int lastone = perms[j] + (perms[j] - perms[i]);
            if (perms.Contains(lastone)) {
              Console.WriteLine ("found them " +  perms[i] + ',' + perms[j]  + ',' + lastone);
            }
          }
        }
        
      }
    }
  }

}
