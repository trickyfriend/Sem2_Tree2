﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2_Tree2
{
    public partial class TreeForm : Form
    {

        static Graphics g;
        Tree tree = new Tree();

        public TreeForm()
        {
            InitializeComponent();
        }

        private void TreeForm_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }

        private void buttonCreateTree_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    tree.Create(openFileDialog.FileName, ref tree);
                    tree.Drawing(g, Width / 6, 70, 70);
                }
                catch (Exception except)
                {
                    FormsUtils.ErrorMessageBox(except);
                }
        }

        private void buttonShowList_Click(object sender, EventArgs e)
        {
            textBoxShowList.Clear();
            try
            {
                List<int> list = tree.Print();
                for (int i = 0; i < list.Count; i++)
                    textBoxShowList.Text += list[i] + "\r\n";
            }
            catch
            {
                MessageBox.Show("Tree is not created.");
            }
        }
    }
}
