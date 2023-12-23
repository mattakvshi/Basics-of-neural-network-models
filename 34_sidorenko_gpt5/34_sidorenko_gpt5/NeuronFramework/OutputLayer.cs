

namespace WindowsFormsApp1.src
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, TypeNeuron nt, string name) : base(non, nopn, nt, name) { }

        public override void Recognize(NeuralNetwork net, Layer nextLayer)
        {
            double e_sum = 0;
            for (int i = 0; i < numOfNeurons; i++)
                e_sum += Neurons[i].Output;

            for (int i = 0; i < numOfNeurons; i++)
            {
                net.Fact[i] = Neurons[i].Output / e_sum; //Расчёт веткора выходных сигналов
            }
        }

        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numOfPrevNeurons + 1];
            for (int j = 0; j < numOfPrevNeurons + 1; j++) // Вычисление градиентых сумм 
            {
                double sum = 0;
                for (int k = 0; k < numOfNeurons; k++)
                    sum += Neurons[k].Weights[j] * errors[k];

                gr_sum[j] = sum;
            }

            for (int i = 0; i < numOfNeurons; i++) // Вычисление коррекции синаптических весов 
            {
                for (int n = 0; n < numOfPrevNeurons + 1; n++)
                {
                    double deltaW;
                    if (n == 0) // Коррекция порогов
                        deltaW = momentum * lastDeltaWeights[i, 0] + learningRate * errors[i];
                    else //Коррекция синаптических весов
                        deltaW = momentum * lastDeltaWeights[i, n] +
                            learningRate * Neurons[i].Inputs[n - 1] * errors[i];

                    lastDeltaWeights[i, n] = deltaW;
                    Neurons[i].Weights[n] += deltaW; //Коррекция весов
                }
            }
            return gr_sum;
        }

    }
}
