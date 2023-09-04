namespace StringBasedCalculator.Abstract
{
    public interface ICalculator
    {
        public IEnumerable<int> ValidateInput(string input, out IEnumerable<int> numbers);

        public int Calculate(IEnumerable<int> numbers);
    }
}
