using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
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
        public Tester findATester(DrivingTest test)
        {
            //עובר על כל הטסטרים מאותו סוג רכב ובודק האם הם זמינים
            var v = from t1 in TestersExpertise(test.carType)
                    from t2 in rangOfTesters(test.StartingPoint)
                    where t1.ID == t2.ID
                    select t1;
            foreach (var item in v)
            {
                if (AvailableTester(item, test.Date))
                {
                    return item;
                }
            }
            // if there is no free tester
            TimeExchangeForTest(test);
            return null;
        }
        public List<Tester> TestersExpertise(CarType carType)
        {
            var v = from tester in dal.GetTesters()
                    group tester by tester.Expertise == carType;

            List<Tester> newList = new List<Tester>();
            foreach (var item in v)
            {
                if (item.Key)
                {
                    foreach (Tester item1 in item)
                        newList.Add(item1);
                }
            }
            return newList;
        }
        public List<Tester> rangOfTesters(Address address)
        {
            Random X = new Random();
            List<Tester> testersByRange = new List<Tester>();
            var rangGroup = from tester in dal.GetTesters()
                            group tester by tester.MaxDistance > getRange(tester.Address.ToString(), address.ToString())/* X.Next(0,100) */into g
                            select new { corect = g.Key, testers = g };
            foreach (var item in rangGroup)
            {
                if (item.corect)
                {
                    foreach (var tester in item.testers)
                        testersByRange.Add(tester);
                }
            }
            return testersByRange;
        }
        public int getRange(string origin, string destination)
        {
            Random X = new Random();//for error occurreds
            string KEY = @"xFdAUGGj5faNqCt7LbMsHqEaSv26ikUb";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                //Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);
                return (int)(distInMiles * 1.609344);
                //display the returned driving time
                //XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                //string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //Console.WriteLine("Driving Time: " + fTime);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                return X.Next(0, 300);
                //Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
            }
            else //busy network or other error...
            {
                return X.Next(0, 300);
                //Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
            }
        }
        public bool AvailableTester(Tester tester, DateTime Date)
        {
            //האם הטסטר עובד
            if (tester.Luz.Data[(int)Date.DayOfWeek][Date.Hour - 9] == false)
            {
                return false;
            }
            //האם כבר יש לו טסט באותו שעה
            var v = from t in dal.GetDrivingTests()
                    where t.Tester_ID == tester.ID && SameWeek(t.Date, Date)
                    // orderby t.Date==Date
                    select t;
            foreach (var item in v)
            {
                if (item.Date == Date)
                {
                    return false;
                }
            }
            //האם עבר את כמות הטסטים המותרת באותו שבוע
            if (v.Count() >= tester.MaxTestWeekly)
            {
                return false;
            }
            return true;
        }
        public void TimeExchangeForTest(DrivingTest test)
        {
            Console.WriteLine("at " + test.Date.Hour + " o'clock there is no free tester." +
                "If you want there are free testers at:");
            test.Date = test.Date.AddHours(9 - test.Date.Hour);
            for (int i = 0; i < 6; i++)
            {
                if (findIfATester(test))
                {
                    Console.WriteLine(test.Date.Hour + ":00");
                }
                test.Date = test.Date.AddHours(1);
            }
        }
        public bool findIfATester(DrivingTest test)
        {
            var v = from t1 in TestersExpertise(test.carType)
                    from t2 in rangOfTesters(test.StartingPoint)
                    where t1.ID == t2.ID
                    select t1;
            foreach (var item in v)
            {
                if (AvailableTester(item, test.Date))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

