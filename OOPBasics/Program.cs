using System;
using System.Collections.Generic;

namespace Praksa
{
    class Program : Person
    {
        static void Main(string[] args)
        {
            Person person = new Person(20,"Marko","Danković","12345678910","1111111");
            person.animal = new Dog(); //Create a new animal type Dog from class Person

            Console.WriteLine("------------------------------------------");
            person.animal.Name = "Ari";
            Console.WriteLine("Name of the dog: " + person.animal.Name);

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
            Console.WriteLine("Age: " + person.Age);
            Console.WriteLine("ID Number: " + person.IDNumber);
            Console.WriteLine("------------------------------------------");
            //Console.WriteLine("JMBG: " + person.JMBG); JMBG can't be printed out since it is a private atribute
            //Animal animal = new Animal(4, "Rita", "Dog"); Cannot create object of an abstract class
            Dog dog = new Dog();
            dog.Name = "Max";
            dog.Age = 3;
            Console.WriteLine("Animal: " + dog.Type);
            Console.WriteLine("Name: " + dog.Name);
            Console.WriteLine("Age: " + dog.Age);
            Console.WriteLine("Sound: " + dog.Sound);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Dog name length: " + dog.Name.Length); // Name of the dog is reference type, we can use methods built in methods

            Console.WriteLine("------------------------------------------");
            dog.AnimalMessage("This is a new message from your dog!");

            Console.WriteLine("------------------------------------------");
            AnimalShelter<string> shelter = new AnimalShelter<string>();
            shelter.name = "ZooCity";
            Console.WriteLine(shelter.name + "\nName length: " + shelter.name.Length);
            AnimalShelter<int> NumberOfShelter = new AnimalShelter<int>();
            NumberOfShelter.name = 32;
            Console.WriteLine("Number of shelter:" + NumberOfShelter.name);
            Console.WriteLine("------------------------------------------");

            //learning about dictionary
            var cities = new Dictionary<string, string>()
            {
                {"CRO", "Zagreb"},
                {"GER","Berlin"},
                {"USA","Washington"},
                {"FRA","Paris"}
            };
            foreach(var city in cities)
            {
                Console.WriteLine("Country: {0}  Capital city: {1}", city.Key, city.Value);
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}
