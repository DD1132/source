using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Address
    {
        public String StreetName { get; set; }
        public int Number { get; set; }
        public String City { get; set; }
        //public int ZipCode { get; set; }

        public int CompareTo(Address other)
        {
            int r = City.CompareTo(other.City);
            if (r == 0)
            {
                r = StreetName.CompareTo(other.StreetName);
            }
            if (r == 0)
            {
                r = Number.CompareTo(other.Number);
            }
            return r;
        }


        public override string ToString()
        {    
            return StreetName + " " + Number + " " + "st." + City;
        }

        public Address Clone()
        {

            Address result = new Address
            {
                StreetName = this.StreetName,
                Number = this.Number,
                City = this.City
            };
            return result;
        }

    }
}
