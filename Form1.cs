using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// Francis Sullivan.

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
        // 9.2 -- Create an ADD button to add info from the four TextBoxes into array.
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
        // 9.3 -- Create an EDIT button to let the user modify the array with info from the four text boxes.
        #region
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int currentItem = listView.SelectedIndices[0];
            stringArray[0, currentItem] = textBoxName.Text;
            stringArray[1, currentItem] = textBoxCategory.Text;
            stringArray[2, currentItem] = textBoxStructure.Text;
            stringArray[3, currentItem] = textBoxDescription.Text;
            ClearTextBoxes();
            DisplayListView();
        }
        #endregion
        // 9.4 -- Create a DELETE button to removes all information from an item in the array.
        #region
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int currentItem = listView.SelectedIndices[0];
            stringArray[0, currentItem] = "~";
            stringArray[1, currentItem] = "";
            stringArray[2, currentItem] = "";
            stringArray[3, currentItem] = "";
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
        // 9.9 -- Create a TextBoxDisplay method to show info when an item is selected in the ListView.
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
        // 9.8 -- Create a ListViewDisplay method to show 'Name' and 'Category' in a ListView.
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

        // In-progress.
        // 9.10	-- Create a SAVE button, data is written to a binary file called definitions.dat.
        //         Data is sorted by Name, user has the option to select an alternate file.
        //         Use a file stream and BinaryWriter to create the file.
        #region
        string defaultFileName = "default.bin";
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bin file|*.bin";
            saveFileDialog.Title = "Save A BIN file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (saveFileDialog.FileName != "")
            {
                Save(fileName);
            }
            else
            {
                Save(defaultFileName);
            }
        }
        private void Save(string saveFileName)
        {
            try
            {
                using (Stream stream = File.Open(saveFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        for (int y = 0; y < row; y++)
                        {
                            for (int x = 0; x < column; x++)
                            {
                                writer.Write(stringArray[x, y]);
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        // 9.11	-- Create a LOAD button that will read the information from a binary file called
        //         definitions.dat into the 2D array, ensure the user has the option to select an alternative file.
        //         Use a file stream and BinaryReader to complete this task.
        #region
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN FILES|*.bin";
            openFileDialog.Title = "Open a BIN file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Open(openFileDialog.FileName);
            }
        }
        private void Open(string openFileName)
        {
            try
            {
                using (Stream stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        {
                            int x = 0;
                            Array.Clear(stringArray, 0, stringArray.Length);
                            while (stream.Position < stream.Length)
                            {
                                for (int y = 0; y < column; y++)
                                {
                                    stringArray[x, y] = reader.ReadString();
                                }
                                x++;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        // To-do.
        // 9.6	-- Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        //         ensure you use a separate swap method that passes the array element to be swapped
        //         (do not use any built-in array methods).
        // 9.7	-- Write the code for a Binary Search for the Name in the 2D array and display
        //         the information in the other textboxes when found, add suitable feedback if the
        //         search in not successful and clear the search textbox(do not use any built-in array methods).
    }
}
