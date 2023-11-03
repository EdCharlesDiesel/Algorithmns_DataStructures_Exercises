namespace InsertionSort.Tests
{
    public class UnitTest1
    {
		[Fact]
		public void Method_Should_Return_False()
		{
            //ARRANGE					 
            InsertionSortClass insertionSort = new();
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] arraySorted = { 2, 3, 5, 6, 8, 9 };

            //ACT
            insertionSort.InsertionSort(array, 6);            

            //ASSERT
            Assert.Equal(array, arraySorted);					 
        }
	}
}