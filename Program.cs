using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<Temperature>> temperatureItems = new Dictionary<string, List<Temperature>>();

            List<Temperature> hotActions = new List<Temperature>()
            {
                new Temperature {  ID = "1", Description = "Put on footwear", Response = "sandals"},
                new Temperature {  ID = "2", Description = "Put on headwear", Response = "sunglasses"},
                new Temperature {  ID = "3", Description = "Put on socks", Response = "fail"},
                new Temperature {  ID = "4", Description = "Put on shirt", Response = "shirt"},
                new Temperature {  ID = "5", Description = "Put on jacket", Response = "fail"},
                new Temperature {  ID = "6", Description = "Put on pants", Response = "shorts"},
                new Temperature {  ID = "7", Description = "Leave house", Response = "leaving house"},
                new Temperature {  ID = "8", Description = "Take off pajamas", Response = "Removing PJs"}
            };

            List<Temperature> coldActions = new List<Temperature>()
            {
                new Temperature {  ID = "1", Description = "Put on footwear", Response = "boots"},
                new Temperature {  ID = "2", Description = "Put on headwear", Response = "hat"},
                new Temperature {  ID = "3", Description = "Put on socks", Response = "socks"},
                new Temperature {  ID = "4", Description = "Put on shirt", Response = "shirt"},
                new Temperature {  ID = "5", Description = "Put on jacket", Response = "jacket"},
                new Temperature {  ID = "6", Description = "Put on pants", Response = "pants"},
                new Temperature {  ID = "7", Description = "Leave house", Response = "leaving house"},
                new Temperature {  ID = "8", Description = "Take off pajamas", Response = "Removing PJs"}
            };

            temperatureItems.Add("HOT", hotActions);
            temperatureItems.Add("COLD", coldActions);

            List<Temperature> lstRes = new List<Temperature>();
        Question1:
            Console.WriteLine("Temperature Type: (HOT or COLD)");

            string strWeather = Console.ReadLine();

            if (String.IsNullOrEmpty(strWeather.Trim()))
            {
                Console.WriteLine("Please enter temperature type");
                goto Question1;
            }
            else if(!strWeather.Trim().ToLower().Contains("cold") && !strWeather.Trim().ToLower().Contains("hot"))
            {
                Console.WriteLine("Please enter temperature type");
                goto Question1;
            }
            else
            {
                string commands = string.Empty;
                
               lstRes = temperatureItems["" + strWeather.Split(' ')[0].Trim() + ""];
                commands = strWeather.Split(' ')[1].Trim();

                string[] validNames = commands.Split(',');

               var orderedData = lstRes.Where(c => validNames.Contains(c.ID)).OrderBy(item => validNames.ToList().IndexOf(item.ID.ToString()));

                var resultArray = string.Join(",", orderedData.Select(x=>x.Response).ToList());

                var numberOfCommandsWithDuplicates = validNames.GroupBy(x => x.ToString()).Count(x => x.Count() > 1);

                StringBuilder sb = new StringBuilder();
                sb.Append(resultArray.ToString());
                int failedCount = validNames.Length - resultArray.Split(',').Length;
                if (failedCount > 0)
                {
                    for(int i=0; i < failedCount; i++)
                    {
                        sb.Append(", fail");
                    }
                }

                Console.WriteLine(sb.ToString());

                Console.ReadLine();
            }
        }
    }
}