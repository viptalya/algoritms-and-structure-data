using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lesson4._1
{
    public class RandStr
    {
        public string Str;

        public RandStr()
        {
            Random random = new Random();
            int NumLetters = 10;
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 1; i < NumLetters; i++)
            {
                int LetterNum = random.Next(0, letters.Length - 1);
                Str += letters[LetterNum];
            }
        }
    }
    class Program
    {
        private static bool SearchElement(string[] arr, string str)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == str)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string[] arr = new string[10000];
            HashSet<string> hs = new HashSet<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                string str = new RandStr().Str;
                if (!hs.Contains(str))
                {
                    hs.Add(str);
                    arr[i] = str;
                }
                else
                {
                    i--;
                }
            }
            string StringSearch = arr[9999];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SearchElement(arr, StringSearch);
            stopwatch.Start();
            Console.WriteLine($"Время замера проверки строки в массиве: {stopwatch.Elapsed.TotalMilliseconds}");
            stopwatch.Reset();
            stopwatch.Start();
            hs.Contains(StringSearch);
            stopwatch.Start();
            Console.WriteLine($"Время замера проверки строки в HashSet: {stopwatch.Elapsed.TotalMilliseconds}");
        }
    }
}
