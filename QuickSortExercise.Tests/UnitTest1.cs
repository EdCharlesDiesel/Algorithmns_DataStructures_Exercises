namespace QuickSortExercise.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void QuickSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2, 3, 5, 6, 8, 9 };


            //ACT
            QuickSortExerciseClass.QuickSort(array, 0, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        }
    }
}