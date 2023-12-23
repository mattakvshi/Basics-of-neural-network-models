using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.src
{
    enum TypeNeuron  // тип нейрона
    { 
        Hidden, 
        Output
    }
    enum MemoryMode 
    {
        GET,
        SET,
        INIT
    }
    enum NetworkMode  // режимы работы нейронки
    { 
        Train,  
        Test,
        Recognize
    }
}
