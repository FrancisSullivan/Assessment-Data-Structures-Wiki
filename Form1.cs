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
        string[,] stringArray = new string[rows, columns];
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < rows; y++)
            {
                if (stringArray[y, 0] == "~")
                {
                    stringArray[y, 0] = textBoxName.Text;
                    stringArray[y, 1] = textBoxCategory.Text;
                    stringArray[y, 2] = textBoxStructure.Text;
                    stringArray[y, 3] = textBoxDescription.Text;
                }
            }
        }
    }
}
