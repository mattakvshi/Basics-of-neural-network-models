using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_sidorenko_gpt5.NeuronFramework
{
    enum MemoryMode // режимы работы памяти
    {
        GET,
        SET,
        INIT
    }
    enum TypeNeuron // тип нейрона
    { 
        Hidden, 
        Output 
    } 

    enum NetworkMode  // режимы работы нейросети
    {
        Train,
        Test,
        Demo
    }
}
