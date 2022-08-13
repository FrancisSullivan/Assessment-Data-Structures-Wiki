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
        // Program Criteria.
        // 9.01 -- Create a global 2D string array.
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
                stringArray[2, i] = "";
                stringArray[3, i] = "";
            }
            DisplayListView();
        }
        #endregion
        // 9.02 -- Create an 'Add' button to add info from the four TextBoxes into array.
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
        // 9.03 -- Create an 'Edit' button to let the user modify the array with info from the four text boxes.
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
        // 9.04 -- Create a 'Delete' button to removes all information from an item in the array.
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
        // 9.05 -- Create a 'Clear' method to clear the four TextBoxes.
        #region
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDescription.Clear();
        }
        #endregion
        // 9.09 -- Create a 'TextBoxDisplay' method to show info when an item is selected in the ListView.
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
        // 9.08 -- Create a 'ListViewDisplay' method to show 'Name' and 'Category' in a ListView.
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
        // 9.10	-- Create a 'Save' button.
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
                BubbleSort();
                DisplayListView();
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
        // 9.11	-- Create a 'Load' button that will read information into the array.
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
                DisplayListView();
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
                            int y = 0;
                            Array.Clear(stringArray, 0, stringArray.Length);
                            while (stream.Position < stream.Length)
                            {
                                for (int x = 0; x < column; x++)
                                {
                                    stringArray[x, y] = reader.ReadString();
                                }
                                y++;
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
        // 9.6	-- Create a 'Bubble Sort' method.
        #region
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            BubbleSort();
            DisplayListView();
        }
        private void BubbleSort()
        {
            for (int i = 0; i < (row - 1); i++)
            {
                for (int j = 0; j < (row - 1); j++)
                {
                    string string00 = stringArray[0, j];
                    string string01 = stringArray[0, j + 1];

                    char[] character00 = string00.ToCharArray();
                    char[] character01 = string01.ToCharArray();

                    int length00 = character00.Length;
                    int length01 = character01.Length;

                    int minimumLength = 1;

                    if (length00 <= length01)
                    {
                        minimumLength = length00;
                    }
                    if (length00 >= length01)
                    {
                        minimumLength = length01;
                    }

                    for (int k = 0; k < minimumLength; k++)
                    {
                        Console.WriteLine("Loop.");
                        if (character01[k] < character00[k])
                        {
                            string temp00 = stringArray[0, j];
                            stringArray[0, j] = stringArray[0, j + 1];
                            stringArray[0, j + 1] = temp00;

                            string temp01 = stringArray[1, j];
                            stringArray[1, j] = stringArray[1, j + 1];
                            stringArray[1, j + 1] = temp01;

                            string temp02 = stringArray[2, j];
                            stringArray[2, j] = stringArray[2, j + 1];
                            stringArray[2, j + 1] = temp02;

                            string temp03 = stringArray[3, j];
                            stringArray[3, j] = stringArray[3, j + 1];
                            stringArray[3, j + 1] = temp03;

                            break;
                        }
                        if (character01[k] > character00[k])
                        {
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        // 9.7	-- Create a 'Binary Search' method.
        #region
        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
        void BinarySearch()
        {
            int column = 1;
            int row = 4;
            string[,] array = new string[column, row];

            array[0, 0] = "a";
            array[0, 1] = "b";
            array[0, 2] = "c";
            array[0, 3] = "d";

            int lowerBound = 0;
            int upperBound = row - 1;
            string target = "d";

            while (true)
            {
                int midPoint = (lowerBound + upperBound) / 2;
                if (array[0, midPoint] == target)
                {
                    Console.WriteLine("Found.");
                    break;
                }
                if (array[0, midPoint].ToCharArray()[0] < target.ToCharArray()[0])
                {
                    lowerBound = midPoint + 1;
                }
                else if (array[0, midPoint].ToCharArray()[0] > target.ToCharArray()[0])
                {
                    upperBound = midPoint - 1;
                }

            }
        }
        #endregion
    }
}
