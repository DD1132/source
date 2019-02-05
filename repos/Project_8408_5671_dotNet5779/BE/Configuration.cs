using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        //, , גיל נבחן  מינימלי, טווח זמן בין מבחן למבחן
        public static int MIN_LESSONS = 28; //מספר השיעורים המינימלי
        public static int MAX_TESTER_AGE = 99;
        public static int MIN_TRAINEE_AGE = 16;
        public static int MIN_GAP_TEST = 30;
        public static int MIN_LESSONS_TO_REGISTER = 20;
        public static int Test_Number = 1000000;
    }
}
