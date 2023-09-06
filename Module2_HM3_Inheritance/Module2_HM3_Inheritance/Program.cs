using Module2_HM3_Inheritance;

List<Animal> animals = new List<Animal>();

animals.Add(new Dog("Bulldog", 5, 30, 10, "English bulldog"));
animals.Add(new Dog("Chihuahua", 5, 30, 10, "Chihuahua"));
animals.Add(new Wolf("Polar", 6, 35, 15, "Polar wolf"));
animals.Add(new Wolf("Red", 7, 40, 16, "Red wolf"));
animals.Add(new Cat("Bengal1", 3, 15, 5, 3, "Bengal"));
animals.Add(new Cat("Bengal2", 4, 20, 6, 4, "Bengal"));
animals.Add(new Lynx("Lynx1", 5, 30, 12, 5, "Lynx"));
animals.Add(new Lynx("Lynx2", 6, 32, 13, 6, "Lynx"));

foreach (var item in animals)
{
    item.PrintAnimal();
}

Console.WriteLine(new string('-', 20));

var animalsByName = animals.ToList();
var animalsByBreed = animals.ToList();

animalsByName = AnimalExtension.FilterByName(animals, "Red");
foreach (var item in animalsByName)
{
    item.PrintAnimal();
}

Console.WriteLine(new string('-', 20));

animalsByBreed = AnimalExtension.FilterByBreed(animals, "Bengal");
foreach (var item in animalsByBreed)
{
    item.PrintAnimal();
}

Console.WriteLine(new string('-', 20));

animals.Sort();
Console.WriteLine("Sorted: ");
foreach (var item in animals)
{
    item.PrintAnimal();
}
