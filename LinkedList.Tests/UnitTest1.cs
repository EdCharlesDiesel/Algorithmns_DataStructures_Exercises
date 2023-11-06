namespace LinkedList.Tests
{
    public class UnitTest1
    {

		[Fact]
		public void LengthFunctionReturnsNodesSize()
		{
            //ARRANGE
            LinkedListClass linkedListClass = new LinkedListClass();


            //ACT
            var actual = linkedListClass.Count();

            //ASSERT
            Assert.Equal(0,actual);
        }

        [Fact(Skip ="Exceptions need to be implemented")]
        public void LengthFunctionReturnsArgumentNullException()
        {
            //ARRANGE
            LinkedListClass linkedListClass = new LinkedListClass();


            //ACT
            var actual = linkedListClass.Count();

            //ASSERT
            Assert.Throws<NullReferenceException>(() => actual);           
        }


    }
}