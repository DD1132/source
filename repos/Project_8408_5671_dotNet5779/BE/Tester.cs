using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Tester : Person
    {
        public Schedule Luz { get; set; }
        public CarType Expertise { get; set; }
        public int Experience { get; set; }
        public int MaxTestWeekly { get; set; }
        public int MaxDistance { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\n Expertise: " + Expertise.ToString() + " MaxTestWeekly: " + MaxTestWeekly +
                " MaxDistance: " + MaxDistance + "\nLuz:\n " + Luz.ToString();
        }

        public new Tester Clone()
        {
            Tester result = null;
            result = new Tester
            {
                Address = this.Address.Clone(),
                DayOfBirth = this.DayOfBirth,
                Expertise = this.Expertise,
                Gender = this.Gender,
                ID = this.ID,
                phoneNumber = this.phoneNumber,
                MaxDistance = this.MaxDistance,
                Name = this.Name,
                Experience = this.Experience,
                MaxTestWeekly = this.MaxTestWeekly,
                Luz = this.Luz//there was aclone here but we didnt do any!
            };
            return result;
        }
    }
}
