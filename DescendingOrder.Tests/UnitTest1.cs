namespace DescendingOrder.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {            
            var expected = DescendingOrderClass.DescendingOrder(42145);
            Assert.Equal(54421, expected);
        }
    }
}