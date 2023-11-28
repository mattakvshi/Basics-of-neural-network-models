

namespace WindowsFormsApp1.src
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nonp, TypeNeuron nt, string type) : base(non, nonp, nt, type)
        {
            
        }

        public override void Recognize(NeuralNetwork net, Layer nextLayer)
        {
            double[] hidden_out = new double[Neurons.Length];

            for (int i = 0; i < Neurons.Length; i++)
            {
                hidden_out[i] = Neurons[i].Output;
            }

            nextLayer.Data = hidden_out;
        }

        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum = new double[numOfNeurons];

            for (int j = 0; j < gr_sum.Length ; j++) // Вычисление локальных градиентов 
            {
                double sum = 0;

                for (int k = 0; k < numOfNeurons; k++) {
                    sum += Neurons[k].Weights[j] * Neurons[k].Derevative * gr_sums[k];
                }

                gr_sum[j] = sum;
                
            }

            for (int i = 0; i < numOfNeurons; i++)
            {
                for (int n = 0; n < numOfPrevNeurons + 1; n++) // цикл коректировки весов
                {
                    double deltaW;
                    if (n == 0)
                    {
                        deltaW = momentum * lastdeltaweights[i,0] + learningRade * Neurons[i].Derevative * gr_sums[i];
                    }
                    else
                    {
                        deltaW = momentum * lastdeltaweights[i, n] + learningRade * Neurons[i].Inputs[n - 1]
                            * Neurons[i].Derevative * gr_sums[i];
                    }

                    lastdeltaweights[i,n] = deltaW;
                    Neurons[i].Weights[n] += deltaW; // Коррекци весов 
                }
            }

            

            return gr_sum;
        }




    }
}
