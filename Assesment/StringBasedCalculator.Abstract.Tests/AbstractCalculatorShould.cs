using StringBasedCalculator.Base;

namespace StringBasedCalculator.Abstract.Tests
{
    public class DummyCalculator : AbstractCalculator
    {
        public static void ValidateInputPublic(string input)
        {
            ValidateInput(input);
        }

        public char[] ExtractDelimitersPublic(ref string input)
        {
            return ExtractDelimiters(ref input);
        }

        public static void CheckForNegativeNumbersPublic(IEnumerable<int> numbers)
        {
            CheckForNegativeNumbers(numbers);
        }

        public static IEnumerable<int> ParseNumbersPublic(string input, char[] delimiters)
        {
            return ParseNumbers(input, delimiters);
        }
    }

    [TestFixture]
    public class AbstractCalculatorShould
    {
        private DummyCalculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new DummyCalculator();
        }

        [Test]
        public void ValidateInput_WithInvalidFormat_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => DummyCalculator.ValidateInputPublic("1,\n2"));
            Assert.Throws<ArgumentException>(() => DummyCalculator.ValidateInputPublic("1\n,2"));
        }

        [Test]
        public void ExtractDelimiters_WithCustomDelimiter_ReturnsCustomDelimiter()
        {
            string input = "//;\n1;2";
            char[] result = calc.ExtractDelimitersPublic(ref input);
            Assert.Multiple(() =>
            {
                Assert.That(result.SequenceEqual(new[] { ';' }), Is.True);
                Assert.That(input, Is.EqualTo("1;2"));
            });
        }

        [Test]
        public void ExtractDelimiters_WithoutCustomDelimiter_ReturnsDefaultDelimiters()
        {
            string input = "1,2\n3";
            char[] result = calc.ExtractDelimitersPublic(ref input);
            Assert.That(result.SequenceEqual(new[] { ',', '\n' }), Is.True);
        }

        [Test]
        public void CheckForNegativeNumbers_WithNegativeNumbers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => DummyCalculator.CheckForNegativeNumbersPublic(new[] { -1, -2 }));
        }

        [Test]
        public void ParseNumbers_ValidNumbers_ReturnsCorrectlyParsedNumbers()
        {
            IEnumerable<int> result = DummyCalculator.ParseNumbersPublic("1,2\n3", new[] { ',', '\n' });
            Assert.That(result.SequenceEqual(new[] { 1, 2, 3 }), Is.True);
        }

        [Test]
        public void ParseNumbers_InvalidNumbers_ReturnsZero()
        {
            IEnumerable<int> result = DummyCalculator.ParseNumbersPublic("1,abc\n3", new[] { ',', '\n' });
            Assert.That(result.SequenceEqual(new[] { 1, 0, 3 }), Is.True);
        }

        [Test]
        public void ParseNumbers_NumbersAbove1000_ReturnsZero()
        {
            IEnumerable<int> result = DummyCalculator.ParseNumbersPublic("1,1001\n3", new[] { ',', '\n' });
            Assert.That(result.SequenceEqual(new[] { 1, 0, 3 }), Is.True);
        }
    }
}