using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Name
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FirstName.ToString() + " LastName: " + LastName.ToString();

        }
    }
}
