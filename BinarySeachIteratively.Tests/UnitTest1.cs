namespace BinarySeachIteratively.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void binarySearchIteritevely_Should_Return_Index()
        {
            //ARRANGE					
            int key = 86;
            int[] inputArray = { 15, 86, 25, 31, 22 };
            int numberOfElements = 5;

            //ACT					 
            var seachIteritively = new BinarySeachIterativelyClass()
                                       .binarySearchIteritevely(inputArray, numberOfElements, key);

            //ASSERT				
            Assert.Equal(4, seachIteritively);	 
        }


    }
}