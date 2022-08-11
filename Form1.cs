using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// Francis Sullivan

namespace Data_Structures_Wiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 99%.
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
        // 9.2 -- Create an ADD button to store information from the four TextBoxes into array.
        #region
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
        #endregion
        // 9.5 -- Create a CLEAR method to clear the four TextBoxes.
        #region
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDescription.Clear();
        }
        #endregion
        // 9.8 -- Create a DISPLAY method to show 'Name' and 'Category' in a ListView.
        #region
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
        #endregion
        // 9.9 -- Create a method to diplay relevant information in appropriate TextBoxes,
        //        when an item is selected in the ListView.
        #region
        private void listView_Click(object sender, EventArgs e)
        {
            int currentItem = listView.SelectedIndices[0];
            textBoxName.Text = stringArray[0, currentItem];
            textBoxCategory.Text = stringArray[1, currentItem];
            textBoxStructure.Text = stringArray[2, currentItem];
            textBoxDescription.Text = stringArray[3, currentItem];
        }
        #endregion

        // In-progress.

        // To-do.
        // 9.3	-- Create an EDIT button that will allow the user to modify any information
        //         from the 4 text boxes into the 2D array.
        // 9.4	-- Create a DELETE button that removes all the information from a single entry
        //         of the array; the user must be prompted before the final deletion occurs.
        // 9.6	-- Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        //         ensure you use a separate swap method that passes the array element to be swapped
        //         (do not use any built-in array methods),
        // 9.7	-- Write the code for a Binary Search for the Name in the 2D array and display
        //         the information in the other textboxes when found, add suitable feedback if the
        //         search in not successful and clear the search textbox(do not use any built-in array methods).
        // 9.10	-- Create a SAVE button so the information from the 2D array can be written into a binary file
        //         called definitions.dat which is sorted by Name, ensure the user has the option to select
        //         an alternative file. Use a file stream and BinaryWriter to create the file.
        // 9.11	-- Create a LOAD button that will read the information from a binary file called
        //         definitions.dat into the 2D array, ensure the user has the option to select an alternative file.
        //         Use a file stream and BinaryReader to complete this task.



    }
}
