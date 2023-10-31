using System;

namespace LongestIncreasingSequence.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void Method_Should_Return_False()
		{
            //ARRANGE					 
            int[] arrayOne = { 6 ,7 ,2 ,3 ,4 ,1 };
            int[] expected = { 2 ,3 ,4 };

            //ACT	
            var actual = LongestIncreasingSequenceClass.LongestIncreasingSequence(arrayOne);

            //ASSERT	

            Assert.Equal(expected,actual);
        }
	}
}