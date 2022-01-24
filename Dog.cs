using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa
{
    class Dog : Animal
    {
        public String Sound = "Bark bark";
        public String Type = "Dog";
        public override string AnimalSound() //override abstract method from Animal
        {
            return Sound;
        }
        
        public Dog()
        {
           
        }
    }
}
