namespace SumTwoSmallestNumbers.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Assert.Equal(13, SumTwoSmallestNumbersClass.sumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void Test2()
        {
            int[] numbers = { 19, 5, 42, 2, 77 };
            Assert.Equal(7, SumTwoSmallestNumbersClass.sumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void Test3()
        {
            int[] numbers = { 10, 343445353, 3453445, 2147483647 };
            Assert.Equal(3453455, SumTwoSmallestNumbersClass.sumTwoSmallestNumbers(numbers));
        }
    }
}