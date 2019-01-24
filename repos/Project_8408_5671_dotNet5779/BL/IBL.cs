using System.Collections.Generic;
using BE;
using System;
using System.Linq;

namespace BL
{
    public interface IBL
    {
        bool AddDrivingTest(DrivingTest drivingTest);
        bool AddTester(Tester tester);
        bool AddTrainee(Trainee trainee);

        bool RemoveDrivingTest(DrivingTest drivingTest);
        bool RemoveTester(Tester tester);
        bool RemoveTrainee(Trainee trainee);

        bool UpdateDrivingTest(DrivingTest drivingTest);
        bool UpdateTester(Tester tester);
        bool UpdateTrainee(Trainee trainee);

        List<DrivingTest> GetDrivingTests();
        List<Tester> GetTesters();
        List<Trainee> GetTrainees();
        IEnumerable<Person> GetAllPersons();


        List<Tester> nearByTesters(Address address);
        List<Tester> availableTesters(DateTime dateTime);
        List<DrivingTest> findTestForTrainee(Trainee trainee);
        bool ownL(Trainee trainee);
        List<DrivingTest> testsInSameDay(DateTime d);
        int numOfAllTests(Trainee trainee);
        IEnumerable<IGrouping<int, Trainee>> traineesByNumOfTests(bool sorted = false);
    }
}