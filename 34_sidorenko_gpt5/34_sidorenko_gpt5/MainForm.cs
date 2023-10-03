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
            if(b.BackColor == Color.Black)
            {
                b.BackColor = Color.default;
                statusArray[index] = 0;
            }
            else 
            {
                b.BackColor = Color.Black;
                statusArray[index] = 1;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 1");
            ChangeStatusData(button1, 0);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 2");
            ChangeStatusData(button2, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 3");
            ChangeStatusData(button3, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 4");
            ChangeStatusData(button4, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 5");
            ChangeStatusData(button5, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 6");
            ChangeStatusData(button6, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 7");
            ChangeStatusData(button7, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 8");
            ChangeStatusData(button8, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 9");
            ChangeStatusData(button9, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 10");
            ChangeStatusData(button10, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 11");
            ChangeStatusData(button11, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 12");
            ChangeStatusData(button12, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 13");
            ChangeStatusData(button13, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 14");
            ChangeStatusData(button14, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MassageFunc("Кнопка 15");
            ChangeStatusData(button15, 0);
        }

        private void LerningButton_Click(object sender, EventArgs e)
        {
             
        }
    }
}
