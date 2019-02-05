using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CarType
    {
        public carType carType { get; set; }
        public GearType gearType { get; set; }
        public CarType Clone()
        {
            CarType result = new CarType
            {
                carType = this.carType,
                gearType = this.gearType
            };
            return result;
        }
        public static bool operator <=(CarType carType1, CarType carType2)
        {
            if (carType1.carType < carType2.carType)
                return true;
            if (carType1.carType == carType2.carType && carType1.gearType <= carType2.gearType)
                return true;
            return false;
        }
        public static bool operator >=(CarType carType1, CarType carType2)
        {
            if (carType1.carType > carType2.carType)
                return true;
            if (carType1.carType == carType2.carType && carType1.gearType >= carType2.gearType)
                return true;
            return false;
        }
        public static bool operator ==(CarType carType1, CarType carType2)
        {
            if (carType1.carType == carType2.carType && carType1.gearType == carType2.gearType)
                return true;
            return false;
        }
        public static bool operator !=(CarType carType1, CarType carType2)
        {
            if (carType1.carType != carType2.carType || carType1.gearType != carType2.gearType)
                return true;
            return false;
        }
        public override string ToString()
        {
            return carType.ToString() + " " + gearType.ToString();
        }

    }
}
