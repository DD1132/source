//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BE;


//namespace DAL
//{
//    internal class Dal_imp : Idal
//    {
//    //    public bool AddDrivingTest(DrivingTest drivingTest)
//    //    {
//    //        DS.DataSource.DrivingtestsList.Add(drivingTest.Clone());
//    //        return true;
//    //    }

//    //    public bool AddTester(Tester tester)
//    //    {
//    //        foreach (Tester item in DS.DataSource.TestersList)
//    //        {
//    //            if (item.ID == tester.ID)
//    //            {
//    //                throw new Exception("Tester already exist");
//    //                return false;
//    //            }
//    //        }
//    //        DS.DataSource.TestersList.Add(tester.Clone());
//    //        return true;
//    //    }

//    //    public bool AddTrainee(Trainee trainee)
//    //    {
//    //        foreach (Trainee item in DS.DataSource.TraineesList)
//    //        {
//    //            if (item.ID == trainee.ID)
//    //            {
//    //                throw new Exception("Trainee already exist");
//    //                return false;
//    //            }
//    //        }
//    //        DS.DataSource.TraineesList.Add(trainee.Clone());
//    //        return true;
//    //    }

//    //    public List<DrivingTest> GetDrivingTests()
//    //    {
//    //        List<DrivingTest> result = new List<DrivingTest>();
//    //        foreach (DrivingTest item in DS.DataSource.DrivingtestsList)
//    //        {
//    //            result.Add(item.Clone());
//    //        }
//    //        return result;
//    //    }



//    //    public List<Tester> GetTesters()
//    //    {
//    //        List<Tester> result = new List<Tester>();
//    //        foreach (Tester item in DS.DataSource.TestersList)
//    //        {
//    //            result.Add(item.Clone());
//    //        }
//    //        return result;
//    //    }

//    //    public List<Trainee> GetTrainees()
//    //    {
//    //        List<Trainee> result = new List<Trainee>();
//    //        foreach (Trainee item in DS.DataSource.TraineesList)
//    //        {
//    //            result.Add(item.Clone());
//    //        }
//    //        return result;
//    //    }

//    //    public bool RemoveDrivingTest(DrivingTest drivingTest)
//    //    {
//    //        foreach (DrivingTest item in DS.DataSource.DrivingtestsList)
//    //        {
//    //            if (item == drivingTest)
//    //            {
//    //                DS.DataSource.DrivingtestsList.Remove(item);
//    //                return true;
//    //            }
//    //        };
//    //        throw new Exception("drivingTest is not exist");
//    //    }

//    //    public bool RemoveTester(Tester tester)
//    //    {
//    //        foreach (Tester item in DS.DataSource.TestersList)
//    //        {
//    //            if (item == tester)
//    //            {
//    //                DS.DataSource.TestersList.Remove(item);
//    //                return true;
//    //            }
//    //        };
//    //        throw new Exception("tester is not exist");
//    //    }

//    //    public bool RemoveTrainee(Trainee trainee)
//    //    {
//    //        foreach (Trainee item in DS.DataSource.TraineesList)
//    //        {
//    //            if (item == trainee)
//    //            {
//    //                DS.DataSource.TraineesList.Remove(item);
//    //                return true;
//    //            }
//    //        };
//    //        throw new Exception("trainee is not exist");
//    //    }

//    //    public bool UpdateDrivingTest(DrivingTest drivingTest)
//    //    {
//    //        foreach (DrivingTest item in DS.DataSource.DrivingtestsList)
//    //        {
//    //            if (item.TestNumber == drivingTest.TestNumber)
//    //            {
//    //                DS.DataSource.DrivingtestsList.Remove(item);
//    //                DS.DataSource.DrivingtestsList.Add(drivingTest);
//    //                return true;
//    //            }

//    //        }
//    //        throw new Exception("driving test is not exist");
//    //    }

//    //    public bool UpdateTester(Tester tester)
//    //    {
//    //        foreach (Tester item in DS.DataSource.TestersList)
//    //        {
//    //            if (item.ID == tester.ID)
//    //            {
//    //                DS.DataSource.TestersList.Remove(item);
//    //                DS.DataSource.TestersList.Add(tester);
//    //                return true;
//    //            }

//    //        }
//    //        throw new Exception("Tester is not exist");
//    //    }

//    //    public bool UpdateTrainee(Trainee trainee)
//    //    {
//    //        foreach (Trainee item in DS.DataSource.TraineesList)
//    //        {
//    //            if (item.ID == trainee.ID)
//    //            {
//    //                DS.DataSource.TraineesList.Remove(item);
//    //                DS.DataSource.TraineesList.Add(trainee);
//    //                return true;
//    //            }

//    //        }
//    //        throw new Exception("Trainee is not exist");
//    //    }
//    }

//}


