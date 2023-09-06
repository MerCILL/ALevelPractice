using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2_HM3_Inheritance
{
    internal class Dog : Canine, IBreedable
    {
        public string Breed { get; set; }
        public Dog(string name, int age, int speed, int hairLength, string breed) : base(name, age, speed, hairLength)
        {
            Breed = breed;
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Dog, Name: {Name}, Breed: {Breed} Age: {Age}, Speed: {Speed}, Hair length: {HairLength}");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }

    }
}
