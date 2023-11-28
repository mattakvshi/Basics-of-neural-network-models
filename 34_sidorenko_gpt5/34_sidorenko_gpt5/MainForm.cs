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

namespace _34_sidorenko_gpt5
{
    public partial class MainForm : Form { 

        int[] statusArray = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int numericValue = 0;  // new variable to hold the numericUpDown value

        public MainForm()
        {
            InitializeComponent();
        }

        void MassageFunc(string massageText) {
            MessageBox.Show(massageText);
        }

        void ChangeStatusData(Button b, int index)
        {
            if(b.BackColor == Color.Gray)
            {
                b.BackColor = Color.Gainsboro;
                statusArray[index] = 0;
            }
            else 
            {
                b.BackColor = Color.Gray;
                statusArray[index] = 1;
            }

        }

     
         
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button1, 0);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button3, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button4, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button5, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button6, 5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button7, 6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button8, 7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button9, 8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button10, 9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button11, 10);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button12, 11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button13, 12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button14, 13);
        }

        private void button15_Click(object sender, EventArgs e)
        {

            ChangeStatusData(button15, 14);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Convert the decimal value from the numericUpDown1 to an int and store it in numericValue
            numericValue = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void LerningButton_Click(object sender, EventArgs e)
        {
            // Convert the statusArray into a comma separated string
            string output = numericValue + "-" + string.Join(",", statusArray);

            // Append the new array to the end of the file, with a newline
            // If the file does not exist, this method creates it
            File.AppendAllText("Lerning.txt", output + Environment.NewLine);
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            // Convert the statusArray into a comma separated string
            string output = numericValue + "-" + string.Join(",", statusArray);

            // Append the new array to the end of the file, with a newline
            // If the file does not exist, this method creates it
            File.AppendAllText("Test.txt", output + Environment.NewLine);
        }

        private void IdentifideButton_Click(object sender, EventArgs e)
        {

        }
    }
}
