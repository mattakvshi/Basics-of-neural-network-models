using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _34_sidorenko_gpt5
{
    public partial class MainForm : Form { 

        int[] statusArray = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    
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
            ChangeStatusData(button2, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button3, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button4, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button5, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button6, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button7, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button8, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button9, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button10, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button11, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button12, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button13, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button14, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {

            ChangeStatusData(button15, 0);
        }


        private void LerningButton_Click(object sender, EventArgs e)
        {
             
        }

        private void TestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
