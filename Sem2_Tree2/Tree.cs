using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sem2_Tree2
{
    class Tree
    {
        private Node root;

        public void Create(string inputFile, ref Tree tree)
        {
            if (tree == null)
                tree = new Tree();
            List<int> s = ArrayUtils.ReadFromFile(inputFile);
            for (int i = 0; i < s.Count; i++)
                tree.Add(s[i]);
        }
        public void Add(int value)
        {
            Add(value, ref root);
        }
        private void Add(int value, ref Node local)
        {
            if (local == null)
            {
                local = new Node();
                local.value = value;
                return;
            }
            if (local.value < value)
            {
                Add(value, ref local.right);
            }
            else
            {
                Add(value, ref local.left);
            }
        }

        public void Drawing(Graphics g, int x, int y, int dy)
        {
            DrawingTree(g, root, x, y, dy);
        }
        private void DrawingTree(Graphics g, Node p, int x, int y, int dy)
        {
            if (p == null)
                return;
            else
            {
                if (p.left != null)
                    Draw.Edge(g, x, y, x / 2, y + dy);
                if (p.right != null)
                    Draw.Edge(g, x, y, x + x / 2, y + dy);
                Draw.Ellipse(g, x, y, p);
                Draw.Node(g, x, y, p);
                DrawingTree(g, p.left, x / 2, y + dy, dy);
                DrawingTree(g, p.right, x + x / 2, y + dy, dy);
            }
        }

        public List<int> Print()
        {
            List<int> list = new List<int>();
            PrintTree(root, list);
            return list;
        }
        private void PrintTree(Node p, List<int> list)
        {
            if (p == null)
                return;
            else
            {
                list.Add(p.value);
                PrintTree(p.left, list);
                PrintTree(p.right, list);
            }
        }

    }
}
