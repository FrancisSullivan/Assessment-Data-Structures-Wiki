using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Francis Sullivan

namespace Data_Structures_Wiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        static int rows = 12;
        static int columns = 4;
        string[,] stringArray = new string[columns, rows];
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                if (stringArray[0, i] == "~")
                {
                    stringArray[0, i] = textBoxName.Text;
                    stringArray[1, i] = textBoxCategory.Text;
                    stringArray[2, i] = textBoxStructure.Text;
                    stringArray[3, i] = textBoxDescription.Text;
                    break;
                }
            }
            DisplayListView();
        }
        private void InitaliseArray()
        {
            for (int i = 0; i < rows; i++)
            {
                stringArray[0, i] = "~"; // Name
                stringArray[1, i] = ""; //  Category
            }
            DisplayListView();
        }
        private void DisplayListView()
        {
            listView.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                ListViewItem lvi = new ListViewItem(stringArray[0, i]);
                lvi.SubItems.Add(stringArray[1, i]);
                listView.Items.Add(lvi);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitaliseArray();
        }
    }
}
