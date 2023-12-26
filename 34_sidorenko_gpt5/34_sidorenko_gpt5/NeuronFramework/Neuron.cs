using System;
using static System.Math;

namespace _34_sidorenko_gpt5.src
{
    class Neuron
    {
        //private double a = 1.7159;
        //private double b = 2 / 3;
        private double a = 1;
        private double b = 1;
        // поля
        private TypeNeuron type;
        private double[] inputs;
        private double[] weights;
        private double derivative;

        private double output;

        // свойства 
        public double[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }

        public double[] Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        public double Derivative
        {
            get { return derivative; }
        }

        public double Output
        {
            get { return output; }
        }

        // конструктор

        public Neuron(double[] ws, TypeNeuron t)
        {
            type = t;
            weights = ws;
        }

        public void Activator()
        {
            // первый элемент weights - b (порог)
            double sum = weights[0];
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * weights[i + 1];
            }

            switch (type)
            {
                case TypeNeuron.Output:
                    output = Exp(sum);
                    break;
                case TypeNeuron.Hidden:
                    output = th(sum);
                    derivative = Derivator(sum);
                    break;
                default:
                    break;
            }
        }

        // функция активации (гиперболический тангенс)
        private double th(double x)
        {
            return a * Tanh(b * x);
        }

        // вычисление производной
        private double Derivator(double x)
        {
            return a * b * (1 - Pow(Tanh(b * x), 2));
        }
    }
}
