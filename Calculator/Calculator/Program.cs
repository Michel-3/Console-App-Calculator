using System;
using System.Threading;
using Calculator.Core;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool operate = true;
            decimal number1;
            decimal number2;
            char operatorCharacter;

            while (operate)
            {
                Console.WriteLine("Console Calculator");
                Console.WriteLine("-------------------");
                number1 = inputValidation("Enter 1st number");
                number2 = inputValidation("Enter 2e number");

                Console.WriteLine("Enter operator (+, -, *, /): ");
                operatorCharacter = Console.ReadLine()?.FirstOrDefault() ?? '\0';

                CalculateService calculator = new CalculateService();
                var calculatedResult = calculator.PerformCalculation(number1, number2, operatorCharacter);
                if (!calculatedResult.HasSucceeded)
                {
                    Console.WriteLine(calculatedResult.ErrorMessage);
                }
                else
                {
                    Console.WriteLine("Result: " +  calculatedResult.Outcome);
                }

                Console.WriteLine("To proceed, type 'continue' otherwise type 'stop':");
                string userInput = Console.ReadLine()?.ToLower() ?? "";

                if (userInput == "continue")
                {
                    operate = true;
                }
                else if (userInput == "stop")
                {
                    operate = false;
                    Console.WriteLine("Calculator shutting down...");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }

        private static decimal inputValidation(string userPrompt)
        {
            do
            {
                decimal numberInput;

                Console.WriteLine(userPrompt);
                string userInput = Console.ReadLine();
                int decimalValidation = userInput.IndexOfAny(new char[] { '.', ',' });

                if (string.IsNullOrEmpty(userPrompt))
                {
                    Console.WriteLine("Fill in this number...");
                }
                else
                {
                    if (decimal.TryParse(userInput, out numberInput))
                    {
                        if (decimalValidation != -1 && userInput.Substring(decimalValidation + 1).Length > 2)
                        {
                            Console.WriteLine("Number can only have two decimals...");
                            continue;
                        }

                        return numberInput;
                    }
                    else
                    {
                        Console.WriteLine("Need a valid number...");
                    }
                }
            } while (true);
        }
    }
}
              