using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class Battery //task 1,2,3,4,5
    {
        #region constants
        private const int minIdle = 0;
        private const int maxIdle = 10000;

        private const int minTalk = 0;
        private const int maxTalk = 5000;
        #endregion

        #region fields
        private string model;


        private double? idleHours;
        private double? talkHours;
        private BatteryType batteryType;

        #endregion

        #region constructors
        public Battery(BatteryType batteryType) //task 3
        {
            this.BatteryType = batteryType;
            this.IdleHours = null;
            this.TalkHours = null;
        }

        public Battery(BatteryType batteryType , double idleHours , double talkHours) //task 3
        {
            this.BatteryType = batteryType;
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
        }
        #endregion

        #region properties

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

        public double? IdleHours
        {
            get { return idleHours; }
            set { idleHours = value; }
        }

        public double? TalkHours
        {
            get { return talkHours; }
            set { talkHours = value; }
        }

        public BatteryType BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        #endregion
    }
}
