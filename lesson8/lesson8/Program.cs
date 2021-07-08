using System;
using System.Collections.Generic;

namespace lesson8
{
    class Program
    {
        static void bucketSort(float[] arr, int n)
        {
            if (n <= 0)
                return;

            List<float>[] buckets = new List<float>[n];
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<float>();
            }
            for (int i = 0; i < n; i++)
            {
                float idx = arr[i] * n;
                buckets[(int)idx].Add(arr[i]);
            }
            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
            }
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[index++] = buckets[i][j];
                }
            }
        }
        public static void Main()
        {
            float[] arr = { (float)0.999, (float)0.565,
                   (float)0.656, (float)0.3234,
                   (float)0.665, (float)0.3434 };

            int n = arr.Length;
            bucketSort(arr, n);

            Console.WriteLine("Сортированный массив: ");
            foreach (float el in arr)
            {
                Console.Write(el + " ");
            }
        }
    }
}
