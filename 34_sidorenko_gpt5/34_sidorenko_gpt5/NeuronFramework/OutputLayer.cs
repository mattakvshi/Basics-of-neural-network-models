

namespace WindowsFormsApp1.src
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nonp, TypeNeuron nt, string type) : base(non, nonp, nt, type)
        {

        }

        public override void Recognize(NeuralNetwork net, Layer nextLayer)
        {
            double e_sum = 0;

            for (int i = 0; i < Neurons.Length; i++)
            {
                e_sum += Neurons[i].Output;
            }

            for (int i = 0; i < Neurons.Length; i++)
            {
                net.fact[i] = Neurons[i].Output / e_sum;
                // завершение функции активации СОФТ МАКС
            }
        }

        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numOfNeurons]; // сумма градиентов 

            for (int j = 0; j < gr_sum.Length; j++) // Вычисление локальных градиентов 
            {
                double sum = 0;

                for (int k = 0; k < numOfNeurons; k++)
                {
                    sum += Neurons[k].Weights[j] *  errors[k];
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
                        deltaW = momentum * lastdeltaweights[i, 0] + learningRade * errors[i];
                    }
                    else
                    {
                        deltaW = momentum * lastdeltaweights[i, n] + learningRade * Neurons[i].Inputs[n - 1]
                            * errors[i];
                    }

                    lastdeltaweights[i, n] = deltaW;
                    Neurons[i].Weights[n] += deltaW; // Коррекци весов 
                }
            }



            return gr_sum;
        }
    }

    
}
