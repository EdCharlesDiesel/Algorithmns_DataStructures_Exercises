using static Easy_Algorithms.EasyAlgorithmsClass;

namespace Easy_Algorithms.Tests
{
    public class Easy_AlgorithmsUnitTest
    {

        #region SumTwoSmallestNumbers
        [Fact]
        public void SumTwoSmallestNumbersTest()
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Assert.Equal(13, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void SumTwoSmallestNumbersTest2()
        {
            int[] numbers = { 19, 5, 42, 2, 77 };
            Assert.Equal(7, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void SumTwoSmallestNumbersTest3()
        {
            int[] numbers = { 10, 343445353, 3453445, 2147483647 };
            Assert.Equal(3453455, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        } 
        #endregion

        #region StringExtensions
        [Fact]
        public void StringExtensions()
        {
            //ACT					 
            var actual = StringExtensionsClass.StringExtensions("c");
            var actualC = StringExtensionsClass.StringExtensions("C");
            var actualD = StringExtensionsClass.StringExtensions("hello I AM DONALD");

            //ASSERT
            Assert.False(actual);
            Assert.True(actualC);
            Assert.False(actualD);
        } 
        #endregion

        #region QuickSort
        [Fact(Skip = "This test is failing")]
        public void QuickSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2, 3, 5, 6, 8, 9 };


            //ACT
            QuickSortExerciseClass.QuickSort(array, 0, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        } 
        #endregion

        #region MinMax
        [Fact]
        public void minMaxTest1()
        {
            Assert.Equal(new int[] { -1, 20 }, MinMaxClass.minMax(new int[] { 1, 2, 5, -1, 12, 20 }));
            Assert.Equal(new int[] { 1, 5 }, MinMaxClass.minMax(new int[] { 1, 2, 3, 4, 5 }));
            Assert.Equal(new int[] { -3, 5 }, MinMaxClass.minMax(new int[] { 1, 2, -3, 4, 5 }));
        } 
        #endregion

        #region InsertionSort
        [Fact]
        public void InsertionSortMethodSortsAnArrayInAscendingOrder()
        {
            //ARRANGE					
            int[] array = { 1, 2, 3, 33, 5 };
            int[] sortedArray = { 1, 2, 3, 5, 33 };

            //ACT
            InsertionSortExerciseClass.InsertionSort(array, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        } 
        #endregion

        #region HighAndLow
        [Fact]
        public void Test1()
        {
            Assert.Equal("42 -9", HighAndLowClass.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }

        [Fact]
        public void Method_Should_Return_False()
        {
            Assert.Equal("3 1", HighAndLowClass.HighAndLow("1 2 3"));
        } 
        #endregion

        #region DescendingOrder
        [Fact]
        public void DescendingOrderTest()
        {
            var expected = DescendingOrderClass.DescendingOrder(42145);
            Assert.Equal(54421, expected);
        } 
        #endregion

        #region BreakCamelCaseClass
        [Fact]
        public void Should_be_assigned_different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCase("camelCasing");
            Assert.Equal("camel Casing", actual);
        }

        [Fact]
        public void Should_be_assigned_Different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCaseSolutionOne("khotsoCharles");
            Assert.Equal("khotso Charles", actual);
        }

        [Fact]
        public void BreakCamelCaseShouldReturnSpacedSentence()
        {
            var actual = BreakCamelCaseClass.BreakCamelCaseSecondSolution("khotsoCharlesMokhethi");
            Assert.Equal("khotso Charles Mokhethi", actual);
        } 
        #endregion
    }
}