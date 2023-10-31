namespace FindSubsequenceOfGivenSum.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void FindSubsequenceOfGivenSum_Should_Return_SubsequenceOfGivenSum()
		{
            //ARRANGE					 

            //ACT					 

            //ASSERT	
            //
                       int[] numbersArray = new int[] { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 13;

            var actul = FindSubsequenceOfGivenSumClass.FindSequenceOfGivenSum(numbersArray, sum);

        }


    }
}