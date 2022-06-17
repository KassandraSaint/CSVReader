using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSVReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getBtn_Click(object sender, EventArgs e)
        {
            // Trying to read a file
            try
            {
                // Creating a StreamReader Object to read a file
                StreamReader inputFile;

                // Initializing variables to work with data
                string line;
                int count = 0;
                int total;
                double average;

                // Creating an array for a delimiter
                char[] delim = { ',' };

                // Opening the file
                inputFile = File.OpenText("Resources/Grades.csv");

                // While there is data reading a file line by line
                while (!inputFile.EndOfStream)
                {
                    // Incrementing student count
                    count++;
                    // Reading a line from the file into a line variable
                    line = inputFile.ReadLine();

                    // Separating tokens by delimkiter on each line
                    string[] tokens = line.Split(delim);

                    // Setting total to 0 
                    total = 0;
                    // Calculating total of each student by summing tokens of each line
                    foreach (string str in tokens)
                    {
                        total += int.Parse(str);
                    }

                    // Calculating average of student's test scores
                    average = (double)total / tokens.Length;

                    // Displaying average of test scores in the Box List
                    averageBox.Items.Add("The average for student " + count + " is " + average.ToString("n1"));
                }
                // Closing the file
                inputFile.Close();
            }
            // Showing a message if the was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            // Closing the form
            this.Close();
        }
    }
}
