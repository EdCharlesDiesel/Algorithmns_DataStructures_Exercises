namespace HighAndLow.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("42 -9", HighAndLowClass.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }

        [Fact]
        public void Method_Should_Return_False()
        {     
            Assert.Equal("3 1", HighAndLowClass.HighAndLow("1 2 3"));
        }
    }    
}