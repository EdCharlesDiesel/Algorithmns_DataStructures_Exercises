namespace BinarySeachIteratively.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BinarySearchIteritevelyShouldReturnIndex()
        {
            //ARRANGE					
            int key = 86;
            int[] inputArray = { 15, 86, 25, 31, 22 };
            int numberOfElements = 5;

            //ACT					 
            var seachIteritively = new BinarySeachIterativelyClass()
                                       .BinarySearchIteritevely(inputArray, numberOfElements, key);

            //ASSERT				
            Assert.Equal(4, seachIteritively);	 
        }

        [Fact]
        public void BinarysearchRecursionShouldReturnIndex()
        {
            //ARRANGE              
            int[] inputArray = { 15, 21, 47, 84, 96 };
            

            //ACT					 
            var seachIteritively = new BinarySeachIterativelyClass()
                                       .BinarysearchRecursion(inputArray,96, 0, 4);

            //ASSERT				
            Assert.Equal(4, seachIteritively);
        }

    }
}