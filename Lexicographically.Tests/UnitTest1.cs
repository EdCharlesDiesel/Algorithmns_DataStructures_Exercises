namespace Lexicographically.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void Lexicographically_Should_Return_First_Lexicographically()
		{
            //ARRANGE					 
            string inputArr1 = "Apple";
            string inputArr2 = "Windows";
            string expected = "Apple";

            //ACT
            var actial= LexicographicallyClass.Lexicographically(inputArr1, inputArr2);            					 

            //ASSERT					 
            Assert.Equal(expected, actial);
        }
    }
}