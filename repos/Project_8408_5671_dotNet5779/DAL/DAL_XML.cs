using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace DAL
{
    public class DAL_XML : Idal
    {
        public DAL_XML()
        {
            if (!File.Exists(traineePath))
                CreateFiles();
            else
                LoadData();
            
           

        }

        protected static DAL_XML dal;
        public static DAL_XML Dal
        {
            get
            {
                if (dal == null)
                    dal = new DAL_XML();
                return dal;
            }
        }


        XElement traineeRoot;
        string traineePath = @"traineeXml.xml";

        XElement testerRoot;
        string testerPath = @"testerXml.xml";

        XElement testRoot;
        string testPath = @"testXml.xml";


        private void CreateFiles()
        {
            traineeRoot = new XElement("trainees");
            traineeRoot.Save(traineePath);

            testerRoot = new XElement("testers");
            testerRoot.Save(testerPath);

            testRoot = new XElement("tests");
            testRoot.Save(testPath);

        }
        private void LoadData()
        {
            try
            {
                traineeRoot = XElement.Load(traineePath);
                testerRoot = XElement.Load(testerPath);
                testRoot = XElement.Load(testPath);

               
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }



        //A.R.U.D tester
        BE.Schedule converterSchedule(XElement xElement)
        {
            Schedule schedule = new Schedule();
            Day day = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    schedule.Data[i][j] = bool.Parse(xElement.Element("Luz").Element(day.ToString()).Element("hour" + j.ToString()).Value);
                }
                day++;
            }
            return schedule;
        }
        XElement converterSchedule(BE.Schedule schedule)
        {
            Day day = 0;
            XElement xElement = new XElement("Luz");
            for (int i = 0; i < 5; i++)
            {
                XElement xElementDay = new XElement(day.ToString());
                for (int j = 0; j < 6; j++)
                {
                    xElementDay.Add(new XElement("hour" + j.ToString(), schedule.Data[i][j].ToString()));
                }
                xElement.Add(xElementDay);
                day++;
            }

            return xElement;
        }

        BE.Tester convertTester(XElement xElement)
        {
            Tester tester = new Tester() { Name = new Name(), Address = new Address(), Expertise = new CarType(), Luz = new Schedule() };
            tester.ID = xElement.Element("ID").Value;
            tester.Name.FirstName = xElement.Element("Name").Element("FirstName").Value;
            tester.Name.LastName = xElement.Element("Name").Element("LastName").Value;
            tester.DayOfBirth = DateTime.Parse(xElement.Element("DayOfBirth").Value);
            tester.Gender = (Gender)Enum.Parse(typeof(Gender), xElement.Element("Gender").Value);
            tester.Address.City = xElement.Element("Address").Element("City").Value;
            tester.Address.StreetName = xElement.Element("Address").Element("StreetName").Value;
            tester.Address.Number = int.Parse(xElement.Element("Address").Element("Number").Value);
            tester.phoneNumber = xElement.Element("PhoneNumber").Value;
            tester.Experience = int.Parse(xElement.Element("Experience").Value);
            tester.MaxTestWeekly = int.Parse(xElement.Element("MaxTestWeekly").Value);
            tester.MaxDistance = int.Parse(xElement.Element("MaxDistance").Value);
            tester.Expertise.carType = (carType)Enum.Parse(typeof(carType), xElement.Element("Expertise").Element("carType").Value);
            tester.Expertise.gearType = (GearType)Enum.Parse(typeof(GearType), xElement.Element("Expertise").Element("gearType").Value);
            tester.Luz = converterSchedule(xElement);
            return tester;
        }
        XElement convertTester(BE.Tester tester)
        {
            return new XElement("tester", new XElement("ID", tester.ID),
                                                           new XElement("Name", new XElement("FirstName", tester.Name.FirstName)
                                                                              , new XElement("LastName", tester.Name.LastName)),
                                                           new XElement("DayOfBirth", tester.DayOfBirth.ToString()),
                                                           new XElement("Gender", tester.Gender.ToString()),
                                                           new XElement("Address", new XElement("City", tester.Address.City),
                                                                                  new XElement("StreetName", tester.Address.StreetName),
                                                                                  new XElement("Number", tester.Address.Number.ToString())),
                                                           new XElement("PhoneNumber", tester.phoneNumber),
                                                           new XElement("Experience", tester.Experience),
                                                           new XElement("MaxTestWeekly", tester.MaxTestWeekly),
                                                           new XElement("MaxDistance", tester.MaxDistance),
                                                           new XElement("Expertise", new XElement("carType", tester.Expertise.carType.ToString()),
                                                                                     new XElement("gearType", tester.Expertise.gearType.ToString())),
                                                           new XElement(converterSchedule(tester.Luz))
                                                           );

        }

        public Tester getTester(string id)
        {
            XElement newTester = null;
            try
            {
                newTester = (from item in testerRoot.Elements()
                             where id == item.Element("ID").Value
                             select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (newTester == null)
                return null;
            return convertTester(newTester);
        }

        public List<Tester> GetTesters()
        {
            List<Tester> testers = new List<Tester>();
            testers = (from item in testerRoot.Elements()
                       select convertTester(item)).ToList();
            if (!testers.Any())
                throw new Exception("There is no testers in the database");
            return testers;
        }

        public bool AddTester(Tester tester)
        {
            Tester temp = getTester(tester.ID);
            if (temp != null)
            {
                throw new Exception("Tester already exist");
            }
            testerRoot.Add(convertTester(tester));
            testerRoot.Save(testerPath);
            return true;
        }

        public bool RemoveTester(Tester tester)
        {
            XElement temp_tester = null;
            temp_tester = (from item in testerRoot.Elements()
                           where tester.ID == item.Element("ID").Value
                           select item).FirstOrDefault();
            if (temp_tester == null)
                throw new Exception("The current tester is not in the database");
            temp_tester.Remove();
            testerRoot.Save(testerPath);

            return true;
        }

        public bool UpdateTester(Tester tester)
        {
            RemoveTester(tester);
            AddTester(tester);
            return true;
        }


        //A.R.U.D trainee
        BE.Trainee convertTrainee(XElement xElement)
        {
            Trainee trainee = new Trainee() { Name = new Name(), Address = new Address(), CarTrained = new CarType(), Instructor = new Name() };
            trainee.ID = xElement.Element("ID").Value;
            trainee.Name.FirstName = xElement.Element("Name").Element("FirstName").Value;
            trainee.Name.LastName = xElement.Element("Name").Element("LastName").Value;
            trainee.DayOfBirth = DateTime.Parse(xElement.Element("DayOfBirth").Value);
            trainee.Gender = (Gender)Enum.Parse(typeof(Gender), xElement.Element("Gender").Value);
            trainee.Address.City = xElement.Element("Address").Element("City").Value;
            trainee.Address.StreetName = xElement.Element("Address").Element("StreetName").Value;
            trainee.Address.Number = int.Parse(xElement.Element("Address").Element("Number").Value);
            trainee.phoneNumber = xElement.Element("PhoneNumber").Value;
            trainee.LessonsNb = int.Parse(xElement.Element("LessonsNb").Value);
            trainee.DrivingSchool = xElement.Element("DrivingSchool").Value;
            trainee.CarTrained.carType = (carType)Enum.Parse(typeof(carType), xElement.Element("CarTrained").Element("carType").Value);
            trainee.CarTrained.gearType = (GearType)Enum.Parse(typeof(GearType), xElement.Element("CarTrained").Element("gearType").Value);
            trainee.Instructor.FirstName = xElement.Element("Instructor").Element("FirstName").Value;
            trainee.Instructor.LastName = xElement.Element("Instructor").Element("LastName").Value;
            return trainee;

        }
        XElement convertTrainee(BE.Trainee trainee)
        {
            return new XElement("Trainee", new XElement("ID", trainee.ID),
                                                           new XElement("Name", new XElement("FirstName", trainee.Name.FirstName)
                                                                              , new XElement("LastName", trainee.Name.LastName)),
                                                           new XElement("DayOfBirth", trainee.DayOfBirth.ToString()),
                                                           new XElement("Gender", trainee.Gender.ToString()),
                                                           new XElement("Address", new XElement("City", trainee.Address.City),
                                                                                  new XElement("StreetName", trainee.Address.StreetName),
                                                                                  new XElement("Number", trainee.Address.Number.ToString())),
                                                           new XElement("PhoneNumber", trainee.phoneNumber),
                                                           new XElement("LessonsNb", trainee.LessonsNb),
                                                             new XElement("DrivingSchool", trainee.DrivingSchool),
                                                          new XElement("Instructor", new XElement("FirstName", trainee.Instructor.FirstName)
                                                                              , new XElement("LastName", trainee.Instructor.LastName)),
                                                           new XElement("CarTrained", new XElement("carType", trainee.CarTrained.carType.ToString()),
                                                                                     new XElement("gearType", trainee.CarTrained.gearType.ToString()))
                                                           );


        }
        public List<Trainee> GetTrainees()
        {
            List<Trainee> trainees = new List<Trainee>();
            trainees = (from item in traineeRoot.Elements()
                        select convertTrainee(item)).ToList();
            if (!trainees.Any())
                throw new Exception("There is no trainees in the database");
            return trainees;
        }
        public Trainee getTrainee(string id)
        {
            XElement newTrainee = null;
            try
            {
                newTrainee = (from item in traineeRoot.Elements()
                              where id == item.Element("ID").Value
                              select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (newTrainee == null)
                return null;
            return convertTrainee(newTrainee);
        }
        public bool AddTrainee(Trainee trainee)
        {
            Trainee temp = getTrainee(trainee.ID);
            if (temp != null)
            {
                throw new Exception("Trainee already exist");
            }
            traineeRoot.Add(convertTrainee(trainee));
            traineeRoot.Save(traineePath);
            return true;
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            XElement temp_trainee = null;
            temp_trainee = (from item in traineeRoot.Elements()
                            where trainee.ID == item.Element("ID").Value
                            select item).FirstOrDefault();
            if (temp_trainee == null)
                throw new Exception("The current trainee is not in the database");
            temp_trainee.Remove();
            traineeRoot.Save(traineePath);

            return true;
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            RemoveTrainee(trainee);
            AddTrainee(trainee);
            return true;
        }




        //A.R.U.D tests
        BE.DrivingTest convertTest(XElement xElement)
        {
            DrivingTest test = new DrivingTest() { requirements = new Requirements(), StartingPoint = new Address(), carType = new CarType() };
            test.TestNumber = int.Parse(xElement.Element("TestNumber").Value);
            test.Tester_ID = xElement.Element("Tester_ID").Value;
            test.Trainee_ID = xElement.Element("Trainee_ID").Value;
            test.Date = DateTime.Parse(xElement.Element("Date").Value);
            test.StartingPoint.City = xElement.Element("StartingPoint").Element("City").Value;
            test.StartingPoint.StreetName = xElement.Element("StartingPoint").Element("StreetName").Value;
            test.StartingPoint.Number = int.Parse(xElement.Element("StartingPoint").Element("Number").Value);
            test.Success = bool.Parse(xElement.Element("Success").Value);
            test.carType.carType = (carType)Enum.Parse(typeof(carType), xElement.Element("carType").Element("carType").Value);
            test.carType.gearType = (GearType)Enum.Parse(typeof(GearType), xElement.Element("carType").Element("gearType").Value);
            test.Comment = xElement.Element("Comment").Value;
            test.requirements.Mirrors = bool.Parse(xElement.Element("requirements").Element("Mirrors").Value);
            test.requirements.revers = bool.Parse(xElement.Element("requirements").Element("revers").Value);
            test.requirements.speed = bool.Parse(xElement.Element("requirements").Element("speed").Value);
            test.requirements.U_turn = bool.Parse(xElement.Element("requirements").Element("U_turn").Value);
            test.requirements.blinks = bool.Parse(xElement.Element("requirements").Element("blinks").Value);
            test.requirements.breks = bool.Parse(xElement.Element("requirements").Element("breks").Value);
            return test;

        }
        XElement convertTest(DrivingTest test)
        {
            return new XElement("Test",
                 new XElement("TestNumber", test.TestNumber),
                 new XElement("Tester_ID", test.Tester_ID),
                 new XElement("Trainee_ID", test.Trainee_ID),
                 new XElement("Date", test.Date.ToString()),
                 new XElement("StartingPoint", new XElement("City", test.StartingPoint.City),
                              new XElement("StreetName", test.StartingPoint.StreetName),
                              new XElement("Number", test.StartingPoint.Number.ToString())),
                 new XElement("carType", new XElement("carType", test.carType.carType.ToString()),
                              new XElement("gearType", test.carType.gearType.ToString())),
                 new XElement("Comment", test.Comment),
                 new XElement("Success", test.Success),
                 new XElement("requirements", new XElement("Mirrors", test.requirements.Mirrors)
                                 , new XElement("revers", test.requirements.revers)
                                 , new XElement("speed", test.requirements.speed)
                                 , new XElement("U_turn", test.requirements.U_turn)
                                 , new XElement("blinks", test.requirements.blinks)
                                 , new XElement("breks", test.requirements.breks)));
        }
        public List<DrivingTest> GetDrivingTests()
        {
            List<DrivingTest> tests = new List<DrivingTest>();
            tests = (from item in testRoot.Elements()
                     select convertTest(item)).ToList();
            if (!tests.Any())
                throw new Exception("There is no tests  in the database");
            return tests;
        }
        public DrivingTest GetTests(int cod)
        {
            XElement newTest = null;
            try
            {
                newTest = (from item in testRoot.Elements()
                           where cod == int.Parse(item.Element("codeOfTest").Value)
                           select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (newTest == null)
                return null;
            return convertTest(newTest);
        }
        public bool AddDrivingTest(DrivingTest drivingTest)
        {
            if (drivingTest.TestNumber == 0)
            {
                drivingTest.TestNumber = Configuration.Test_Number;
            }

            testRoot.Add(convertTest(drivingTest));
            testRoot.Save(testPath);
            return true;
        }

        public bool RemoveDrivingTest(DrivingTest drivingTest)
        {
            XElement temp_Test = null;
            temp_Test = (from item in testRoot.Elements()
                         where drivingTest.TestNumber== int.Parse(item.Element("codeOfTest").Value)
                         select item).FirstOrDefault();
            if (temp_Test == null)
                throw new Exception("The current drivingTest is not in the database");
            temp_Test.Remove();
            testRoot.Save(testPath);
            return true;
        }

        public bool UpdateDrivingTest(DrivingTest drivingTest)
        {
            RemoveDrivingTest(drivingTest);
            AddDrivingTest(drivingTest);
            return true;
        }
        public void init()
        {
            AddTrainee(new Trainee()
            {
                //    string origin = "pisga 45 st. jerusalem"; //or "תקווה פתח 100 העם אחד "etc.

                ID = "S1",
                Name = new Name { FirstName = "s1", LastName = "s1" },
                Address = new Address
                {
                    City = "jerusalem",
                    Number = 45,
                    StreetName = "pisga",

                },
                phoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 25,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            AddTrainee(new Trainee()
            {
                ID = "S2",
                Name = new Name { FirstName = "s2", LastName = "s2" },
                Address = new Address
                {
                    City = "jerusalem",
                    Number = 45,
                    StreetName = "pisga",

                },
                phoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 25,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            AddTrainee(new Trainee()
            {
                ID = "S3",
                Name = new Name { FirstName = "s3", LastName = "s3" },
                Address = new Address
                {
                    City = "jerusalem",
                    Number = 45,
                    StreetName = "pisga",

                },
                phoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 25,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });

            AddTester(new Tester()
            {
                ID = "T1",
                Name = new Name { FirstName = "jojo", LastName = "chalass" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 21,
                    StreetName = "havvad haleumi",
                },
                phoneNumber = "054999999",

                DayOfBirth = DateTime.Now.AddYears(-50),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 1000,
                MaxTestWeekly = 20,
                Luz = new Schedule(new bool[5][] {
                       new bool[6] { false, true,true, true, true, true},
                       new bool[6] { true, false, true, true, true, true},
                       new bool[6] { true, true, false, true, true, true},
                       new bool[6] { true, true, true, false, true, true},
                       new bool[6] { true, true, true, true, false, false } })
            });
            AddTester(new Tester()
            {
                //string destination = "gilgal 78 st. ramat-gan";//or "גן רמת 10 בוטינסקי'ז "etc.
                ID = "T2",
                Name = new Name { FirstName = "jojo", LastName = "chalass" },
                Address = new Address
                {
                    City = "ramat-gan",
                    Number = 78,
                    StreetName = "gilgal",
                },
                phoneNumber = "054999999",

                DayOfBirth = DateTime.Now.AddYears(-50),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 50,
                MaxTestWeekly = 20,
                Luz = new Schedule(new bool[5][] {
                        new bool[6] { true, true,true, true, true, true},
                        new bool[6] { true, true, true, true, true, true},
                        new bool[6] { true, true, true, true, true, true},
                        new bool[6] { true, true, true, true, true, true},
                        new bool[6] { true, true, true, true, true, true} })
            });

            AddDrivingTest(new DrivingTest()
            {
                Trainee_ID = "S1",
                Tester_ID = "T1",
                carType = new CarType() { carType = carType.Private, gearType = GearType.Automatic },
                TestNumber = 0,
                Date = new DateTime(3000, 01, 01),
                StartingPoint = new Address() { City = "s1", Number = 1, StreetName = "s1" },
            });
        }


    }
}
