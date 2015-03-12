using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{
    public class GSMCallHistoryTest
    {
        //fields
        public static GSM testMobile = new GSM("Lumia", "Nokia", 390, "John Smith", new Battery(BatteryType.LiIon), new Display(3, 255));   // create an instance of the GSM class

        public static DateTime callTimeOne = DateTime.Parse("03/12/2015 11:25:00"); // for shor use in the new calls
        public static DateTime callTimeTwo = DateTime.Parse("03/13/2015 15:35:22");
        public static DateTime callTimeThree = DateTime.Parse("03/14/2015 20:45:44");

        public static List<Call> callHistory = new List<Call>     // array with three calls
        {
            new Call("359889008008" , 2400 , callTimeOne),
                        new Call("9287777" , 600 , callTimeTwo),
                                    new Call("++001257115689" , 1200 , callTimeThree)
        };


        //methods
        public static string CreateCallHistory() // task 12
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 35));
            sb.Append(new string('-', 10));
            sb.Append("Call History LOG");
            sb.AppendLine(new string('-', 9));

            for (int i = 0; i < callHistory.Count; i++)
            {
                sb.AppendLine(new string('-', 35));
                sb.Append(Call.GenerteCallHistory(callHistory[i])); // using GenerteCallHistory from Call class
                sb.AppendLine();
                sb.AppendLine(new string('-', 35));
            }

            sb.AppendLine(new string('-', 35));
            sb.AppendLine("TOTAL COSTS : "+ GSM.PriceCallHistory((decimal)0.37, callHistory)); // using the price generator from GSM class

            return sb.ToString();
        }

        public static void RemoveLongestCall() // task 12
        {
            Call longestCall = GSMCallHistoryTest.callHistory.OrderBy(x => x.Duration).ToArray()[GSMCallHistoryTest.callHistory.Count - 1];
            GSMCallHistoryTest.callHistory.RemoveAt(0);
        }

    }

    class MobilePhoneTest // CONSOLE TESTS for ctrl+f5
    {
        public static void Main(string[] args) // for console test purposes ONLY
        {
            Console.WriteLine("Console part for test of application!");

            var models = GSMTest.GenerateGSM();         // generating some mobiles
            GSMTest.PrintModelsInformation(models);     // printing all mobile phones info

            Console.WriteLine();
            string result = GSMCallHistoryTest.CreateCallHistory(); // call history generation
            Console.WriteLine(result);

            Console.WriteLine();
            Console.WriteLine("And now lets remove the longest call and re-calculated the total price ...");
            GSMCallHistoryTest.RemoveLongestCall(); // removing the longest call (by duration) in the list
            var resultFinal = GSM.PriceCallHistory((decimal)0.37 , GSMCallHistoryTest.callHistory);
            Console.WriteLine("TOTAL COSTS after removing the longest call : {0}", resultFinal);

            GSM.ClearCallHistory(GSMCallHistoryTest.callHistory); // clear the call history list

            Console.WriteLine(); Console.WriteLine();
            result = GSMCallHistoryTest.CreateCallHistory(); // call history generation
            Console.WriteLine("CALL LOG and PRICE after clearing the history : \n{0}", result);


        }                                      // end console test
    }
}
