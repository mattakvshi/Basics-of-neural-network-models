

namespace _34_sidorenko_gpt5.src
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, TypeNeuron nt, string name) : base(non, nopn, nt, name) { }

        public override void Recognize(NeuralNetwork net, Layer nextLayer)
        {
            double[] hidden_out = new double[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++)
                hidden_out[i] = Neurons[i].Output;
            nextLayer.Data = hidden_out;
        }
        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum = new double[numOfPrevNeurons];
            for (int j = 0; j < gr_sum.Length; j++) // Вычисление градиентных сумм
            {
                double sum = 0;
                for (int k = 0; k < numOfNeurons; k++)
                    sum += Neurons[k].Weights[j] * Neurons[k].Derivative * gr_sums[k];
            }

            for (int i = 0; i < numOfNeurons; i++) // Вычисление коррекции синапт. весов
            {
                for (int n = 0; n < numOfPrevNeurons; n++)
                {
                    double deltaW = 0;
                    if (n == 0) // Для коррекции порогов
                        deltaW = momentum * lastDeltaWeights[i, 0] + learningRate * Neurons[i].Derivative * gr_sums[i];
                    else
                        deltaW = momentum * lastDeltaWeights[i, n] +
                            learningRate * Neurons[i].Inputs[n - 1] * Neurons[i].Derivative * gr_sums[i];
                    lastDeltaWeights[i, n] = deltaW;
                    Neurons[i].Weights[n] += deltaW; // Коррекция весов
                }
            }
            return gr_sum;
        }
    }
}
