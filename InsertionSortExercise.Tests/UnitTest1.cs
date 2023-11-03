namespace InsertionSortExercise.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void InsertionSortMethodSortsAnArrayInAscendingOrder()
        {
            //ARRANGE					
            int[] array =       { 1, 2, 3, 33, 5 };
            int[] sortedArray = { 1, 2, 3, 5, 33 };

            //ACT
            InsertionSortExerciseClass.InsertionSort(array, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        }


    }
}