using StringBasedCalculator.Abstract;
using StringBasedCalculator.Base;

namespace StringBasedCalculator.App
{
    public class AddCalculator : AbstractCalculator, ICalculator
    {
        public int Calculate(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public IEnumerable<int> ValidateInput(string input, out IEnumerable<int> numbers)
        {
            ValidateInput(input);

            char[] delimiters = ExtractDelimiters(ref input);
            numbers = ParseNumbers(input, delimiters);

            CheckForNegativeNumbers(numbers);

            return numbers;
        }
    }
}