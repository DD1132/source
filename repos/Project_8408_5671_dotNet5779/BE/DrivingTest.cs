using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BE
{
    /// <summary>
    /// טסט
    /// </summary>
    public class DrivingTest
    {

        //need to do a clone!!!!!!!!!!!!!
        private DateTime _date;
        public int TestNumber { get; set; }
        public CarType carType { get; set; }
        //  private ArrayList _requirements = new ArrayList();
        /// <summary>
        /// get set the Trainee ID
        /// </summary>
        public String Trainee_ID { get; set; }
        /// <summary>
        /// get set the Tester ID
        /// </summary>
        public String Tester_ID { get; set; }

        public DateTime Date { get => _date.Date; set => _date = value.Date; }
        public TimeSpan Time { get => Date.TimeOfDay; set => _date.AddMilliseconds(value.TotalMilliseconds); }
        public Address StartingPoint { get; set; }
        private Requirements _requirements = new Requirements();
        public Requirements requirements { get => _requirements; set => _requirements = value; }
        public bool Success { get; set; }
        private String comment = " ";
        public String Comment { get=> comment; set=> comment=value; }


        public override string ToString()
        {
            string A = "";

            return "\ncode of test: " + TestNumber + "\ntrainee ID: " + Trainee_ID +
                " tester ID: " + Tester_ID + " date:  " + Date.ToString() + A +
                "\nstarting point: " + StartingPoint.ToString() +
                 requirements.ToString() +
                "\nsuccess: " + Success + " comment: " + Comment;
        }
        public DrivingTest Clone()  //amok 
        {
            return new DrivingTest
            {
                TestNumber = this.TestNumber,
                Tester_ID = this.Tester_ID,
                Trainee_ID = this.Trainee_ID,
                Date = this.Date,
                Comment = this.Comment,
                requirements = this.requirements.Clone(),

                StartingPoint = this.StartingPoint.Clone(),
                Success = this.Success,  
            };
        }
    }
}
