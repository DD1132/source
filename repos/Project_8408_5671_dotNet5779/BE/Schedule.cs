using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Schedule
    {

        public bool[][] Data = new bool[5][];

        public Schedule()
        {
            for (int i = 0; i < 5; i++)
            {
                Data[i] = new bool[6];
            }
        }

        public Schedule(bool[][] data)
        {
            this.Data = data;
        }

        public Schedule Clone()
        {
            Schedule result = new Schedule((bool[][])this.Data.Clone());
            return result;
        }
        public override string ToString()
        {
            int starttime = 9;
            bool oved = false;
            string result = null;
            string hayom = null;
            for (int i = 0; i < 5; i++)
            {
                oved = false;
                hayom = null;

                for (int j = 0; j < 6; j++)
                {
                    if (Data[i][j] == true)
                    {
                        oved = true;
                        hayom += "\t" + (starttime + j) + ":00-";
                        hayom += (starttime + j + 1).ToString() + ":00\n";
                    }
                }
                if (oved == true)
                {
                    result += ((Day)i).ToString() + "\n";
                    result += hayom;
                }
            }
            if (result == null)
                return "";
            return result.Substring(0, result.Length - 1);

        }
    }
}