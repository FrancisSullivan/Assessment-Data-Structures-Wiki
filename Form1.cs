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

        // 9.1 -- Create a global 2D string array.
        #region
        static int row = 12;
        static int column = 4;
        string[,] stringArray = new string[column, row];
        private void Form1_Load(object sender, EventArgs e)
        {
            InitaliseArray();
        }
        private void InitaliseArray()
        {
            for (int i = 0; i < row; i++)
            {
                stringArray[0, i] = "~";
                stringArray[1, i] = "";
            }
            DisplayListView();
        }
        #endregion
        // 9.5 -- Create a CLEAR method to clear the four text boxes.
        #region
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDescription.Clear();
        }
        #endregion
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < row; i++)
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
            ClearTextBoxes();
            DisplayListView();
        }


        
        private void DisplayListView()
        {
            listView.Items.Clear();
            for (int i = 0; i < row; i++)
            {
                ListViewItem listViewItem = new ListViewItem(stringArray[0, i]);
                listViewItem.SubItems.Add(stringArray[1, i]);
                listView.Items.Add(listViewItem);
            }
        }
        

        private void listView_Click(object sender, EventArgs e)
        {
            int currentItem = listView.SelectedIndices[0];
            textBoxName.Text = stringArray[0, currentItem];
            textBoxCategory.Text = stringArray[1, currentItem];
            textBoxStructure.Text = stringArray[2, currentItem];
            textBoxDescription.Text = stringArray[3, currentItem];
        }
    }
}
