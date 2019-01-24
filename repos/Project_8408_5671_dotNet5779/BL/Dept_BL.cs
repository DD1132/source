using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    internal class Dept_BL : IBL
    {
        private static DAL.Idal dal = DAL.FactorySingletonDal.getInstance();


        public bool AddTester(Tester tester)
        {
            if (DateTime.Now.Year - tester.DayOfBirth.Year < 40)
            {
                throw new Exception("tester under 40 years");
                //  return false;
            }
            try
            {
                dal.AddTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool RemoveTester(Tester tester)
        {
            try
            {
                dal.RemoveTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            try
            {
                dal.UpdateTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public bool AddTrainee(Trainee trainee)
        {
            if (DateTime.Now.Year - trainee.DayOfBirth.Year < 18)
            {
                throw new Exception("Trainee under 18 years");
            }
            if (trainee.LessonsNb < 20)
            {
                throw new Exception("Trainee does less then 20 lessons");
            }
            try
            {
                dal.AddTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool RemoveTrainee(Trainee trainee)
        {
            try
            {
                dal.RemoveTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            try
            {
                dal.UpdateTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public bool AddDrivingTest(DrivingTest drivingTest)
        {
            //האם הנבחן קיים במערכת
            Trainee currentTrainee = findTrainee(drivingTest.Trainee_ID);
            // עדכון פרטי הטסט
            drivingTest.carType = currentTrainee.CarTrained;
            drivingTest.StartingPoint = currentTrainee.Address.Clone();
            //עשה מספיק שיעורים
            if (currentTrainee.LessonsNb < Configuration.MIN_LESSONS_TO_REGISTER)
                throw new Exception("The trainee has not yet had 20 lessons");
            //בודק האם ישנם טסטים בעבר שעבר או שקיים לו כבר טסט עתידי או שהאחרון היה לפני פחות משבוע
            if (numOfTests(currentTrainee) > 0)
                TestsInThePast(currentTrainee);
            //האם יש בוחן זמין
            Tester currentTester = findTester(drivingTest.Tester_ID);
            if (currentTester == null)
                throw new Exception("There are no free tasters for this hour. Please create a new test for a different time");

            drivingTest.Tester_ID = currentTester.ID;

            //ADD
            try
            {
                dal.AddDrivingTest(drivingTest);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool RemoveDrivingTest(DrivingTest drivingTest) { return true; }
        public bool UpdateDrivingTest(DrivingTest drivingTest)
        {

            if (drivingTest.Comment == null)
            {
                throw new Exception("pls complite all the fields");
            }
            dal.UpdateDrivingTest(drivingTest);

            return true;
        }

        public List<Tester> GetTesters() { return dal.GetTesters(); }
        public List<Trainee> GetTrainees() { return dal.GetTrainees(); }
        public List<DrivingTest> GetDrivingTests() { return dal.GetDrivingTests(); }
        public Trainee findTrainee(string id)
        {
            foreach (Trainee item in DAL.FactorySingletonDal.getInstance().GetTrainees())
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            throw new Exception("trainee not exist");

        }

        public Tester findTester(string id)
        {
            foreach (Tester item in DAL.FactorySingletonDal.getInstance().GetTesters())
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            throw new Exception("Tester not exist");

        }

        public DrivingTest findDrivingTest(int number)
        {
            foreach (DrivingTest item in dal.GetDrivingTests())
            {
                if (item.TestNumber == number)
                {
                    return item;
                }
            }
            throw new Exception("Driving test not exist");

        }

        public List<DrivingTest> findTestForTester(string id)
        {
            IEnumerable<DrivingTest> result = from t in dal.GetDrivingTests()
                                              where t.Tester_ID == id
                                              select t;

            return result.ToList();

        }

        public List<DrivingTest> findTestForTrainee(string id)
        {
            IEnumerable<DrivingTest> result = from t in dal.GetDrivingTests()
                                              where t.Trainee_ID == id
                                              select t;

            return result.ToList();

        }

        public List<DrivingTest> findTestForTrainee(Trainee trainee)
        {
            IEnumerable<DrivingTest> result = from t in dal.GetDrivingTests()
                                              where t.Trainee_ID == trainee.ID
                                              select t;

            return result.ToList();

        }

        public int numOfAllTests(Trainee trainee)
        {
            return findTestForTrainee(trainee).Count();
        }

        public bool SameWeek(DateTime date1, DateTime date2)
        {
            return date1.AddDays(-(int)date1.DayOfWeek).AddHours(-date1.Hour) ==
                date2.AddDays(-(int)date2.DayOfWeek).AddHours(-date2.Hour);
        }//v++

        public List<Tester> availableTesters(DateTime dateTime)
        {
            List<Tester> freeTesters = new List<Tester>();
            foreach (Tester item in GetTesters())
            {
                int temp = dateTime.Hour;
                int temp1 = (int)dateTime.DayOfWeek;
                if (item.Luz.Data[temp1][temp] == true)
                {
                    foreach (DrivingTest x in findTestForTester(item.ID))
                    {
                        if (x.Date != dateTime)
                        {
                            freeTesters.Add(item);
                        }
                    }
                }
            }
            return freeTesters;

        }

        public delegate bool testsFilter(DrivingTest drivingTest);

        public int numPastedTests(string id)
        {
            List<DrivingTest> result = findTestForTrainee(id);
            int counter = 0;
            foreach (DrivingTest item in result)
            {
                if (item.Comment != null)
                {
                    counter++;
                }
            }
            return counter;
        }
        bool ownL(Trainee trainee)
        {
            List<DrivingTest> result = findTestForTrainee(trainee.ID);

            foreach (DrivingTest item in result)
            {
                if (item.Success)
                {
                    return true;
                }
            }
            return false;
        }
        public List<DrivingTest> testsInSameDay(DateTime d)
        {
            List<DrivingTest> result = new List<DrivingTest>();
            foreach (DrivingTest item in GetDrivingTests())
            {
                if (item.Date.Day == d.Day && item.Date.Month == d.Month)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        IEnumerable<IGrouping<CarType, Tester>> groupByExpertise(bool sorted = false)
        {
            if (!sorted)
            {
                var v1 = from Tester in GetTesters()
                         group Tester by Tester.Expertise;
                return v1;
            }
            var v2 = from Tester in GetTesters()
                     orderby Tester.ID
                     group Tester by Tester.Expertise;
            return v2;
        }
        IEnumerable<IGrouping<string, Trainee>> groupByDrivingSchool(bool sorted = false)
        {
            if (!sorted)
            {
                var v1 = from Trainee in GetTrainees()
                         group Trainee by Trainee.DrivingSchool;
                return v1;
            }
            var v2 = from Trainee in GetTrainees()
                     orderby Trainee.ID
                     group Trainee by Trainee.DrivingSchool;
            return v2;
        }
        IEnumerable<IGrouping<Name, Trainee>> groupByInstructor(bool sorted = false)
        {
            if (!sorted)
            {
                var v1 = from Trainee in GetTrainees()
                         group Trainee by Trainee.Instructor;
                return v1;
            }
            var v2 = from Trainee in GetTrainees()
                     orderby Trainee.ID
                     group Trainee by Trainee.Instructor;
            return v2;
        }

        IEnumerable<IGrouping<int, Trainee>> groupByNumOfTests(bool sorted = false)
        {
            if (!sorted)
            {
                var v1 = from Trainee in GetTrainees()
                         group Trainee by numPastedTests(Trainee.ID);
                return v1;
            }
            var v2 = from Trainee in GetTrainees()
                     orderby Trainee.ID
                     group Trainee by numPastedTests(Trainee.ID);
            return v2;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public List<Tester> nearByTesters(Address address)
        {
            throw new NotImplementedException();
        }

        bool IBL.ownL(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Trainee>> traineesByNumOfTests(bool sorted = false)
        {
            if (!sorted)
            {
                var v1 = from trainee in dal.GetTrainees()
                         group trainee by numOfAllTests(trainee);
                return v1;
            }
            var v2 = from trainee in dal.GetTrainees()
                     orderby trainee.ID, trainee.Gender
                     group trainee by numOfAllTests(trainee);
            return v2;
        }
        public int numOfTests(Trainee trainee)
        {
            return (dal.GetDrivingTests().Count(Test =>
            (Test.Trainee_ID == trainee.ID) && (Test.carType >= trainee.CarTrained)));
        }
        public void TestsInThePast(Trainee trainee)
        {
            List<DrivingTest> lastTestsList = new List<DrivingTest>();
            foreach (DrivingTest item in dal.GetDrivingTests())
            {
                if ((trainee.ID == item.Trainee_ID) && (trainee.CarTrained <= item.carType))
                {
                    if (item.Success)         //בדיקה האם עבר כבר טסט בסוג רכב זה
                        throw new Exception("Has already passed a test on this type of vehicle or better");

                    if (item.Date >= DateTime.Now)     //בדיקה האם יש לו טסט עתידי
                        throw new Exception("Has already have a test on this type of vehicle or better in the future");
                    lastTestsList.Add(item);
                }

            }
            var v = from DrivingTest item in lastTestsList
                    where (DateTime.Now - item.Date).Days < 7
                    select item;
            if (v.Any()) { throw new Exception("The trainee faild in a test in less then 7 days"); }

        }
    }
}

