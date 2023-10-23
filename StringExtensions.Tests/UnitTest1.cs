namespace StringExtensions.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Method_Should_Return_False()
        {
            //ACT					 
            var actual = StringExtensionsClass.StringExtensions("c");
            var actualC = StringExtensionsClass.StringExtensions("C");
            var actualD = StringExtensionsClass.StringExtensions("hello I AM DONALD");  

            //ASSERT
            Assert.False(actual);
            Assert.True(actualC);
            Assert.False(actualD);
        }
    }
}