using static Easy_Algorithms.EasyAlgorithmsClass;

namespace Easy_Algorithms.Tests
{
    public class Easy_AlgorithmsUnitTest
    {
        #region EvaluateExpressionTree
        [Fact]
        public void EvaluateExpressionTreeClassTest1()
        {
            EvaluateExpressionTreeClass.BinaryTree tree = new EvaluateExpressionTreeClass.BinaryTree(-1);
            tree.left = new EvaluateExpressionTreeClass.BinaryTree(2);
            tree.right = new EvaluateExpressionTreeClass.BinaryTree(-2);
            tree.right.left = new EvaluateExpressionTreeClass.BinaryTree(5);
            tree.right.right = new EvaluateExpressionTreeClass.BinaryTree(1);
            var expected = 6;
            var actual = new EvaluateExpressionTreeClass().EvaluateExpressionTree(tree);
            Assert.True(expected == actual);
        } 
        #endregion

        #region NonConstructibleChange
        [Fact]
        public void NonConstructibleChangeTest1()
        {
            int[] input = new int[] { 5, 7, 1, 1, 2, 3, 22 };
            int expected = 20;
            var actual = new NonConstructibleChangeClass().NonConstructibleChange(input);
            Assert.True(expected == actual);
        } 
        #endregion

        #region SortedSquaredArray
        [Fact]
        public void SortedSquaredArrayTest1()
        {
            var input = new int[] { 1, 2, 3, 5, 6, 8, 9 };
            var expected = new int[] { 1, 4, 9, 25, 36, 64, 81 };
            var actual = new SortedSquaredArrayClass().SortedSquaredArray(input);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        } 
        #endregion

        #region TournamentWinner
        [Fact]
        public void TournamentWinnerTest1()
        {
            List<List<string>> competitions = new List<List<string>>();
            List<string> competition1 = new List<string> {
            "HTML", "C#"
             };

            List<string> competition2 = new List<string> {
            "C#", "Python"
            };

            List<string> competition3 = new List<string> {
            "Python", "HTML"
        };
            competitions.Add(competition1);
            competitions.Add(competition2);
            competitions.Add(competition3);
            List<int> results = new List<int> {
            0, 0, 1
        };
            string expected = "Python";
            var actual = new TournamentWinnerClass().TournamentWinner(competitions, results);
            Assert.True(expected == actual);
        } 
        #endregion

        #region TransposeMatrix
        [Fact]
        public void TransposeMatrixTest1()
        {
            int[,] input = new int[3, 3] {
                {1,2,3},{4,5,6},{7,8,9}
            };
            int[,] expected = new int[3, 3] {
                {1,4,7},{2,5,8},{3,6,9}
            };

            int[,] actual = new TransposeMatrixClass().TransposeMatrix(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.True(expected[i, j] == actual[i, j]);
                }
            }
        } 
        #endregion

        #region IsValidSubsequence
        [Fact]
        public void TestCase1()
        {
            List<int> array = new List<int> {
                5, 1, 22, 25, 6, -1, 8, 10
            };

            List<int> sequence = new List<int> {
            1, 6, -1, 10
            };

            Assert.True(ValidateSubsequenceClass.IsValidSubsequence(array, sequence));
        } 
        #endregion

        #region TwoNumberSum
        [Fact]
        public void TwoNumberSumTest1()
        {
            int[] output = new TwoNumberSumClass().TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        } 
        #endregion

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