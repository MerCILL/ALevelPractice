using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal class Animal : IAnimal, IComparable<Animal>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Speed { get; set; }

        public Animal(string name, int age, int speed)
        {
            Name = name;
            Age = age;
            Speed = speed;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("...");
        }

        public virtual void PrintAnimal()
        {
            Console.WriteLine($"Type: {this.GetType()}, Name: {Name}, Age: {Age}, Speed: {Speed}");
        }
        public int CompareTo(Animal animal)
        {
            //int typeComparison = this.GetType().Name.CompareTo(animal.GetType().Name);
            //if (typeComparison != 0) 
            //    return typeComparison;

            //return this.Speed.CompareTo(animal.Speed);

           //return this.GetType().Name.CompareTo(animal.GetType().Name) != 0 ? this.GetType().Name.CompareTo(animal.GetType().Name) : this.Speed.CompareTo(animal.Speed);

            return animal.Speed.CompareTo(this.Speed) != 0 ? animal.Speed.CompareTo(this.Speed) : animal.GetType().Name.CompareTo(this.GetType().Name);

        }
    }
    
}
