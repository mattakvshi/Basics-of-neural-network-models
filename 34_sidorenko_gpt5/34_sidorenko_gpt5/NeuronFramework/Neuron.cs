using System;
using static System.Math;

namespace WindowsFormsApp1.src
{
    class Neuron
    {

        //поляч
        private TypeNeuron typeNeuron;
        private double[] inputs;
        private double output;
        private double[] weights;
        private double derevative;

        //свойства

        public double[] Inputs { get => inputs; set => inputs = value; }
        public double[] Weights { get => weights; set => weights = value; }
        public double Output { get => output; }
        public double Derevative { get => derevative; }


        //constructor

        public Neuron(double[] w, TypeNeuron t)
        {
            this.typeNeuron = t;
            this.weights = w;
        }

        private double Lya_Kirily (double arg)
        {
            return Math.Max(0.01 * arg, arg);
        }
        private double Lya_Kirily_derevator(double arg)
        {
            if (arg > 0)
            return 1;
            else return 0.01;
        }

        public void Activator(double[] inpt, double[] wght)
        {
            double sum = wght[0];
            for (int i = 0; i < inpt.Length; i++) { 
                sum += inpt[i] * wght[i + 1];
            }


            switch(typeNeuron) {
                case TypeNeuron.Hidden:output = Lya_Kirily(sum); derevative = Lya_Kirily_derevator(sum); break;
                case TypeNeuron.Output:output = Exp(sum); break;
            }  
        }

        

    }
}
