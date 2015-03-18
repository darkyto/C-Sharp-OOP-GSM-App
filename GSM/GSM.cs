namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GSM
    {
        /*Problem 1. Define class
         * Define a class that holds information about a mobile phone device: model, manufacturer, 
         * price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors).
         * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
         */

        #region fields
        public static readonly GSM IPhone4S = new GSM("Iphone 4S", "Apple", 390, "John Smith", new Battery(BatteryType.LiIon, 48, 12), new Display(3, 255));

        private string model;
        private string manufacturer;
        private double? price; // float? so it can take null values but also to be double digit
        private string owner;

        private Battery phoneBattery;
        private Display phoneDisplay;

        public List<Call> callHistory = new List<Call>();

        #endregion

        #region constructors

        public GSM(string model, string manufacturer)  //the first constructor with only model and manufacturer mandatory 
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.PhoneBattery = null;
            this.PhoneDisplay = null;
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery phoneBattery, Display phoneDisplay) //the full overloaded constuctor with all properties included
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.PhoneBattery = phoneBattery;
            this.PhoneDisplay = phoneDisplay;
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
                    throw new ArgumentException("Model name must contain at least 2 symbols!");
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value == null || value.Length < 2)
                {
                    throw new ArgumentException("Manufacturer name must contain at least two symbols");
                }
                else
                {
                    manufacturer = value;
                }
            }
        }

        public double? Price
        {
            get { return price; }
            set
            {
                if (value >= 0 || value != null)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Price can not be negative number or null!");
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set
            {
                if (value != null || (value.Length > 2 && value.Length < 31))
                {
                    owner = value;
                }
                else if (value.Length <= 2)
                {
                    throw new Exception("Owner's name must contain at least 3 symbols!");
                }
                else if (value.Length >= 31)
                {
                    throw new Exception("Owner's name must contain Maximum 30 symbols!");
                }
            }
        }

        public Battery PhoneBattery
        {
            get { return phoneBattery; }
            set { phoneBattery = value; }
        }

        public Display PhoneDisplay
        {
            get { return phoneDisplay; }
            set { phoneDisplay = value; }
        }

        #endregion

        #region methods

        public static List<Call> AddOutgoingCall(List<Call> callHistory, Call call)
        {
            callHistory.Add(call); // add the current outgoing converastion to history
            return callHistory;
        }

        public static List<Call> RemoveOutgoingCall(List<Call> callHistory, Call call)
        {
            callHistory.Remove(call); // removing a specific call from history
            return callHistory;
        }

        public static void CLearALL(List<Call> callHistory)
        {
            callHistory.Clear(); // void method only for clearing ALL hhistory
        }

        public static List<Call> RemoveLongestCall(List<Call> callHistory) // task 12
        {
            Call longestCall = callHistory.OrderBy(x => x.Duration).ToArray()[callHistory.Count - 1]; // order by duration time >> to array in reverse order
            
            callHistory.RemoveAt(0); // remove calling from GSMCallHistoryTest.
            
            return callHistory;
        }

        public static decimal PriceCallHistory(double price, List<Call> callHistory) // task 11
        {
            decimal totalSeconds = 0;
            decimal totalPrice = 0;

            for (int i = 0; i < callHistory.Count; i++)
            {
                totalSeconds += callHistory[i].Duration;
            }

            totalPrice = (totalSeconds / 60) * (decimal)price; // seconds/60 =  minutes *0.37 (price)

            return Math.Round(totalPrice, 2);
        }

        public override string ToString() // task 4
        {
            StringBuilder sb = new StringBuilder();

            if (this.Model != null && this.Model.Length > 1)
            {
                sb.Append("Model : ".PadRight(20, ' '));
                sb.Append(this.Model);
                sb.AppendLine();
            }
            if (this.Manufacturer != null && this.Manufacturer.Length > 1)
            {
                sb.Append("Manufacturer : ".PadRight(20, ' '));
                sb.Append(this.Manufacturer);
                sb.AppendLine();
            }
            if (this.Price != null && this.Price >= 0)
            {
                sb.Append("Price : ".PadRight(20, ' '));
                sb.Append(this.Price);
                sb.AppendLine();
            }
            if (this.Owner != null && this.Owner.Length > 2)
            {
                sb.Append("Owner : ".PadRight(20, ' '));
                sb.Append(this.Owner);
                sb.AppendLine();
            }
            if (this.PhoneBattery != null)
            {
                sb.Append("Phone Battery : ".PadRight(20, ' '));
                sb.Append(this.PhoneBattery.Model + this.PhoneBattery.BatteryType);
                sb.AppendLine();
                sb.Append("Battery Talk time : " + this.PhoneBattery.TalkHours + "\nBattery Idle time : " + this.PhoneBattery.IdleHours);
                sb.AppendLine();
            }
            if (this.PhoneDisplay != null)
            {
                sb.Append("Display size : ".PadRight(20, ' '));
                sb.Append(this.PhoneDisplay.Size);
                sb.AppendLine();
                sb.Append("Number of colors: ".PadRight(20, ' '));
                sb.Append(this.PhoneDisplay.Colors);
                sb.AppendLine();
            }

            return sb.ToString();
        }
        #endregion
    }
}
