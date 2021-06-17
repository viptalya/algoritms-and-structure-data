using System;
using System.Collections.Generic;

namespace lesson4._2
{
    class Tree
    {
        public int value = 0;
        public Tree LeftChild = null;
        public Tree RightChild = null;
        public Tree parent = null;
        public Tree() { }
        Tree(int value, Tree parent)
        {
            this.value = value;
            this.parent = parent;
        }
        public bool AddItem(int value)

        {
            if (this.value == 0)
            {
                this.value = value;
                LeftChild = null;
                RightChild = null;
                return true;
            }
            else if (value < this.value)
            {
                if (LeftChild == null)
                {
                    LeftChild = new Tree(value, this);
                    return true;
                }
                else return LeftChild.AddItem(value);
            }
            else if (value > this.value)
            {
                if (RightChild == null)
                {
                    RightChild = new Tree(value, this);
                    return true;
                }
                else return RightChild.AddItem(value);
            }
            else return false;
        }
        public Tree GetByValue(int value)
        {
            if (value < this.value && LeftChild != null)
            {
                return LeftChild.GetByValue(value);
            }
            else if (value > this.value && RightChild != null)
            {
                return RightChild.GetByValue(value);
            }
            else if (value == this.value) return this;
            else return null;
        }
        public void RemoveItem(Tree branch, int value)
        {
            Tree forDelete = branch.GetByValue(value);
            Tree newBranch;
            Queue<Tree> queue = new Queue<Tree>();
            if (forDelete.LeftChild != null) queue.Enqueue(forDelete.LeftChild);
            if (forDelete.RightChild != null) queue.Enqueue(forDelete.RightChild);
            if (forDelete.parent == null)
            {
                newBranch = this;
                newBranch.LeftChild = null;
                newBranch.RightChild = null;
                newBranch.value = 0;
            }
            else
            {
                newBranch = forDelete.parent;
                if (newBranch.LeftChild == forDelete) newBranch.LeftChild = null;
                else newBranch.RightChild = null;
            }

            while (queue.Count != 0)
            {
                Tree oldBranch = queue.Dequeue();
                newBranch.AddItem(oldBranch.value);
                if (oldBranch.LeftChild != null) queue.Enqueue(oldBranch.LeftChild);
                if (oldBranch.RightChild != null) queue.Enqueue(oldBranch.RightChild);
            }
        }
    }

    class Program
    {
        public static void PrintTree(Tree tree)
        {
            Console.Clear();
            List<List<string>> toDisplay = new List<List<string>>();
            {
                List<Tree> lineTree = new List<Tree> { tree };
                bool exit = false;
                while (!exit)
                {
                    List<Tree> lineTreeTmp = new List<Tree>();
                    List<string> toDisplayTmp = new List<string>();
                    List<string> lineTmp = new List<string>();
                    exit = true;
                    for (int i = 0; i < lineTree.Count; i++)
                    {
                        int print = 0;
                        Tree left = null;
                        Tree right = null;
                        string line = "0";
                        if (lineTree[i] != null)
                        {
                            print = lineTree[i].value;
                            if (lineTree[i].parent != null && lineTree[i].value < lineTree[i].parent.value) line = "/";
                            else if (lineTree[i].parent != null) line = "\\";
                            left = lineTree[i].LeftChild;
                            right = lineTree[i].RightChild;
                            exit = false;
                        }
                        lineTmp.Add(line);
                        toDisplayTmp.Add(Convert.ToString(print));
                        lineTreeTmp.Add(left);
                        lineTreeTmp.Add(right);
                    }
                    if (lineTmp.Count != 0) toDisplay.Add(lineTmp);
                    toDisplay.Add(toDisplayTmp);
                    lineTree = lineTreeTmp;
                }
                toDisplay.RemoveAt(toDisplay.Count - 1);
                toDisplay.RemoveAt(toDisplay.Count - 1);
            }

            int len = toDisplay[toDisplay.Count - 1].Count / 2;

            for (int i = 1; i < toDisplay.Count; i += 2)
            {
                int lenNext = len;
                List<string> tmp1 = new List<string>();
                List<string> tmp2 = new List<string>();
                for (int j = 0; j < toDisplay[i].Count; j++)
                {
                    for (int m = 0; m < lenNext; m++)
                    {
                        tmp1.Add("0");
                        tmp2.Add("0");
                    }
                    tmp1.Add(toDisplay[i - 1][j]);
                    tmp2.Add(toDisplay[i][j]);
                    if (j == 0) lenNext = (lenNext * 2) - 1;

                }
                int lenEnd = len - 1;
                for (int m = 0; m < lenEnd; m++)
                {
                    tmp1.Add("0");
                    tmp2.Add("0");
                }
                len /= 2;
                toDisplay[i - 1] = tmp1;
                toDisplay[i] = tmp2;
            }


            len = 0;
            while (len != -1)
            {
                bool remove = true;
                for (int i = 0; i < toDisplay.Count; i++)
                {
                    if (len >= toDisplay[i].Count)
                    {
                        len = -1;
                        break;
                    }
                    if (toDisplay[i][len] != "0")
                    {
                        remove = false;
                        break;
                    }
                }
                if (remove && len != -1) for (int i = 0; i < toDisplay.Count; i++) toDisplay[i].RemoveAt(len);
                else if (len != -1) len++;
            }


            for (int i = 2; i < toDisplay.Count; i += 2)
            {
                for (int j = 0; j < toDisplay[i].Count; j++)
                {
                    if (toDisplay[i][j] == "/" && toDisplay[i - 1][j] == "0")
                    {
                        for (int m = 1; toDisplay[i - 1][j + m] == "0"; m++)
                        {
                            toDisplay[i - 1][j + m] = "_";
                        }
                    }
                    if (toDisplay[i][j] == "\\" && toDisplay[i - 1][j] == "0")
                    {
                        for (int m = 1; toDisplay[i - 1][j - m] == "0"; m++)
                        {
                            toDisplay[i - 1][j - m] = "_";
                        }
                    }
                }
            }
            Print(toDisplay);
        }
        static void Print(List<List<string>> str)
        {
            for (int i = 0; i < str.Count; i++)
            {
                for (int j = 0; j < str[i].Count; j++)
                {
                    {
                        if (str[i][j].Length == 1)
                        {
                            if (str[i][j] == "_") Console.Write(" _" + str[i][j]);
                            else if (str[i][j] == "0") Console.Write("   ");
                            else Console.Write("  " + str[i][j]);
                        }
                        else Console.Write(" " + str[i][j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Tree tree = new Tree();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int a = (int)rnd.Next(1, 20);
                if (!tree.AddItem(a)) i--;
            }
            string command = "";
            PrintTree(tree);
            while (command != "close")
            {
                Console.WriteLine("Для добавление значения введите add + значение" + "\n" + 
                    "Для поиска значения введите search + значение" + "\n" +
                    "Для удаления значения введите del + значение" + "\n" +
                    "Для завершения программы введите close");
                command = Console.ReadLine();
                if (command.Split(" ")[0] == "add")
                {
                    Console.WriteLine(Convert.ToInt32(command.Split(" ")[1]) != 0 ? tree.AddItem(Convert.ToInt32(command.Split(" ")[1])) : false);
                    PrintTree(tree);
                }
                if (command.Split(" ")[0] == "search") Console.WriteLine(tree.GetByValue(Convert.ToInt32(command.Split(" ")[1])) == null ? false : true);
                if (command.Split(" ")[0] == "del")
                {
                    tree.RemoveItem(tree, Convert.ToInt32(command.Split(" ")[1]));
                    PrintTree(tree);
                }
            }
        }
    }
} 


