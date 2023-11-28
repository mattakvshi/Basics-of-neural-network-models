using System;
using System.IO;

namespace WindowsFormsApp1.src
{
    class InputLayer
    {
        private Random random = new Random();

        //Поля
        private (double[], int)[] trainSet = new (double[], int)[100];

        public (double[], int)[] TrainSet { get { return trainSet; } }

        public InputLayer(NetworkMode nm)
        {

        }
    }
}
