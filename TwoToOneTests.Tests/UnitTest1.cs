namespace TwoToOneTests.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("aehrsty", TwoToOneTestsClass.Longest("aretheyhere", "yestheyarehere"));
            Assert.Equal("abcdefghilnoprstu", TwoToOneTestsClass.LongestTwo("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.Equal("acefghilmnoprstuy", TwoToOneTestsClass.LongestDictionary("inmanylanguages", "theresapairoffunctions"));
        }
    }
}