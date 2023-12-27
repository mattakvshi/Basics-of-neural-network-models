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
using _34_sidorenko_gpt5.src;

namespace _34_sidorenko_gpt5
{
    public partial class MainForm : Form {

        double[] inputData;
        int numericValue = 0;  // new variable to hold the numericUpDown value
        NeuralNetwork net = new NeuralNetwork(NetworkMode.Recognize);

        public double[] InputData
        {
            get { return inputData; }
            set { inputData = value; }
        }


        double[] NetOutput
        {
            set => labelOutput.Text = value.ToList().IndexOf(value.Max()).ToString();
        }

        //void MassageFunc(string massageText) {
        //    MessageBox.Show(massageText);
        //}

        public MainForm()
        {
            InputData = new double[15];
            InitializeComponent();
        }

        void ChangeStatusData(Button b, int index)
        {
            if(b.BackColor == Color.Gray)
            {
                b.BackColor = Color.Gainsboro;
                InputData[index] = 0;
            }
            else 
            {
                b.BackColor = Color.Gray;
                InputData[index] = 1;
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

        private void saveTrainDataBtn_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "trainData.txt";
            string data = numericValue.ToString();
            foreach (int i in InputData)
            {
                data += " " + i.ToString();
            }
            data += "\n";
            File.AppendAllText(path, data);
        }

        private void saveTestDataBtn_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "testData.txt";
            string data = numericValue.ToString();
            foreach (int i in InputData)
            {
                data += " " + i.ToString();
            }
            data += "\n";
            File.AppendAllText(path, data);
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            net.ForwardPass(net, InputData);
            NetOutput = net.Fact;
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            net.Train(net);
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            net.Test(net);
        }
    }
}
