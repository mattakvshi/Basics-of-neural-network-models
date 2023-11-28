using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.src;

namespace WindowsFormsApp1.src
{
    abstract class Layer
    {
        // поля
        protected string name_Layer;
        string pathDirWeights; // путь к каталогу 
        string pathFileWeights; // путь к файлу
        protected int numOfNeurons;
        protected int numOfPrevNeurons;
        protected const double learningRade = 0.5;
        protected const double momentum = 0.05d;
        protected double[,] lastdeltaweights;
        private Neuron[] neurons;
        

        // свойства
        public Neuron[] Neurons
        {
            get => neurons;
            set => neurons = value;
        }

        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; i++)
                {
                    Neurons[i].Inputs = value;
                    Neurons[i].Activator(Neurons[i].Inputs, Neurons[i].Weights);
                }
            }
        }

        protected Layer(int non, int nopn, TypeNeuron nt, string nm_layer)
        {
            int i, j; // счетчики циклов
            numOfNeurons = non;
            numOfPrevNeurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "memory.csv";

            double[,] Weights;

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            lastdeltaweights = new double[non, nopn + 1];

            for (i = 0; i < non; ++i)
            {
                double[] twp_weights = new double[nopn + 1];
                for (j = 0; j < nopn + 1; ++j)
                {
                    twp_weights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(twp_weights, nt);
            }
        }

        public double[,] WeightInitialize(MemoryMode mm, string path)
        {
            double[,] weights = new double[numOfNeurons, numOfPrevNeurons + 1];
            char[] delim = new char[] { ':', ' ' };
            string tmpStr = "";
            string[] tmpStrWeights;

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memory_element;
                    for (int i = 0; i < numOfNeurons + 1; ++i)
                    {
                        memory_element = tmpStrWeights[i].Split(delim);
                        for (int j = 0; j < numOfPrevNeurons + 1; ++j)
                        {
                            weights[i, j] = double.Parse(memory_element[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
                case MemoryMode.SET:
                    break;
                case MemoryMode.INIT:
                    // Дз написать инициализацию весов
                    /*
                     Инициализация ыесов
                    1) случайными значениями
                    2) средние значкние весов должно равняться нулю
                    3) средне квадротическое отклонение весов нейронов должно равняться единице
                    4) 
                    */
                    tmpStrWeights = new string[numOfNeurons]; // Инициализация tempStrWeights
                    Random random = new Random();
                    //заполнить случайными значениями
                    //среднее значение весов должно равняться 0 (считаем среднее значение,
                    // а потом от каждого его отнимаем)
                    //среднеквадратическое отклонение всех весов нейрона должно равняться 1
                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        tmpStr = ""; // Инициализация tempStr для каждой итерации
                        for (int j = 1; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpStr += delim[0] + weights[i, j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(path, tmpStrWeights);
                    break;
                default: break;
            }

            return weights;
        }
        
        abstract public void Recognize(NeuralNetwork net, Layer nextLayer); // Метод прямого прохода
        abstract public double [] BackwardPass(double[] staff); // Метод обратного прохода

            

    }
}
