namespace SearchingAlgorithmns.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Search s = new Search();
            int[] A = { 84, 21, 47, 96, 15 };
            int found = s.linearsearch(A, 5, 100);

            Assert.NotEqual(100, found);
            //Assert.Equal(21, found);
        }
    }
}