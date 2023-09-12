using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }
        int Speed { get; set; }
        void PrintAnimal();
        void MakeSound();
    }
}
