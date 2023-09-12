using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal class Feline : Mammal
    {
        public int ClawLength { get; set; }
        public Feline(string name, int age, int speed, int hairLength, int clawLength) : base(name, age, speed, hairLength)
        {
            ClawLength = clawLength;
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Feline, Name: {Name}, Age: {Age}, Speed: {Speed}, Hair length: {HairLength}, Claw length: {ClawLength}");
        }
    }

}
