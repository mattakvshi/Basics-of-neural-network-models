using System;


namespace WindowsFormsApp1.src
{
    class NeuralNetwork
    {
        // Массив для хранения выходного сигнала нейросети
        public double[] fact = new double[10];

        //все слои нейросети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(72, 15, TypeNeuron.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(33, 72, TypeNeuron.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 33, TypeNeuron.Output, nameof(output_layer));

        //Среднее значение энергии ошибки эпохи обучения
        private double e_error_avg;

        public double E_error_avg
        {
            get => e_error_avg;
            set => e_error_avg = value;
        }

        public NeuralNetwork(NetworkMode nm) 
        {
            input_layer = new InputLayer(nm);
        }

        public void ForwardPass (NeuralNetwork net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }
    }
}