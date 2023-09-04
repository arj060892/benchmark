using StringBasedCalculator.Abstract;
using StringBasedCalculator.Base;

namespace StringBasedCalculator.App
{
    public class SubstractCalculator : AbstractCalculator, ICalculator
    {
        public int Calculate(IEnumerable<int> numbers)
        {
            return numbers.Aggregate((current, next) => current - next);
        }

        public IEnumerable<int> ValidateInput(string input, out IEnumerable<int> numbers)
        {
            ValidateInput(input);
            numbers = ParseNumbers(input, ExtractDelimiters(ref input));

            CheckForNegativeNumbers(numbers);

            return numbers;
        }
    }
}