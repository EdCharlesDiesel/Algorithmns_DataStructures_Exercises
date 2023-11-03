using ShellSort;
namespace ShellSort.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShellSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2,3,5,6,8,9 };


            //ACT
            ShellSortClass.ShellSort(array, 6);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        }
    }
}