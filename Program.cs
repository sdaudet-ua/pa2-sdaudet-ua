using System;

namespace PA2
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            while (exit == 0)
            {
                int userChoice = ChooseProgram();
                if (userChoice == 1)
                {
                    CurrencyConverter();
                    exit = ExitDesired();
                }
                else if (userChoice == 2)
                {
                    PointOfSale();
                    exit = ExitDesired();
                }
                else if (userChoice == 3)
                {
                    Console.WriteLine("Thank you, Goodbye.");
                    exit = 1;
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again.");

                }
            }
        }
        static int ChooseProgram()
        {
            Console.WriteLine("-Enter 1 for the currency converter.");
            Console.WriteLine("-Enter 2 for the Point of Sale.");
            Console.WriteLine("-Enter 3 to exit");
            return int.Parse(Console.ReadLine());
        }   
        static int ExitDesired()
        {
            /*Run after every process to ask user if they want to continue or end. If user enters n or N, 
                the program will exit from integer exit being "1" */
            int exit;
            Console.WriteLine("Would you like to run another command? (Y/N)");
            switch (Console.ReadLine().ToLower())
            {
                case "n":
                exit = 1;
                break;

                default:
                exit = 0;
                break;
            }
            return exit;
        } 
        static void CurrencyConverter()
        {
            Console.WriteLine("Please enter the type of currency to convert from: ");
            string fromCurrency = ChooseCurrency();
            Console.Write("Please enter the amount: ");
            double amount = double.Parse(Console.ReadLine());
            if (fromCurrency == "u")
            {
                Console.WriteLine("What currency would you like the amount converted to? ");
                string toCurrency = ChooseCurrency();
            }
            
        }
        static string ChooseCurrency()
        {
            Console.Write("(C)anadian Dollar\n(E)Uro\n(I)ndian Rupee\n(J)apense Yen\n(M)exican Peso\n(B)ritish Pound\nChoice: \t");
            return Console.ReadLine().ToLower();
        }
        static void PointOfSale()
        {

        }
    }
}
