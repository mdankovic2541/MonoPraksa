using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa
{
   public abstract class Animal : IAnimal
    {
        public int Age;
        public String Name;
        public String Type = "Cat"; //Value set for testing what will be printed out, this or value in class Dog
        public String Sound = "Mijau mijau";

        public Animal()
        {
        }

        public Animal(int age, string name, string type)
        {
            Age = age;
            this.Name = name;
            this.Type = type;
        }
        
        public void AnimalMessage(string message)
        {
            Console.WriteLine(message);
        }

        public abstract String AnimalSound();
        
    }
}
