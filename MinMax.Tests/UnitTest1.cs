namespace MinMax.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(new int[] { -1, 20 }, MinMaxClass.minMax(new int[] { 1, 2, 5, -1, 12, 20 }));
            Assert.Equal(new int[] { 1, 5 }, MinMaxClass.minMax(new int[] { 1, 2, 3, 4, 5 }));
            Assert.Equal(new int[] { -3, 5 }, MinMaxClass.minMax(new int[] { 1, 2, -3, 4, 5 }));
        }
    }
}