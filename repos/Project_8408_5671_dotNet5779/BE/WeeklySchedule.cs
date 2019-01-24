using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class WeeklySchedule : IEnumerable<DayHours>
    {
        public DayHours[] Yomit { get; private set; }
        public IEnumerator<DayHours> GetEnumerator()
        {
            foreach (var item in Yomit)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public WeeklySchedule()
        {
            Yomit = new DayHours[5];
            for (int i = 0; i < 5; i++)
            {
                Yomit[i].Day = (Day)i;
                Yomit[i].Hours = new bool[6];
            }
        }
    }
}