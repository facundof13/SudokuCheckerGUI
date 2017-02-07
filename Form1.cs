using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuCheckerGUI
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Facundo.\n\nJanuary 2017", "About Sudoku Checker");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            List<Int32> board = new List<Int32>(); //create new list to store all the textbox items in
            int[,] arr = new int[9, 9];
            bool validBoard = true;
            bool errorShown = false;

            try
            {
                foreach (var control in this.Controls.OfType<TextBox>())
                {
                    if (control.Text != "0")
                    {
                        board.Add(int.Parse(control.Text));
                    }

                }
            }
            catch {
                MessageBox.Show("Please fill the board correctly.");
                errorShown = true;
            }


            //loop through 2d array and add list items to array\
            int row = 0; //current row
            int column = 0; //current column 
            int boardLength = board.Count; //size of board
            int boardIndex = 0; //current list index

            for (int i = 0; i < boardLength; i++)
            {
                if (column > 8)
                {
                    column = 0;
                    row++;
                }

                if (board[boardIndex] == 1 || board[boardIndex] == 2 || board[boardIndex] == 3 ||
                    board[boardIndex] == 4 || board[boardIndex] == 5 || board[boardIndex] == 6 ||
                    board[boardIndex] == 7 || board[boardIndex] == 8 || board[boardIndex] == 9)
                {
                    arr[row, column] = board[boardIndex];
                }

                column++;
                boardIndex++;
            }

            int[] rowCopy = new int[9];
            int[] columnCopy = new int[9];

            for (int o = 0; o < arr.GetLength(0); o++)
            {
                rowCopy = copyRow(arr, o);
                columnCopy = copyColumn(arr, o);
                if ((CheckRow(rowCopy) == false) || (checkColumn(columnCopy) == false))
                    validBoard = false;
            }

            if (!errorShown)
            {
                MessageBox.Show("This board is " + (validBoard ? "valid." : "not valid."));
            }
        }


        private static bool CheckRow(int[] arr)
        {
            return arr.Distinct().Count() == arr.Length;
        }

        private static bool checkColumn(int[] arr)
        {
            return arr.Distinct().Count() == arr.Length;
        }

        private static int[] copyRow(int[,] arr, int row)
        {
            int[] copy = new int[9];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                copy[i] = arr[row, i];

            }

            return copy;
        }

        private static int[] copyColumn(int[,] arr, int column)
        {
            int[] copy = new int[9];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                copy[i] = arr[i, column];
            }

            return copy;
        }

        private void printArray (int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    System.Diagnostics.Debug.Write(arr[i, j]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        private void clearBoardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls.OfType<TextBox>())
            {
                control.Text = "";
            }
        }

        private void randomizeBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            foreach (var control in this.Controls.OfType<TextBox>())
            {
                int random = rand.Next(1, 10);
                control.Text = random.ToString(); ;
            }
        }
    }
}
