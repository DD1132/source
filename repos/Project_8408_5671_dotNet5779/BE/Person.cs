using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Person
    {
        public String ID { get; set; }
        public String phoneNumber { get; set; }
        public Name Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return "\nID: " + ID + "\nName: " + Name.ToString() + " DayOfBirth: " + DayOfBirth.ToString() +
                " Gender: " + Gender.ToString() + "\n" + Address.ToString() + " PhoneNumber: " + phoneNumber;
        }

        public virtual Person Clone()  //deep clone 
        {
            return new Person
            {
                ID = this.ID,
                phoneNumber = this.phoneNumber,
                Address = new Address
                {
                    City = this.Address.City,
                    Number = this.Address.Number,
                    StreetName = this.Address.StreetName//,
                    //ZipCode = this.Address.ZipCode
                },
                DayOfBirth = this.DayOfBirth,
                Gender = this.Gender,
                Name = this.Name
            };
        }

    }
}