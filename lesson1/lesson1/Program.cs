using System;
using System.Linq;
using System.Collections.Generic;

namespace lesson1
{
    class Program
    {
        /*
        1. Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм
        проверки, простое число или нет.
        */
        public static int easyNum(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            if (d == 0)
            {
                Console.WriteLine($"Число {n} простое");
            }
            else
            {
                Console.WriteLine($"Число {n} не простое");
            }
            return n;
        }
        //для теста первого задания
        public class testCaseEasy
        {
            public int n { get; set; }
            public int Expected { get; set; }
            public Exception exception { get; set; }
        }
        static void testEasy (testCaseEasy TCE)
        {
            try
            {
                var actual = easyNum(TCE.n);
                if (actual == TCE.Expected)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
            catch (Exception ex)
            {
                if (TCE.exception != null)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
        }

        /*
        2. Посчитайте сложность функции
        public static int  StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) //О(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //О(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //О(N)
                    {
                        int y = 0; //O(1)

                        if (j != 0) // O(N + 1)
                        {
                            y = k / j; //O(2)
                        }

                        sum += inputArray[i] + i + k + j + y; //O(5)
                    }
                }
            }

            return sum; //O(1)
        }
        Сложность: 9 + (N+1) + N^3
        */

        /*
        3. Реализуйте функцию вычисления числа Фибоначчи рекурсией и циклом
        */
        //рекурсия Фибоначчи
        public static int recFib(int F)
        {
            if (F == 0)
            {
                return 0;
            }
            else if (F == 1)
            {
                return 1;
            }
            else
            {
                return recFib(F - 1) + recFib(F - 2);
            }
        }
        //проверка для рекурсии Фибоначчи
        public class testCaseRecFib
        {
            public int F { get; set; }
            public int Result { get; set; }
            public Exception ex { get; set; }
        }
        static void testRecFib(testCaseRecFib TCRF)
        {
            try
            {
                var actual = recFib(TCRF.F);
                if (actual == TCRF.Result)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
            catch (Exception ex)
            {
                if (TCRF.ex != null)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
        }
        //цикл Фибоначчи
        static int cycleFib(int F)
        {
            int f0, f1;
            int fsum = 0;
            f0 = 0;
            f1 = 1;
            if (F == 0)
            {
                return 0;
            }
            else if (F == 1)
            {
                return 1;
            }
            for(int i = 1; i < F; i++)
            {
                fsum = f0 + f1;
                f0 = f1;
                f1 = fsum;
            }
            return fsum;
        }
        //проверка для цикла
        public class testCaseCycleFib
        {
            public int Fib { get; set; }
            public int Res { get; set; }
            public Exception Ex { get; set; }
        }
        static void testCycleFib(testCaseCycleFib TCCF)
        {
            try
            {
                var actual = recFib(TCCF.Fib);
                if (actual == TCCF.Res)
                {
                    Console.WriteLine("Valid test");
                }
                else
                {
                    Console.WriteLine("Invalid test");
                }
            }
            catch (Exception ex)
            {
                if (TCCF.Ex != null)
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
            //данные для теста первого задания
            Console.WriteLine("Введите первое число n");
            int newN1 = Convert.ToInt32(Console.ReadLine());
            var testCase1 = new testCaseEasy()
            {
                n = newN1,
                Expected = newN1,
                exception = null
            };
            Console.WriteLine("Введите второе число n");
            int newN2 = Convert.ToInt32(Console.ReadLine());
            var testCase2 = new testCaseEasy()
            {
                n = newN2,
                Expected = newN2,
                exception = null
            };
            Console.WriteLine("Введите третье число n");
            int newN3 = Convert.ToInt32(Console.ReadLine());
            var testCase3 = new testCaseEasy()
            {
                n = newN3,
                Expected = newN3,
                exception = null
            };
            var testCase4 = new testCaseEasy()
            {
                n = -2,
                Expected = 2,
                exception = null
            };
            var testCase5 = new testCaseEasy()
            {
                n = -11,
                Expected = 11,
                exception = null
            };
            testEasy(testCase1);
            testEasy(testCase2);
            testEasy(testCase3);
            testEasy(testCase4);
            testEasy(testCase5);
            //данные для теста рекурсии Фибоначчи
            Console.WriteLine("Введите первое число Фибоначчи");
            int newF1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newF1} Фибоначчи равно {recFib(newF1)}");
            var testCaseRecFib = new testCaseRecFib()
            {
                F = newF1,
                Result = recFib(newF1),
                ex = null
            };
            testRecFib(testCaseRecFib);
            Console.WriteLine("Введите второе число Фибоначчи");
            int newF2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newF2} Фибоначчи равно {recFib(newF2)}");
            var testCaseRecFib2 = new testCaseRecFib()
            {
                F = newF2,
                Result = recFib(newF2),
                ex = null
            };
            testRecFib(testCaseRecFib2);
            Console.WriteLine("Введите третье число Фибоначчи");
            int newF3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newF3} Фибоначчи равно {recFib(newF3)}");
            var testCaseRecFib3 = new testCaseRecFib()
            {
                F = newF3,
                Result = recFib(newF3),
                ex = null
            };
            testRecFib(testCaseRecFib3);
            int newF4 = 5;
            Console.WriteLine($"Для числа {newF4} Фибоначчи равно {recFib(newF4)}");
            var testCaseRecFib4 = new testCaseRecFib()
            {
                F = newF4,
                Result = 1,
                ex = null
            };
            testRecFib(testCaseRecFib4);
            int newF5 = 1;
            Console.WriteLine($"Для числа {newF5} Фибоначчи равно {recFib(newF5)}");
            var testCaseRecFib5 = new testCaseRecFib()
            {
                F = newF5,
                Result = 2,
                ex = null
            };
            testRecFib(testCaseRecFib5);
            //данные для вычисления Фибоначчи циклом
            Console.WriteLine("Введите первое число для вычисления Фибоначчи циклом");
            int newFC1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newFC1} Фибоначчи равно {cycleFib(newFC1)}");
            var testCaseCycleFib1 = new testCaseCycleFib()
            {
                Fib = newFC1,
                Res = cycleFib(newFC1),
                Ex = null
            };
            testCycleFib(testCaseCycleFib1);
            Console.WriteLine("Введите второе число для вычисления Фибоначчи циклом");
            int newFC2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newFC2} Фибоначчи равно {cycleFib(newFC2)}");
            var testCaseCycleFib2 = new testCaseCycleFib()
            {
                Fib = newFC2,
                Res = cycleFib(newFC2),
                Ex = null
            };
            testCycleFib(testCaseCycleFib2);
            Console.WriteLine("Введите третье число для вычисления Фибоначчи циклом");
            int newFC3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Для числа {newFC3} Фибоначчи равно {cycleFib(newFC3)}");
            var testCaseCycleFib3 = new testCaseCycleFib()
            {
                Fib = newFC3,
                Res = cycleFib(newFC3),
                Ex = null
            };
            testCycleFib(testCaseCycleFib3);
            int newFC4 = 7;
            Console.WriteLine($"Для числа {newFC4} Фибоначчи равно {cycleFib(newFC4)}");
            var testCaseCycleFib4 = new testCaseCycleFib()
            {
                Fib = newFC4,
                Res = 2,
                Ex = null
            };
            testCycleFib(testCaseCycleFib4);
            int newFC5 = 8;
            Console.WriteLine($"Для числа {newFC5} Фибоначчи равно {cycleFib(newFC5)}");
            var testCaseCycleFib5 = new testCaseCycleFib()
            {
                Fib = newFC5,
                Res = 2,
                Ex = null
            };
            testCycleFib(testCaseCycleFib5);
        } 

    }
}
