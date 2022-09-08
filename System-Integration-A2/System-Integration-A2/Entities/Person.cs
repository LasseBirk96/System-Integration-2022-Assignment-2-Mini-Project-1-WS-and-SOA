using System;
namespace System_Integration_A2.Entities
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }

        public Person(string Name, string Email, string IP)
        {
            this.Name = Name;
            this.Email = Email;
            this.IP = IP;
        }


        public string ReturnPerson()
        {
            return this.Name +  this.Email + this.IP;

        }
    }
}

