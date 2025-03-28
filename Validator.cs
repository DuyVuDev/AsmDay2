namespace AsmDay2
{
    public static class Validator
    {
        private static T ValidateInput<T>(string prompt, Func<string?, (bool, T)> conditionFunc, string errorMessage)
        {
            T result;
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine().Trim();
                var (isValid, validatedResult) = conditionFunc(input);
                if (isValid)
                {
                    result = validatedResult;
                    break;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return result;
        }

        public static string ValidateStringInput(string prompt, string errorMsg)
        {
            return ValidateInput(prompt, input => (!string.IsNullOrEmpty(input), input!), errorMsg);
        }

        public static int ValidateYearInput(string prompt, string errorMsg)
        {
            return ValidateInput(prompt, input =>
            {
                bool isValid = int.TryParse(input, out var result) && result >= 1886 && result <= DateTime.Now.Year;
                return (isValid, result);
            }, errorMsg);
        }

        public static DateTime ValidateDateInput(string prompt)
        {
            return ValidateInput(prompt, input => (DateTime.TryParse(input, out var result), result), "Invalid date. Please enter a valid date.");
        }

        public static string ValidateCarTypeInput(string prompt)
        {
            return ValidateInput(prompt, input =>
                (input != null && (input.Equals("F", StringComparison.OrdinalIgnoreCase) || input.Equals("E", StringComparison.OrdinalIgnoreCase)),
                input!),
                "Invalid car type. Please enter F for Fuel or E for Electric.");
        }
    }

}
