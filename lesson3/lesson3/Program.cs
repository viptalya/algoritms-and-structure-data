using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson3
{
    public class BechmarkClass
    {
        public class PointClass
        {
            public int X;
            public int Y;
        }

        public struct PointStruct
        {
            public int X;
            public int Y;
        }

        //  Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа
        //  float).
        public static float PointDistanceClassFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //  Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа
        //  float).
        public static float PointDistanceStructFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //  Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа
        //  bouble).
        public static double PointDistanceStructDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        //  Метод расчёта дистанции без корня со значимым типом (PointStruct — координаты типа
        //  bouble).
        public static float PointDistanceStructNotSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestPointDistanceClassFloat()
        {
            PointDistanceClassFloat(new PointClass { X = 1, Y = 2 }, new PointClass { X = 8, Y = 9 });
        }
        [Benchmark]
        public void TestPointDistanceStructFloat()
        {
            PointDistanceStructFloat(new PointStruct { X = 1, Y = 2 }, new PointStruct { X = 8, Y = 9 });
        }
        [Benchmark]
        public void TestPointDistanceStructDouble()
        {
            PointDistanceStructDouble(new PointStruct { X = 1, Y = 2 }, new PointStruct { X = 8, Y = 9 });
        }
        [Benchmark]
        public void TestPointDistanceStructNotSqrt()
        {
            PointDistanceStructNotSqrt(new PointStruct { X = 1, Y = 2 }, new PointStruct { X = 8, Y = 9 });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
