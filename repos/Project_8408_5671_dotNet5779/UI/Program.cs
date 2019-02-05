using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace UI
{
    class Program
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        static void Main(string[] args)
        {
            try//הכנסת תלמיד עם בעיה S1
            {
                Console.WriteLine("The problem is that the trainee is young");
                bl.AddTrainee(new Trainee()
                {
                    ID = "S1",
                    Name = new Name { FirstName = "s1", LastName = "s1" },
                    Address = new Address
                    {
                        City = "s1",
                        Number = 1,
                        StreetName = "s1",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-15),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try// הכנסתתלמיד ללא בעיה S1
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S1",
                    Name = new Name { FirstName = "s1", LastName = "s1" },
                    Address = new Address
                    {
                        City = "s1",
                        Number = 1,
                        StreetName = "s1",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try//הכנסת תלמיד עם בעיה S2
            {
                Console.WriteLine("\n\nThe problem is that the trainee already exists in the system");
                bl.AddTrainee(new Trainee()
                {
                    ID = "S1",
                    Name = new Name { FirstName = "s2", LastName = "s2" },
                    Address = new Address
                    {
                        City = "s2",
                        Number = 2,
                        StreetName = "s2",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try//הכנסת תלמיד ללא בעיה S2
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S2",
                    Name = new Name { FirstName = "s2", LastName = "s2" },
                    Address = new Address
                    {
                        City = "s2",
                        Number = 2,
                        StreetName = "s2",


                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                Console.WriteLine("\n\nThe problem is that the trainee does less then the expacted lessons");
                bl.AddTrainee(new Trainee()
                {
                    ID = "S3",
                    Name = new Name { FirstName = "s3", LastName = "s3" },
                    Address = new Address
                    {
                        City = "s3",
                        Number = 3,
                        StreetName = "s3",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 19,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.FEMALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S4",
                    Name = new Name { FirstName = "s4", LastName = "s4" },
                    Address = new Address
                    {
                        City = "s4",
                        Number = 4,
                        StreetName = "s4",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S5",
                    Name = new Name { FirstName = "s5", LastName = "s5" },
                    Address = new Address
                    {
                        City = "s5",
                        Number = 5,
                        StreetName = "s5",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-18),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S6",
                    Name = new Name { FirstName = "s6", LastName = "s6" },
                    Address = new Address
                    {
                        City = "s6",
                        Number = 6,
                        StreetName = "s6",


                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-19),
                    Gender = Gender.FEMALE,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                bl.AddTrainee(new Trainee()
                {
                    ID = "S7",
                    Name = new Name { FirstName = "s7", LastName = "s7" },
                    Address = new Address
                    {
                        City = "s7",
                        Number = 7,
                        StreetName = "s7",

                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-20),
                    Gender = Gender.MALE,
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            /*****************************ADD TESTERS******************************************/
            try
            {
                Console.WriteLine("\nThe problem is that the tester is young");
                bl.AddTester(new Tester()
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

                    DayOfBirth = DateTime.Now.AddYears(-39),
                    Gender = Gender.MALE,
                    Experience = 10,
                    Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    MaxDistance = 1000,
                    MaxTestWeekly = 5,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                bl.AddTester(new Tester()
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
                    Expertise =  new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    MaxDistance = 1000,
                    MaxTestWeekly = 1,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //T2
            try
            {
                Console.WriteLine("\n\nThe problem is that the tester already exists in the system");
                bl.AddTester(new Tester()
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
                    Expertise =  new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    MaxDistance = 1000,
                    MaxTestWeekly = 5,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }

            try
            {
                bl.AddTester(new Tester()
                {
                    ID = "T2",
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
                    Expertise =  new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    MaxDistance = 1000,
                    MaxTestWeekly = 5,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                bl.AddTester(new Tester()
                {
                    ID = "T3",
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
                    MaxTestWeekly = 5,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                bl.AddTester(new Tester()
                {
                    ID = "T4",
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
                    MaxTestWeekly = 5,
                    Luz = new Schedule()
                    {
                        Data = new bool[5][] {
                                    new bool[6] { true, true,true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true},
                                    new bool[6] { true, true, true, true, true, true} }
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            //-------------------add tests--------------------
            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    
                    Trainee_ID = "S1",
                    Date = new DateTime(2018, 12, 10, 10, 0, 0),
                    Success = false,
                    
                   
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    
                    Trainee_ID = "S1",
                    Date = new DateTime(2018, 12, 8, 9, 0, 0),
                    Success = false,
                   
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }








            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {

                    Trainee_ID = "S1",
                    Date = new DateTime(2018, 12, 26, 9, 0, 0),
                    Success = false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                bl.UpdateTrainee(new Trainee()
                {
                    ID = "S1",
                    Name = new Name { FirstName = "s1", LastName = "s1" },
                    Address = new Address
                    {
                        City = "s1",
                        Number = 1,
                        StreetName = "s1",


                    },
                    phoneNumber = "0542520196",
                    CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                    DrivingSchool = "beit sefer",
                    Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                    LessonsNb = 20,
                    DayOfBirth = DateTime.Now.AddYears(-17),
                    Gender = Gender.MALE,
                });
            }
            catch (Exception e)
            { Console.WriteLine(e); }


            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    requirements = new Requirements(),
                    StartingPoint = new Address(),
                    Trainee_ID = "S3",
                    Date = new DateTime(2018, 12, 17, 9, 0, 0),
                    Success = false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    requirements = new Requirements(),
                    StartingPoint = new Address(),
                    Trainee_ID = "S4",
                    Date = new DateTime(2018, 12, 30, 9, 0, 0),
                    Success = false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    requirements = new Requirements(),
                    StartingPoint = new Address(),

                    Trainee_ID = "S5",
                    Date = new DateTime(2018, 12, 30, 9, 0, 0),
                    Success = false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                bl.AddDrivingTest(new DrivingTest()
                {
                    requirements = new Requirements(),
                    StartingPoint = new Address(),
                    Trainee_ID = "S1",
                    Date = new DateTime(2018, 12, 30, 9, 0, 0),
                    Success = false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\n\n\n-----------------------\n\n\n");
            DrivingTest m1 = new DrivingTest
            {
                requirements = new Requirements(),
                StartingPoint = new Address(),

                Trainee_ID = "S7",
                Date = new DateTime(2018, 12, 27, 10, 0, 0),
                Success = false

            };

            try
            {
                bl.AddDrivingTest(m1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            m1.requirements.U_turn = true;
            m1.requirements.speed = true;
            m1.requirements.revers = true;
            m1.requirements.breks = true;
            m1.requirements.Mirrors = true;
            m1.requirements.blinks = true;
            try
            {
                bl.UpdateDrivingTest(m1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\n\n\n-----------------------\n\n\n");
            Console.WriteLine(m1.ToString());

            //Console.WriteLine("Trainees\n--------------------------------------\n");

            //foreach (Trainee item in bl.GetTrainees())
            //{
            //    Console.WriteLine(item.ToString());

            //}

            Console.WriteLine("\nTesters\n---------------------------------------\n");

            foreach (Tester item in bl.GetTesters())
            {
                Console.WriteLine(item.ToString());

            }

            Console.WriteLine("\nTests\n-----------------------------------------\n");
            foreach (DrivingTest item in bl.GetDrivingTests())
            {
                Console.WriteLine(item.ToString());


            }
            Console.WriteLine("\nupdate\n-----------------------------------------\n");
            foreach (var item in bl.traineesByNumOfTests(true))
            {
                Console.WriteLine(item.Key);
                foreach (var v in item)
                {
                    Console.WriteLine(v.ID + "\t" + v.Gender);
                }
            }
            ////Console.WriteLine("\nTests after update\n-----------------------------------------\n");
            ////Console.WriteLine("\nupdate tranee\n-----------------------------------------\n");
            ////Console.WriteLine("\ntranee after update\n-----------------------------------------\n");
            ////Console.WriteLine("\nTests after update\n-----------------------------------------\n");
            ////Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            ////Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            Console.WriteLine("hi");
            Console.ReadKey();



        }
    }
}