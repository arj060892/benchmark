namespace StringBasedCalculator.App.Tests
{
    [TestFixture]
    public class AddCalculatorShould
    {
        private AddCalculator addCalculator;

        [SetUp]
        public void Setup()
        {
            addCalculator = new AddCalculator();
        }

        [Test]
        public void Calculate_EmptyList_ReturnsZero()
        {
            int result = addCalculator.Calculate(new List<int>());
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Calculate_ValidNumbers_ReturnsSum()
        {
            int result = addCalculator.Calculate(new[] { 1, 2, 3, 4, 5 });
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void ValidateInput_ValidInput_ReturnsParsedNumbers()
        {
            addCalculator.ValidateInput("1,2\n3", out IEnumerable<int> result);
            Assert.That(result.SequenceEqual(new[] { 1, 2, 3 }), Is.True);
        }

        [Test]
        public void ValidateInput_InputWithCustomDelimiter_ReturnsParsedNumbers()
        {
            addCalculator.ValidateInput("//;\n1;2;3", out IEnumerable<int> result);
            Assert.That(result.SequenceEqual(new[] { 1, 2, 3 }), Is.True);
        }

        [Test]
        public void ValidateInput_InputWithInvalidFormat_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => addCalculator.ValidateInput("1,\n2", out IEnumerable<int> result));
        }

        [Test]
        public void ValidateInput_InputWithNegativeNumbers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => addCalculator.ValidateInput("1,2,-3", out IEnumerable<int> result));
        }

        [Test]
        public void ValidateInput_InputWithNumbersAbove1000_ReturnsZeroForThoseNumbers()
        {
            addCalculator.ValidateInput("1,1001\n3", out IEnumerable<int> result);
            Assert.That(result.SequenceEqual(new[] { 1, 0, 3 }), Is.True);
        }
    }
}