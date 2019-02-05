using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Trainee : Person
    {
        public CarType CarTrained { get; set; }
        public String DrivingSchool { get; set; }
        public Name Instructor { get; set; }
        public int LessonsNb { get; set; }  //new balance of lessons number

        public new Trainee Clone()
        {
            Trainee result = null;
            result = new Trainee
            {
                Address = this.Address.Clone(),
                DayOfBirth = this.DayOfBirth,
                CarTrained = this.CarTrained,
                DrivingSchool = this.DrivingSchool,
                Instructor = this.Instructor,
                LessonsNb = this.LessonsNb,
                Gender = this.Gender,
                ID = this.ID,
                phoneNumber = this.phoneNumber,
                Name = this.Name,
            };
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + " \nCarTrained: " + CarTrained.ToString()
                + " DrivingSchool: " + DrivingSchool +
               "Instructor: " + Instructor.ToString() + " LessonsNb: " + LessonsNb + "\n";
        }

    }
}
