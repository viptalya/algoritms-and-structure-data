using System;
using System.Collections.Generic;

namespace lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string exit = "";
            int vert;
            while (true)
            {
                Console.WriteLine("Введите размер дерева:");
                vert = Convert.ToInt32(Console.ReadLine()) - 1;
                if (vert < 3)
                {
                    Console.WriteLine("Вы ввели некорректный размер. Программа автоматически заменила размер.");
                    vert = rand.Next(3, 6);
                }
                bool[] used = new bool[vert + 1];
                int[][] g = new int[vert + 1][];

                for (int i = 0; i < vert + 1; i++)
                {
                    g[i] = new int[vert + 1];
                    Console.Write("\n({0}) вершина -->[", i + 1);
                    for (int j = 0; j < vert + 1; j++)
                    {
                        g[i][j] = rand.Next(0, 2);
                    }
                    g[i][i] = 0;
                    foreach (var item in g[i])
                    {
                        Console.Write(" {0}", item);
                    }
                    Console.Write("]\n");

                }
                used[vert] = true;
                Console.WriteLine("Введите DFS если хотите выполнить поиск в глубину \nВведите BFS если хотите выполнить поиск в ширину");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "BFS":
                        Queue<int> q = new Queue<int>();
                        q.Enqueue(vert);
                        Console.WriteLine("Начинаем обход с {0} вершины", vert + 1);
                        while (q.Count != 0)
                        {
                            vert = q.Peek();
                            q.Dequeue();
                            Console.WriteLine("Перешли к узлу {0}", vert + 1);

                            for (int i = 0; i < g.Length; i++)
                            {
                                if (Convert.ToBoolean(g[vert][i]))
                                {
                                    if (!used[i])
                                    {
                                        used[i] = true;
                                        q.Enqueue(i);
                                        Console.WriteLine("Добавили в очередь узел {0}", i + 1);
                                    }
                                }
                            }
                        }
                        break;
                    case "DFS":
                        Stack<int> s = new Stack<int>();
                        s.Push(vert);
                        Console.WriteLine("Начинаем обход с {0} вершины", vert + 1);
                        while (s.Count != 0)
                        {
                            vert = s.Peek();
                            s.Pop();
                            Console.WriteLine("Перешли к узлу {0}", vert + 1);
                            for (int i = 0; i < g.Length; i++)
                            {
                                if (Convert.ToBoolean(g[vert][i]))
                                {
                                    if (!used[i])
                                    {
                                        used[i] = true;
                                        s.Push(i);
                                        Console.WriteLine("Добавили в стек узел {0}", i + 1);
                                    }
                                }
                            }
                        }
                        break;
                }
                Console.WriteLine("Завершить программу?");
                exit = Console.ReadLine();
                if (exit == "нет" || exit == "ytn" || exit == "YTN" || exit == "НЕТ")
                    Console.Clear();
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
