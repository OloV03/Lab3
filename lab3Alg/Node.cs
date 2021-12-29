using System;

namespace lab3Alg
{
    public class Node
    {
        private int data;
        public int size;
        private Node left;
        private Node rigth;

        public Node(int data)
        {
            this.data = data;
            size = 1;
        }

        public override string ToString() { return data.ToString(); }

        public int getData() { return data; }

        public Node getLeft() { return left; }
        public Node getRigth() { return rigth; }
        public int getSize() { return size; }

        public void setSize(int size) { this.size++; }
        public void setLeft(Node node) { left = node; }
        public void setRigth(Node node) { rigth = node; }
    }
}
