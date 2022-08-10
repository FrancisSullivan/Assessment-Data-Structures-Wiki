using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Francis Sullivan, 2022.08.10.

namespace Data_Structures_Wiki
{
    public partial class Form1 : Form
    {
        static int rowSize = 8;
        static int columnSize = 3;
        string[,] employees = new string[rowSize, columnSize];
        public Form1()
        {
            InitializeComponent();
        }
    }
}
