using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2_HM3_Inheritance
{
    internal class Lynx : Feline, IBreedable
    {
        public string Breed { get; set; }
        public Lynx(string name, int age, int speed, int hairLength, int clawLength, string breed) : base(name, age, speed, hairLength, clawLength)
        {
            Breed = breed;
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Lynx, Name: {Name}, Breed: {Breed} Age: {Age}, Speed: {Speed}, Hair length: {HairLength}, Claw length: {ClawLength}");
        }

        public new void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
