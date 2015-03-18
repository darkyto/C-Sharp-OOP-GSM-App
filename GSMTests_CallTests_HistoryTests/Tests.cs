

namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Tests
    {
        #region fields
        // create new instance of the GSM class among with ne instance of batttery and display
        private static readonly double pricePerMinute = 0.37;

        public static GSM testMobile = new GSM("Lumia", "Nokia", 390, "John Smith", new Battery(BatteryType.LiIon), new Display(3, 255));

        public static DateTime callTimeOne = DateTime.Parse("03/12/2015 11:25:00"); // for easier use in the new calls (insted of amunally adding date)
        public static DateTime callTimeTwo = DateTime.Parse("03/13/2015 15:35:22");
        public static DateTime callTimeThree = DateTime.Parse("03/14/2015 20:45:44");
        #endregion


        #region methods

        public static string CreateCallHistory(List<Call> calls)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 38));
            sb.Append(new string('-', 10));
            sb.Append("Call History LOG");
            sb.AppendLine(new string('-', 12));

            for (int i = 0; i < calls.Count; i++)
            {
                sb.AppendLine(new string('-', 38));
                sb.Append(Call.GenerateCallList(calls[i])); // using GenerteCallHistory from Call class
                sb.AppendLine();
                sb.AppendLine(new string('-', 38));
            }

            sb.AppendLine(new string('-', 38));
            sb.AppendLine("TOTAL COSTS :                $"+ GSM.PriceCallHistory(pricePerMinute, calls)); // using the price generator from GSM class

            return sb.ToString();
        }


        static void Main(string[] args)
        {
            #region GSM Test
            ////////////////////////////// TEST FOR THE GSM APARATES \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            List<GSM> models = new List<GSM>();
            models.Add(new GSM("S3", "Samsung", 159.99, "Aldous Huxley", new Battery(BatteryType.LiIon), new Display(6, 32000)));  // (string model, string manufacturer, double price, string owner, Battery phoneBattery, Display phoneDisplay)
            models.Add(new GSM("Lumia 830", "Nokia", 556, "Richard Bach", new Battery(BatteryType.NiCd, 32, 6), new Display(8, 16000000)));
            models.Add(GSM.IPhone4S); // the trick for the static property


            // using the override ToString in the GSM class for the test purposes
            foreach (var model in models)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(model.ToString()); //the overrided ToString() in GSM class
                Console.ResetColor();
            }


            List<GSM> Blackberries = new List<GSM> // again new instance of GSM called by index in list
            {            
                new GSM("Exodus", "BlackBerry", 200, "Gender Bender", new Battery(BatteryType.Alkaline), new Display(6, 1600000))
            };
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Blackberries[0].ToString()); ;
            Console.ResetColor();
            ////////////////////////// END TEST FOR THE GSM APARATES \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            #endregion

            #region CAllHistoryTest
            ////////////////////////////// TEST FOR CALLS (timestamp , duartion , phone dialed)\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            DateTime callTimeOneTest = DateTime.Parse("06/12/2015 00:25:00");
            DateTime callTimeTwoTest = DateTime.Parse("08/12/2015 22:00:55");

            List<Call> callHistory = new List<Call>     // array with three calls
            {
                new Call("359889008008" , 2425 , callTimeOneTest),
                new Call("9287777" , 634 , callTimeTwoTest),
                new Call("911" , 2124 , callTimeOneTest),
                new Call("070017777" , 246 , callTimeTwoTest),
            };

            string resutlTest = CreateCallHistory(callHistory);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(resutlTest);
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("NOW Lets REMOVE THE LONGEST CALL and RECALCULATE AGAIN the TOTAL PRICE!");
            Console.ResetColor();

            GSM.RemoveLongestCall(callHistory); //using the method from GSM class
            string resutlTestTwo = CreateCallHistory(callHistory);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(resutlTestTwo);
            Console.ResetColor();


            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("AND Finally lets CLEAR ALL History and Print again!");
            Console.ResetColor();

            GSM.CLearALL(callHistory);
            string resultFinal = CreateCallHistory(callHistory);
            Console.WriteLine(resultFinal);

            //////////////////////////END TEST FOR CALLS (timestamp , duartion , phone dialed)\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            #endregion
        }

        #endregion
    }
}
