namespace SearchingAlgorithmns.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void LinearSearch_Should_Return_Element_Not_Found()
        {
            Search s = new();
            int[] A = { 84, 21, 47, 96, 15 };
            int found = Search.Linearsearch(A, 5, 100);

            Assert.NotEqual(100, found);
        }


        [Fact]
        public void LinearSearch_Should_Return_Element_Found()
        {
            //ARRANGE					 
            Search s = new();
            int[] A = { 84, 21, 47, 96, 15 };

            //ACT					 
            int found = Search.Linearsearch(A, 5, 21);

            //ASSERT
            Assert.Equal(1, found);
        }


        [Fact]
        public void LinearSearch_Should_Return_Element_Found_Three()
        {
            //ARRANGE					 
            Search search = new();
            int[] A = { 6, 5, 89, 22, 3, 5, 8 };

            //ACT					 
            var actual = Search.Linearsearch(A, 7, 22);

            //ASSERT					 
            Assert.Equal(3, actual);
        }


    }
}