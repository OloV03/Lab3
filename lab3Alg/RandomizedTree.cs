using System;
namespace lab3Alg
{
    public class RandomizedTree
    {

        // добавление узла в дерево (простая вставка)
        public Node AddNode(Node p, int k)
        {
            if (p == null)
                return new Node(k);

            if (k == p.getData())
                return p;

            if (k < p.getData())
                p.setLeft(AddNode(p.getLeft(), k));
            else
                p.setRigth(AddNode(p.getRigth(), k));

            FixSize(p);
            return p;
        }

        // поиск ключа k в дереве p
        public Node Find(Node p, int k)
        {
            // проверка на пустое дерево
            if (p == null)
                return null;

            if (k == p.getData())
                return p;

            // куда дальше пойдет поиск
            if (k < p.getData())
                return Find(p.getLeft(), k);
            else
                return Find(p.getRigth(), k);
        }

        // установление размера дерева
        private void FixSize(Node p)
        {
            int size = GetSize(p.getRigth()) + GetSize(p.getLeft()) + 1;
            p.setSize(size);
        }
        private int GetSize(Node p)
        {
            if (p == null)
                return 0;
            return p.getSize();
        }

        //  правый поворот
        private Node RotateRigth(Node p)
        {
            Node q = p.getLeft();
            if (q == null)
                return p;

            p.setLeft(q.getRigth());
            q.setRigth(p);
            q.setSize(p.getSize());
            FixSize(p);
            return q;
        }

        // левый поворот
        private Node RotateLeft(Node q)
        {
            Node p = q.getRigth();
            if (p == null)
                return q;

            q.setRigth(p.getLeft());
            p.setLeft(q);
            p.setSize(q.getSize());
            FixSize(q);
            return p;
        }

        // вставка в корень
        private Node InsertRoot(Node p, int k)
        {
            if (p == null)
                return new Node(k);

            if (k < p.getData())
            {
                p.setLeft(InsertRoot(p.getLeft(), k));
                return RotateRigth(p);
            }
            else
            {
                p.setRigth(InsertRoot(p.getRigth(), k));
                return RotateLeft(p);
            }
        }

        // рандомизированная вставка
        public Node RandomizeInsert(Node p, int k)
        {
            Random rn = new Random();

            if (p == null)
            {
                p = new Node(k);
                return p;
            }

            if (k == p.getData())
            {
                p.size--;
                return p;
            }

            if (rn.Next(1, p.getSize()+1) == p.getSize())
                return InsertRoot(p, k);

            if (k < p.getData())
                p.setLeft(RandomizeInsert(p.getLeft(), k));
            else
                p.setRigth(RandomizeInsert(p.getRigth(), k));

            FixSize(p);
            return p;
        }

        // прямой обход
        public void PreOrderTravers(Node root)
        {
            if (root != null)
            {
                Console.Write(root.getData() + " ");
                PreOrderTravers(root.getLeft());
                PreOrderTravers(root.getRigth());
            }
        }

        // симметричный обход
        public void InOrderTravers(Node root)
        {
            if (root != null)
            {
                InOrderTravers(root.getLeft());
                Console.Write(root.getData() + " ");
                InOrderTravers(root.getRigth());
            }
        }

        // заполнение дерева TreeTo при симметричном обходе дерева TreeFrom
        public void InsertInOrder(Node TreeFrom, Node TreeTo)
        {
            if (TreeFrom != null)
            {
                InsertInOrder(TreeFrom.getLeft(), TreeTo);
                if (Find(TreeTo, TreeFrom.getData()) == null)
                    RandomizeInsert(TreeTo, TreeFrom.getData());

                InsertInOrder(TreeFrom.getRigth(), TreeTo);
                if (Find(TreeTo, TreeFrom.getData()) == null)
                    RandomizeInsert(TreeTo, TreeFrom.getData());
            }
        }

        // доабавление пробелов (необходимо для корректного вывода дерева)
        private string SetTabs(int tabs)
        {
            string res = "";

            for (int i = 0; i < tabs; i++)
            {
                res += "  ";
            }

            return res;
        }

        // вывод дерева в консоль
        public Node PrintTree(Node p, int tab = 0)
        {
            bool app = true;
            if (p == null)
                Console.WriteLine("Дерево пустое");
            else
            {
                Console.Write(p.ToString());
                if (p.getLeft() == null && p.getRigth() == null)
                {
                    return p;
                }

                app = false;

                if (p.getLeft() != null || p.getLeft() != null)
                {
                    if (tab != 0)
                        Console.Write($"\n|{SetTabs(tab)}|-");
                    else
                        Console.Write("\n|-");


                    tab++;
                    PrintTree(p.getLeft(), tab);
                    tab--;
                    app = true;
                }

                if (p.getRigth() != null)
                {
                    if (app)
                    {
                        Console.Write("\n");
                        if (tab != 0)
                            Console.Write($"|{SetTabs(tab)}|-");
                        else
                            Console.Write("|-");
                    }

                    else
                    {
                        if (tab != 0)
                            Console.Write($"\n|{SetTabs(tab)}|-");
                        else
                            Console.Write("\n|-");
                    }

                    tab++;
                    PrintTree(p.getRigth(), tab);
                    tab--;
                }
            }


            return p;
        }
    }
}




//// вывод дерева в консоль
//public Node PrintTree(Node p, int tab = 0)
//{
//    bool app = true;
//    if (p == null)
//        Console.Write("Дерево пустое");
//    else
//    {
//        Console.Write(p.ToString());
//        if (p.getLeft() == null && p.getRigth() == null)
//        {
//            return p;
//        }

//        app = false;

//        if (p.getLeft() != null || p.getLeft() != null)
//        {
//            if (tab != 0)
//                Console.Write($"\n|{SetTabs(tab)}|-");
//            else
//                Console.Write("\n|-");


//            tab++;
//            PrintTree(p.getLeft(), tab);
//            tab--;
//            app = true;
//        }

//        if (p.getRigth() != null)
//        {
//            if (app)
//            {
//                Console.Write("\n|");
//                if (tab != 0)
//                    Console.Write($"{SetTabs(tab)}|-");
//                else
//                    Console.Write("-");
//            }

//            else
//            {
//                if (tab != 0)
//                    Console.Write($"\n|{SetTabs(tab)}|-");
//                else
//                    Console.Write("\n|-");
//            }

//            tab++;
//            PrintTree(p.getRigth(), tab);
//            tab--;
//        }
//    }


//    return p;
//}