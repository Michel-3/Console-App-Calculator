namespace Calculator.Core
{
    public class CalculateService
    {
        public PropertyAccessor PerformCalculation(decimal number1, decimal number2, char operator1)
        {
            decimal result;

            {
                switch (operator1)
                {
                    case '+':
                        result = number1 + number2;
                        break;
                    case '-':
                        result = number1 - number2;
                        break;
                    case  '*':
                        result = number1 * number2;
                        break;
                    case '/':
                        if ( number2 == 0 )
                        {
                            return new PropertyAccessor()
                            {
                                Outcome = 0,
                                HasSucceeded = false,
                                ErrorMessage = "Cannot be divided by 0!"
                            };
                        }
                        else
                        {
                            result = number1 / number2;
                        }
                        break;

                    default:
                        return new PropertyAccessor()
                        {
                            Outcome = 0,
                            HasSucceeded = false,
                            ErrorMessage = "Invalid operator"
                        };
                }
            }

            return new PropertyAccessor()
            {
                Outcome = result,
                HasSucceeded = true,
                ErrorMessage = ""
            };
        }
    }
}