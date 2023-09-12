using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal class Canine : Mammal
    { 
        public Canine(string name, int age, int speed, int hairLength) : base(name, age, speed, hairLength)
        {
            
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Canine, Name: {Name}, Age: {Age}, Speed: {Speed}, Hair length: {HairLength}");
        }

    }
}
