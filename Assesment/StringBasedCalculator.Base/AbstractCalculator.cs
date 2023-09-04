namespace StringBasedCalculator.Base
{
    public abstract class AbstractCalculator
    {
        protected static void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            if (input.Contains(",\n") || input.Contains("\n,"))
            {
                throw new ArgumentException("Invalid Format");
            }
        }

        protected virtual char[] ExtractDelimiters(ref string input)
        {
            char[] defaultDelimiters = { ',', '\n' };

            if (input.StartsWith("//"))
            {
                int endOfDelimiters = input.IndexOf('\n');
                char[] delimiters = input[2..endOfDelimiters].ToCharArray();
                input = input[(endOfDelimiters + 1)..];
                return delimiters;
            }

            return defaultDelimiters;
        }

        protected static void CheckForNegativeNumbers(IEnumerable<int> numbers)
        {
            List<int> negativeNumbers = numbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Input contains negative numbers " + string.Join(',', negativeNumbers));
            }
        }

        protected static IEnumerable<int> ParseNumbers(string input, char[] delimiters)
        {
            return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.TryParse(c, out int num) && num <= 1000 ? num : 0)
                .ToList();
        }
    }
}