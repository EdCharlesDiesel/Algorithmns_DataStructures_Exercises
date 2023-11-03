namespace BubbleSort.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //ARRANGE
            BubbleSortClass bubbleSort = new();
            					 
           
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] arraySorted = { 2, 3, 5, 6, 8, 9 };

            //ACT
            bubbleSort.Bubblesort(array, 6);

            //ASSERT
            Assert.Equal(array, arraySorted);
            
        }
    }
}