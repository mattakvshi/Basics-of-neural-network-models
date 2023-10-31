using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_sidorenko_gpt5.NeuronFramework
{
    internal class Layer
    {
        protected string layerName;
        string pathDirWeights; //путь для каталога с весами
        string pathFileWeights; //путь к файлу с весами
        protected int numOfNeuron;
        protected int numOfPervNeuton;
        protected const double learningRade  = 0.5;
        protected const double momentum = 0.5d;
        protected double[,] lastDeltaWaights;
        private Neuron[] neurons;
        

        public Neuron[] Neurons
        {
            get => neurons;
            set => neurons = value;
        }

        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; i++) { 
                    Neurons[i].Inputs = value;
                    Neurons[i].Activator(Neurons[i].Inputs, Neurons[i].Weights);
                }
            }
        }

        public double[,] WeightsInitialize(MemoryMode mm, string path)
        {
            char[] delim = new char[] { ';', ' ', '-' };
            string tmpStr; //временная строка для чтения
            string[] tmpStrWeights; //Временная строка 
            double[,] weights = new double[numOfNeuron, numOfPervNeuton + 1];


            switch (mm) 
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memoryElement;
                    for(int i = 0; i < numOfNeuron; ++i)
                    {
                        memoryElement = tmpStrWeights[i].Split(delim);
                        for (int j = 0; j < numOfPervNeuton + 1; ++j)
                        {
                            weights[i, j] = double.Parse(memoryElement[j].Replace(',' , '.'),System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
                case MemoryMode.SET:
                    break;
                case MemoryMode.INIT:
                    /*
                     * Инициализация случайными числами
                     * Среднее значение или мат ожидание весов должно равнятся нулю
                     * Средне квадратическое откланение всех весов каждого нейрона должно равнятся еденице
                     */

                    break;
            
            }

            return weights;

        }

        protected Layer(int non, int nopn, TypeNeuron nt, string LName)
        {
            int i, j; //счётчики циклов
            numOfNeuron = non;
            numOfPervNeuton = nopn;
            Neurons = new Neuron[non];
            layerName = LName;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "momory\\";
            pathFileWeights = pathDirWeights + layerName + "memory.csv";

            double[,] Weights;

            if(File.Exists(pathFileWeights))
                Weights = WeightsInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathFileWeights);
                Weights = WeightsInitialize(MemoryMode.INIT, pathFileWeights);
            }

            lastDeltaWaights = new double[non, nopn + 1];

            for(i = 0; i < non; ++i)
            {
                double[] twp_weigths = new double[nopn + 1];
                for(j = 0; j < nopn; ++j)
                {
                    twp_weigths[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(twp_weigths, nt);
            }


        }

    }
}
