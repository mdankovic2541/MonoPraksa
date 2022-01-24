using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa
{
   public class Person
    {
        public int Age;
        public String FirstName;
        public string LastName;
        public String IDNumber;
        private string JMBG;
        public Animal animal; // Person has an animal (pet animal) so that we can test creating an object
       

        public Person()
        {
            
        }

        public Person(int age, string firstName, string lastName, string iDNumber)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iDNumber;
        }

        public Person(int age, string firstName, string lastName, String iDNumber, string JMBG)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iDNumber;
            this.JMBG = JMBG;
        }

        public Person(string firstName, string lastName, String iDNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iDNumber;
        }

        

    }
}
