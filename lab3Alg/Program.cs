using System;
using System.IO;
using System.Collections.Generic;

namespace lab3Alg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практика 3 - Деревья двоичного поиска\n");
            RandomizedTree alg = new RandomizedTree();

            // формируем дерево A
            Node TreeA = new Node(40);
            TreeA = alg.RandomizeInsert(TreeA, 10);
            TreeA = alg.RandomizeInsert(TreeA, 20);
            TreeA = alg.RandomizeInsert(TreeA, 11);
            TreeA = alg.RandomizeInsert(TreeA, 14);
            TreeA = alg.RandomizeInsert(TreeA, 19);
            TreeA = alg.RandomizeInsert(TreeA, 65);
            TreeA = alg.RandomizeInsert(TreeA, 1);
            TreeA = alg.RandomizeInsert(TreeA, 99);
            TreeA = alg.RandomizeInsert(TreeA, 5);

            Console.WriteLine("Дерево 'A'");
            alg.PrintTree(TreeA);
            Console.WriteLine("\n\nПрямой обход дерева 'A'");
            alg.PreOrderTravers(TreeA);
            Console.WriteLine("\n\n");



            // формируем дерево B
            Node TreeB = new Node(50);
            TreeB = alg.RandomizeInsert(TreeB, 60);
            TreeB = alg.RandomizeInsert(TreeB, 11);
            TreeB = alg.RandomizeInsert(TreeB, 5);
            TreeB = alg.RandomizeInsert(TreeB, 10);
            TreeB = alg.RandomizeInsert(TreeB, 20);
            TreeB = alg.RandomizeInsert(TreeB, 84);
            TreeB = alg.RandomizeInsert(TreeB, 14);
            TreeB = alg.RandomizeInsert(TreeB, 21);
            TreeB = alg.RandomizeInsert(TreeB, 1);

            Console.WriteLine("Дерево 'B'");
            alg.PrintTree(TreeB);
            Console.WriteLine("\n\nСиммеетричный обход дерева 'B'");
            alg.InOrderTravers(TreeB);
            Console.WriteLine("\n\n");



            // формируем дерево С
            Node TreeC = TreeA;
            Console.WriteLine("Дерево 'C'");
            alg.InsertInOrder(TreeB, TreeC);
            alg.PrintTree(TreeC);
            Console.WriteLine("\n\nПрямой обход дерева 'C'");
            alg.PreOrderTravers(TreeC);




            Console.ReadLine();
        }
    }
}
