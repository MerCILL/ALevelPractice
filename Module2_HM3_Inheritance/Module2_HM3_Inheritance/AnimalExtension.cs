using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM3_Inheritance
{
    internal static class AnimalExtension
    {
        //public static List<T> FilterByBreed<T>(this List<T> animals, string breed) where T : IBreedable
        //{
        //    return animals.Where(a => a.Breed == breed).ToList();
        //}
        public static List<Animal> FilterByBreed(this List<Animal> animals, string breed)
        {
            return animals.OfType<IBreedable>().Where(a => a.Breed == breed).Cast<Animal>().ToList();
        }


        public static List<T> FilterByName<T>(this List<T> animals, string name) where T: Animal
        {
            return animals.Where(a => a.Name == name).ToList();
        }

    }
}
