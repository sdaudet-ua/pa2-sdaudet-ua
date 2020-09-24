using System;

namespace PA2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Priming Read for Sentinel Value (Main Menu)
            int exit = 0;
            //This is the main loop. When you finish a currency conversion or POS Transaction, you are returned to this menu. 
            while (exit == 0)
            {
                int userChoice = ChooseProgram();
                //This is the selection block for the main menu. Choice 1 is for the currency converter, and 2 is for the POS. 3 Exits. 
                if (userChoice == 1)
                {
                    CurrencyConverter();
                }
                else if (userChoice == 2)
                {
                    PointOfSale();
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
            //This method displays the main menu and returns the chosen value to the main method for selection.
            Console.WriteLine("\n\n\n\n-Enter 1 for the currency converter.\n-Enter 2 for the Point of Sale.\n-Enter 3 to exit");
            return int.Parse(Console.ReadLine());
        }   
        static void CurrencyConverter()
        {
            //Primes the output currency to US Dollars, in case the input currency is not US Dollars.
            string toCurrency = "u";
            //Asks user to input payment amount. (Currency agnostic)
            Console.Write("Please enter the amount: ");
            double amount = double.Parse(Console.ReadLine());
            //Asks user to input currency type of payment amount.
            Console.WriteLine("Please enter the type of currency to convert from: ");
            string fromCurrency = ChooseCurrency();
            //If the user inputs US Dollar for input currency, the system will ask user for desired output currency. 
            //Otherwise, the system will automatically convert the input to US Dollars.
            if (fromCurrency == "u")
            {
                Console.WriteLine("What currency would you like the amount converted to? ");
                toCurrency = ChooseCurrency();
            }
            //Calls the conversion method which will parse user input and use the respective rate to calculate the exchange. 
            double output = CalculateCurrency(fromCurrency,amount,toCurrency);
            //This if/else statement is just to check that the conversion outputs a real value. The "ToString("F")" is to limit the decimal places to 2 (used throughout program). 
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
            /* This is the method that does all the real processing for the currency conversion. It first defines the exchange rates for easy adjustment down the road.*/
            double output = 0;
            double canada = .9813;
            double euro = .757;
            double indian = 52.53;
            double japan = 80.92;
            double mexico = 13.1544;
            double pound = .6178;

            //If the target currency is US dollars, the program will use this switch to determine which rate to use in the conversion to USD, and complete the calculation.
            if (to == "u")
            {
                //Switch for the source currency, for use if the target currency is US Dollars.
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

                    //If the user's input for source currency is invalid, it displays this message, and the output is 0, so the output is not displayed, it shows this message, then the "Something went wrong message.
                    default:
                    Console.WriteLine("Invalid Input, please try again.");
                    break;
                }
                // Console.WriteLine($"output from Switch: {output}");
            }
            //If the user inputs US Dollars as the source currency, this switch is used for the calculations from USD to any of the other supported currencies.
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

                    //If the user's input for source currency is invalid, it displays this message, and the output is 0, so the output is not displayed, it shows this message, then the "Something went wrong message.
                    default:
                    Console.WriteLine("Invalid Input, please try again.");
                    break;
                }
            }
            //This else is here as a catch-all. Should never be used, and will result only in a error message. As long as users provide valid inputs for currency type, this will never be touched. 
            else
            {
                output = 0;
            }
            //Return value to CurrencyConverter() for error check, then displays the output or an error message. 
            return output;
        }
        static string ChooseCurrency()
        {
            //Displays the currency options and returns the user's input back to CurrencyConverter() in lowercase for further processing. 
            Console.Write("(C)anadian Dollar\n(E)Uro\n(I)ndian Rupee\n(J)apense Yen\n(M)exican Peso\n(B)ritish Pound\n(U)S Dollar\n\nChoice: ");
            return Console.ReadLine().ToLower(); 
        }
        static void PointOfSale()
        {
            //This method holds the constants, variables, and does the math for tax and tip calculations. It then calls methods to gather and display the dollar amounts, and to ensure full payment. 
            double tipAmount = 0.18;
            double taxAmount = 0.09;
            //The following 2 lines call the GetAmount method to prompt the user for food and alcohol totals. 
            double foodTotal = GetAmount("food");
            double alcTotal = GetAmount("alcohol");
            //Adds the food and alcohol amounts together for subtotal.
            double subtotal = foodTotal + alcTotal;
            //Calculates the tip using only the food amount. 
            double tip = foodTotal * tipAmount;
            //Calculates tax based on all items. 
            double tax = subtotal * taxAmount;
            //Calculates the total amount due, including tip and tax. 
            double total = subtotal + tip + tax;
            //Displays the calculated information to the user in dollars. 
            DisplayTotal(subtotal, tip, tax, total);
            //Asks user to input payment amount and calculates the change or shortage to ensure full payment and provide rapid change return to the customer. 
            GetPayment(total);
        }
        static double GetAmount(string item)
        {
            Console.Write($"Please enter the {item} total: ");
            return double.Parse(Console.ReadLine());
        }
        static void DisplayTotal(double subtotal, double tip, double tax, double total)
        {
            //Displays the tax, tip and totals to the user in dollars. Rounds numbers to 2 decimal places. 
            Console.WriteLine($"Subtotal: ${subtotal.ToString("F")} \nTax: ${tax.ToString("F")} \nTip: ${tip.ToString("F")} \nTotal: ${total.ToString("F")}\n\n\n");
        }
        static void GetPayment(double amountDue)
        {
            //This while loop ensures that the full amount of the bill is payed before allowing the user to exit the transaction and program.
            while (amountDue > 0)
            {
                //Asks user to enter amount payed by customer.
                Console.Write("Enter payment amount: ");
                double paymentAmount = double.Parse(Console.ReadLine());
                //Round to 2 decimal places so tiny amounts do not affect selection statements. 
                amountDue = double.Parse(amountDue.ToString("F"));
                //Calculate how much is still due after payment. 
                amountDue = amountDue - paymentAmount;
                //If the customer overpayed, this will show user how much change to dispense. 
                if (amountDue < 0)
                {
                    Console.WriteLine($"Change due: {Math.Abs(amountDue).ToString("F")}");
                }
                //If the customer underpayed, this will tell the user that the customer needs to pay more and will repeat until the balance is 0 or less. 
                else if (amountDue > 0)
                {
                    Console.WriteLine($"Payment amount insufficient, remaining balance is {amountDue.ToString("F")}");
                }
                //If the customer pays precise amount and brings balance to 0, this will notify the user the balance is payed in full and terminate the transaction.
                else if (amountDue == 0)
                {
                    Console.WriteLine("Transaction Complete, Thank you.");
                }
            }
        }
    }
}