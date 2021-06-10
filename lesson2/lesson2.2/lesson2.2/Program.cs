using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson2._2
{
    //2. Двоичный поиск
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0; //о(1)
            int max = inputArray.Length - 1; //о(1)
            while (min <= max) //о(2n^2)
            {
                int mid = (min + max) / 2; //o(1)
                if (searchValue == inputArray[mid]) //о(2n)
                {
                    return mid; //o(1)
                }
                else if (searchValue < inputArray[mid]) //о(2n)
                {
                    max = mid - 1; //o(1)
                }
                else
                {
                    min = mid + 1; //o(1)
                }
            }
            return -1; //o(1)
        }
        //Сложность: O(6) + O(N^2) + O(4N) 
        public class TestCase
        {
            public int x { get; set; }
            public int res { get; set; }
            public Exception exception { get; set; }
        }

        static void TestSearch(TestCase testCase)
        {
            try
            {
                int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var actual = BinarySearch(arr, testCase.x);
                if (actual == testCase.res)
                {
                    Console.WriteLine($"Значение: {testCase.x}, " +
                        $"номер: {actual}");
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine($"Значение: {testCase.x}, " +
                        $"номер: {actual}");
                    Console.WriteLine("Invalid test");
                }
            }
            catch (Exception ex)
            {
                if (testCase.exception != null)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
        }
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                x = 6,
                res = 5,
                exception = null
            };
            TestSearch(testCase1);
            var testCase2 = new TestCase()
            {
                x = 1,
                res = 0,
                exception = null
            };
            TestSearch(testCase2);
            var testCase3 = new TestCase()
            {
                x = 9,
                res = 8,
                exception = null
            };
            TestSearch(testCase3);
            var testCase4 = new TestCase()
            {
                x = 5,
                res = 3,
                exception = null
            };
            TestSearch(testCase4);
            var testCase5 = new TestCase()
            {
                x = 3,
                res = 5,
                exception = null
            };
            TestSearch(testCase5);
        }
    }
}
