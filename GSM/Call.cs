namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Call
    {
        #region fields

        private DateTime timeStamp;
        private int duration; //in seconds
        private string phoneDialed; //string for cases like ++359 and ect.

        #endregion

        #region constructors

        public Call(string phoneDialed, int duration, DateTime timeStamp) //task 8 - 12
        {
            this.PhoneDialed = phoneDialed;
            this.Duration = duration;
            this.TimeStamp = timeStamp;
        }

        #endregion

        #region properties

        public DateTime TimeStamp
        {
            get { return this.timeStamp; }
            set
            {
                this.timeStamp = value;
            }
        } // task 8-9

        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (duration >= 0)
                {
                    this.duration = value;
                }
                else
                {
                    throw new ArgumentException("Duration value can not be bnegative or NaN");
                }
            }
        } // task 8-9

        public string PhoneDialed
        {
            get { return this.phoneDialed; }
            set { this.phoneDialed = value; }
        }// task 8-9

        #endregion

        #region methods

        public static string GenerateCallList(Call call)
        {
            return String.Format(
                                 "Date:        {0,25}\n" +
                                 "Phone Number {1,25}\n" +
                                 "Duration     {2,1} minutes and {3} seconds", call.TimeStamp, call.PhoneDialed, (call.Duration) / 60, (call.Duration) % 60);
        }

        #endregion
    }
}
