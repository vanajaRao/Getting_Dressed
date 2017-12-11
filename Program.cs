using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Temperature Type: (HOT or COLD)");

            string strWeather = Console.ReadLine();

            if (strWeather.ToUpper() != "HOT" && strWeather.ToUpper() != "COLD")
                return;

            int intCount = 0;
            string strOutPut = string.Empty;

            Console.Clear();

            displayMenu();

            string strHistory = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                int intUserInput = Convert.ToInt32(Console.ReadLine());
                intCount++;

                
                if (intCount == 1 && intUserInput != 8)
                {
                    Console.WriteLine("Fail");
                    strOutPut = string.Empty;
                    break;
                }
                else if (intCount != 1 && strHistory.Contains(intUserInput.ToString()))
                {
                    Console.WriteLine("Only one peace of each type of clothing may be put on");
                    intUserInput = 0;
                }
                else if (strWeather.ToUpper() == "HOT" && intUserInput == 3)
                {
                    Console.WriteLine("You cannot put on socks when it is hot");
                    intUserInput = 0;
                }
                else if (strWeather.ToUpper() == "HOT" && intUserInput == 5)
                {
                    Console.WriteLine("You cannot put on jacket when it is hot");
                    intUserInput = 0;
                }
                else if (strWeather.ToUpper() != "HOT" && intUserInput == 1 && strHistory.Contains("3") == false)
                {
                    Console.WriteLine("You cannot put footwear before socks");
                    intUserInput = 0;
                }
                else if (intUserInput == 1 && strHistory.Contains("6") == false)
                {
                    Console.WriteLine("You cannot put footwear before pants");
                    intUserInput = 0;
                }
                else if ((intUserInput == 2 || intUserInput == 5) && strHistory.Contains("4") == false )
                {
                    Console.WriteLine("Shirt must me put on before headwear or jacket");
                    intUserInput = 0;
                }
                else if (intUserInput == 7 )
                {

                    if (strWeather.ToUpper() == "HOT" && (strHistory.Contains("1") == false || strHistory.Contains("2") == false || strHistory.Contains("4") == false || strHistory.Contains("6") == false))
                    {
                        Console.WriteLine("You cannot leave the house until all items of clothing are on");
                        intUserInput = 0;
                    }
                    else if (strWeather.ToUpper() == "COLD" && (strHistory.Contains("1") == false || strHistory.Contains("2") == false || strHistory.Contains("3") == false || strHistory.Contains("4") == false || strHistory.Contains("5") == false || strHistory.Contains("6") == false))
                    {
                        Console.WriteLine("You cannot leave the house until all items of clothing are on");
                        intUserInput = 0;
                    }

                   
                }
                else if (intUserInput > 8)
                {

                    Console.WriteLine("Fail");
                    break;
                }

                switch (intUserInput)
                {
                    case 1:
                        {
                            if (strWeather.ToUpper() == "HOT")
                                strOutPut += "sandals, ";
                            else
                                strOutPut += "boots, ";
                            break;
                        }
                    case 2:
                        {
                            if (strWeather.ToUpper() == "HOT")
                                strOutPut += "sunglasses, ";
                            else
                                strOutPut += "hat, ";
                            break;
                        }
                    case 3:
                        {
                            if (strWeather.ToUpper() == "COLD")
                                strOutPut += "socks, ";
                            break;
                        }
                    case 4:
                        {

                            strOutPut += "shirt, ";
                            break;
                        }
                    case 5:
                        {
                            if (strWeather.ToUpper() == "COLD")
                                strOutPut += "jacket, ";
                            break;
                        }
                    case 6:
                        {
                            if (strWeather.ToUpper() == "HOT")
                                strOutPut += "shorts, ";
                            else
                                strOutPut += "pants, ";
                            break;
                        }
                    case 7:
                        {

                            strOutPut += "leaving house, ";
                            break;
                        }
                    case 8:
                        {
                            strOutPut += "Removing PJs, ";
                            break;
                        }
                    case 0:
                        {

                            strOutPut += "Fail, ";
                            break;
                        }

                }

                strHistory = strHistory + intUserInput.ToString();

                if (intUserInput == 0 || intUserInput == 7)
                    break;
            }

            if (strOutPut != "")
                strOutPut = strOutPut.Substring(0, strOutPut.Length - 2);

            Console.WriteLine(strOutPut);


            
            Console.Read();
        }


        public static void displayMenu()
        {
            Console.WriteLine("------------------------Welcome to Getting Dressed-----------------------");
            Console.WriteLine("1. Put on footwear");
            Console.WriteLine("2. Put on headwear");
            Console.WriteLine("3. Put on socks");
            Console.WriteLine("4. Put on shirt");
            Console.WriteLine("5. Put on jacket");
            Console.WriteLine("6. Put on pants");
            Console.WriteLine("7. Leave house");
            Console.WriteLine("8. Take off Pajamas");

        }
    }
}
