using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{
    public class Call
    {

        // *** Fields *** \\ task 8

        private DateTime talkDate; // timestamp
        private int duration; // seconds
        private string callDialed; // numbers to string beacuse it moght contain other symbols as # + ect.
        // private string callReceived;


        // *** Constructors *** \\ task 8

        public Call(string callDialed, int duration, DateTime talkDate)
        {
            this.CallDialed = callDialed;
            this.Duration = duration;
            this.TalkDate = talkDate;
        }

        // *** Properties *** \\ task 8
        public string CallDialed 
        {
            get { return this.callDialed; }
            set { this.callDialed = value; } 
        }

        public DateTime TalkDate
        {
            get { return this.talkDate; }
            set { this.talkDate = value; }
        }

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
                    throw new ArgumentException("Call duration can not have a negative value!"); 
                }
            }
        }

        // *** Methods *** \\ task 9

        public static string GenerteCallHistory(Call call)
        {
            return String.Format("Date:         {0,15}\n" +
                                 "Phone Number: {1,15}\n" +
                                 "Duration min: {2,15}\n" +
                                 "Duration sec: {3,15}\n",
                                  call.TalkDate, call.CallDialed, call.Duration/60 ,call.Duration);
        }
    }
}
