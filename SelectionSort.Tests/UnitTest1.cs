namespace SelectionSort.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void Method_Should_Return_False()
		{
            //ARRANGE					 
            SelectionSortClass selectionSort = new();
            int[] array  = { 3, 5, 8, 9, 6, 2 };

            //ACT				
            Array.Sort(array);
            var actual = selectionSort.SelectionSort(array,6);

            //ASSERT					 
            Assert.Equal(array, actual);
        }
    }
}