using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{

    public class GSM // task 1
    {
        #region Fields
        // *** static field *** \\ task 6

        private static readonly GSM IPhone4S = new GSM("Iphone 4S", "Apple", 390, "John Smith", new Battery(BatteryType.LiIon), new Display(3, 255));

        // *** Fields *** \\ task 1
        private string model;
        private string manufacturer;
        private double? price;         // inital price can be null with this constructor 
        private string owner;

        private Battery phoneBattery;  // the separate class Battery contains also the enumerator BatteryType for the batteries
        private Display phoneDisplay;

        public List<Call> callHistory = new List<Call>(); // task 9
        #endregion


        #region Constructors
        // *** Constructors *** \\  task 2

        public GSM(string model, string manufacturer)
        {
            this.Model = model; // model and manufacture are mandatory - all others are optional
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.PhoneBattery = null;
            this.PhoneDisplay = null;
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery phoneBattery, Display phoneDisplay)
        {
            this.Model = model; // model and manufacture are mandatory - all others are optional
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.PhoneBattery = phoneBattery;
            this.PhoneDisplay = phoneDisplay;
        }

        #endregion


        #region Properties
        // *** Properties *** \\ task 5
        public List<Call> CallHistory
        {
            get { return callHistory; } // no setter - just getter for this property
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
                    throw new ArgumentException("Model name must contain at least 2 symbols!");
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value != null || value.Length > 1)
                {
                    manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("manufacturer name must contain at least 2 symbols!");
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
                    throw new Exception("Owner's name must contain maximum 30 symbols!");
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

        public static GSM IPhoneFour // for use in the MobbilePhoneTest (task 7)
        {
            get { return IPhone4S; }
        }
        #endregion 


        #region Methods
        // *** Methods *** \\

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
                sb.Append(this.PhoneBattery.Model + " " + this.PhoneBattery.BatteryType);
                sb.AppendLine();
                sb.Append("Battery Talk time :" + this.PhoneBattery.Talk + "\nBattery Idle time :" + this.PhoneBattery.Idle);
                sb.AppendLine();
            }
            if (this.PhoneDisplay != null)
            {
                sb.Append("Display size (inches): ".PadRight(20, ' '));
                sb.Append(this.PhoneDisplay.Size);
                sb.AppendLine();
                sb.Append("Number of colors: ".PadRight(20, ' '));
                sb.Append(this.PhoneDisplay.Colors);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static List<Call> AddOutgoingCall(List<Call> callHistory, Call dialed) // task 9 - method for adding a cal to call history
        {
            callHistory.Add(dialed);
            return callHistory;
        }
        
        public static List<Call> RemoveOutgoingCall(List<Call> callHistory , Call dialed) // task 9 - remove call from history
        {
            callHistory.Remove(dialed);
            return callHistory;
        }

        public static void ClearCallHistory(List<Call> callHistory) // will clear the whole list (task 9)
        {
            callHistory.Clear();
        }

        public static decimal PriceCallHistory(decimal price , List<Call> callHistory) // task 11
        {
            decimal totalSeconds = 0;
            decimal totalPrice = 0;

            for (int i = 0; i < callHistory.Count; i++)
            {
                totalSeconds += callHistory[i].Duration;
            }

            totalPrice = (totalSeconds / 60) * (decimal)price; // seconds/60 =  minutes *0.37 (price)

            return totalPrice;
        }

        public static void GenerateHistory(List<Call> callHistory) // test purposes method task 9-11
        {
            foreach (var call in callHistory)
            {
                Console.WriteLine(call);
            }
        }
        #endregion
    }

    public class GSMTest  //task 7
    {
        public static List<GSM> GenerateGSM()
        {
            List<GSM> models = new List<GSM>();
            models.Add(new GSM("S3", "Samsung", 159.99, "Aldous Huxley", new Battery(BatteryType.LiIon), new Display(6, 32000)));  // (string model, string manufacturer, double price, string owner, Battery phoneBattery, Display phoneDisplay)
            models.Add(new GSM("Lumia 830", "Nokia", 556, "Richard Bach", new Battery(BatteryType.NiCd), new Display(8, 16000000)));
            models.Add(GSM.IPhoneFour); // the trick for the static property

            return models;
        }
        public static void PrintModelsInformation(List<GSM> models)
        {
            foreach (var model in models)
            {
                Console.WriteLine(new string('-', 20));
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("{0,25}", model);
                Console.ResetColor();
                Console.WriteLine(new string('-', 20));
            }
        }
    }

}
