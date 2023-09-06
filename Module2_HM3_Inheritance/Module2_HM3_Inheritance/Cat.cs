using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal class Cat : Feline, IBreedable
    {
        public string Breed { get; set; }
        public Cat(string name, int age, int speed, int hairLength, int clawLength, string breed) : base(name, age, speed, hairLength, clawLength)
        {
            Breed = breed;
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Cat, Name: {Name}, Breed: {Breed} Age: {Age}, Speed: {Speed}, Hair length: {HairLength}, Claw length: {ClawLength}");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

    }
}
