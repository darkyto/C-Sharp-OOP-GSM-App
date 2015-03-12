using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{
    public enum BatteryType // task 3 ( Enumeration)
    {
        LiIon,
        LiPol,
        LiFe,
        LiS,
        LiTi,
        ZnBr,
        NiMH,
        NiCd,
        Atomic,
        Alkaline,
        Potato
    }

    public class Battery
    {
        // *** Fields *** \\ task 1,2,3,4,5,
        private const int minIdle = 1;
        private const int maxIdle = 10000; // declaring some constants (if later we must change it it will happeen here globbally)

        private const int minTalk = 1;
        private const int maxTalk = 10000;

        private string model;
        private double? idleHours;
        private double? talkHours;
        private BatteryType batteryType; // task 3 - Enumeration

        // *** Constructors  *** \\
        public Battery(BatteryType batteryType) // task 3
        {
            this.BatteryType = batteryType;
            this.idleHours = null;
            this.talkHours = null;
        }

        // *** Properties *** \\
        public double? Talk
        {
            get { return talkHours; }
            set
            {
                if (value >= minTalk && value <= maxTalk)
                {
                    talkHours = value;
                }
                else
                {
                    throw new Exception("Value for 'talk duration' must be a positive integer within 1 and 10000");
                }
            }
        }

        public double? Idle
        {
            get { return idleHours; }
            set
            {
                if (value >= minIdle && value <= maxIdle)
                {
                    idleHours = value;
                }
                else
                {
                    throw new Exception(string.Format("Value for 'talk duration' must be a positive integer within {0} and {1}", minIdle, maxIdle));
                }
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (value != null || value.Length > 1)
                {
                    model = value;
                }
                else
                {
                    throw new Exception("Model name must contain at least two symbols!");
                }

            }
        }

        public BatteryType BatteryType // task 3
        {
            get { return batteryType; }
            set { batteryType = value; }
        }
    }
}
