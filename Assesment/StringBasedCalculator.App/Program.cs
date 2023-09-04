using StringBasedCalculator.Abstract;
using StringBasedCalculator.App;

// this can be extended with DI based on user input
ICalculator calculator = new AddCalculator();
//ICalculator calculator = new SubstractCalculator();

List<string> inputList = new()
{
    "",
    "1,2",
    "1\n2,3",
    "//;\n1;2",
    "2,1001,13",
    "//*%\n1*2%3",
    "1,-2,-3",
    "\n,23"
};

foreach (string input in inputList)
{
    try
    {
        Console.WriteLine("Input :" + input);
        // Validate the user input
        calculator.ValidateInput(input, out IEnumerable<int> numbers);

        // Show the output
        Console.WriteLine($"Output {calculator.Calculate(numbers)}\n");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Output {e.Message}\n");
    }
}