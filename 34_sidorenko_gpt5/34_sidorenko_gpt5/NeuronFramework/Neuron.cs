using static System.Math;

namespace _34_sidorenko_gpt5.NeuronFramework
{
    class Neuron
    {
        //поля
        private TypeNeuron typeNeuron;
        private double[] inputs; //Входные данные
        private double[] weights; //Синаптические веса нейрона
        private double output; //Выходной сигнал нейрона
        private double derevative; //Производная

        //свойства
        public double[] Inputs { get => inputs; set => inputs = value; }
        public double[] Weights { get => weights; set => weights = value; }
        public double Output { get => output; }
        public double Derevative { get => derevative; }

        //конструктор 
        public Neuron(double[] w, TypeNeuron t)
        {
            this.typeNeuron = t;
            this.weights = w;
        }

        private double HiperbolicTg(double arg)
        {
            return 0;
        }

        private double HeperbolicTgDerevator(double arg)
        {
            return 0;
        }

        public void Activator(double[] inpt, double[] wght)
        {
            double sum = wght[0];
            for (int i = 0; i < inpt.Length; i++)
            {
                sum += inpt[i] * wght[i + 1];
            }

            switch (typeNeuron)
            {
                case TypeNeuron.Hidden:
                    output = HiperbolicTg(sum); 
                    derevative = HeperbolicTgDerevator(sum);
                    break;

                case TypeNeuron.Output:
                    output = Exp(sum);
                    break;
            }
        }








    }
}
