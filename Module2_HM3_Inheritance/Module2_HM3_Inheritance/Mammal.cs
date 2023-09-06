using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal class Mammal : Animal
    {
        public int HairLength { get; set; }
        public Mammal(string name, int age, int speed, int hairLength) : base(name, age, speed)
        {
            HairLength = hairLength;
        }

        public override void PrintAnimal()
        {
             Console.WriteLine($"Type: Mammal, Name: {Name}, Age: {Age}, Speed: {Speed}, Hair length: {HairLength}");
        }

    }
}
