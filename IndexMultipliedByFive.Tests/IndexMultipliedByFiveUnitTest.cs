namespace IndexMultipliedByFive.Tests
{
    public class IndexMultipliedByFiveUnitTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int[] array = new int[20];

            //Act
            int[] expected = new int[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95 };
            var actual = IndexMultipliedByFiveClass.IndexMultipliedByFive(array);

            //Assert

            Assert.Equal(expected, actual);

        }
    }
}