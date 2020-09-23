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
                    // exit = ExitDesired();
                }
                else if (userChoice == 2)
                {
                    PointOfSale();
                    // exit = ExitDesired();
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
            string toCurrency = "u";
            Console.Write("Please enter the amount: ");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the type of currency to convert from: ");
            string fromCurrency = ChooseCurrency();
            if (fromCurrency == "u")
            {
                Console.WriteLine("What currency would you like the amount converted to? ");
                toCurrency = ChooseCurrency();
            }
            double output = CalculateCurrency(fromCurrency,amount,toCurrency);
            if (output > 0)
            {
                Console.WriteLine($"New Amount is: {output.ToString("F")}");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
        }
        static double CalculateCurrency(string from, double amount, string to)
        {
            double output = 0;
            double canada = .9813;
            double euro = .757;
            double indian = 52.53;
            double japan = 80.92;
            double mexico = 13.1544;
            double pound = .6178;

            if (to == "u")
            {
                switch(from)
                {
                    case "c":
                    Console.WriteLine($"Converting {amount.ToString("F")} Canadian Dollars to US Dollars");
                    output = amount / canada;
                    break;

                    case "e":
                    Console.WriteLine($"Converting {amount.ToString("F")} Euros to US Dollars");
                    output = amount / euro;
                    break;

                    case "i":
                    Console.WriteLine($"Converting {amount.ToString("F")} Indian Rupees to US Dollars");
                    output = amount / indian;
                    break;

                    case "j":
                    Console.WriteLine($"Converting {amount.ToString("F")} Japanese Yen to US Dollars");
                    output = amount / japan;
                    break;

                    case "m":
                    Console.WriteLine($"Converting {amount.ToString("F")} Mexican Pesos to US Dollars");
                    output = amount / mexico;
                    break;

                    case "b":
                    Console.WriteLine($"Converting {amount.ToString("F")} British Pounds to US Dollars");
                    output = amount / pound;
                    break;

                    default:
                    Console.WriteLine("Invalid Input, please try again.");
                    break;
                }
                // Console.WriteLine($"output from Switch: {output}");
            }
            else if (from == "u")
            {
                switch(to)
                {
                   case "c":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to Canadian Dollars");
                    output = amount * canada;
                    break;

                    case "e":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to Euros");
                    output = amount * euro;
                    break;

                    case "i":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to Indian Rupees");
                    output = amount * indian;
                    break;

                    case "j":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to Japanese Yen");
                    output = amount * japan;
                    break;

                    case "m":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to Mexican Pesos");
                    output = amount * mexico;
                    break;

                    case "b":
                    Console.WriteLine($"Converting {amount.ToString("F")} US Dollars to British Pounds");
                    output = amount * pound;
                    break; 

                    default:
                    Console.WriteLine("Invalid Input, please try again.");
                    break;
                }
            }
            else
            {
                output = 0;
            }
            return output;
        }
        static string ChooseCurrency()
        {
            Console.Write("(C)anadian Dollar\n(E)Uro\n(I)ndian Rupee\n(J)apense Yen\n(M)exican Peso\n(B)ritish Pound\n(U)S Dollar\n\nChoice: ");
            return Console.ReadLine().ToLower(); 
        }
        static void PointOfSale()
        {

        }
    }
}
