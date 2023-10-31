using System;

namespace ArraysAreEqual.Tests
{
    public class ArrraysAreEqualUnitTest
    {
        [Fact]
        public void Array_Should_Return_True()
        {
            //ARRANGE
            int[] arrayOne = { 1, 2, 3, 4, 4 };
            int[] arrayTwo = { 1, 2, 3, 4, 4 };

            //ACT
            bool answer = ArraysAreEqual.ArraysAreEqualClass.ArraysEqual(arrayOne, arrayTwo);

            //ASSERT
            Assert.True(answer);
        }

        [Fact]
        public void Array_Should_Return_False()
        {
            //ARRANGE
            int[] arrayOne = { 1, 2, 3, 4, 4 };
            int[] arrayThree = { 1, 2, 3, 4, 5 };

            //ACT
            bool answer = ArraysAreEqual.ArraysAreEqualClass.ArraysEqual(arrayOne, arrayThree);

            //ASSERT
            Assert.False(answer);
        }
 
        [Fact]
        public void CalculateArray()
        {

            //ASSERT
            int[] array = new int[6];
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            //ACT

            int[] actual = ArraysAreEqualClass.CheckArray(array);

            //ARRANGE
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void ReverseArray_Should_Return_Reversed_Array()
        {
            //ARRANGE	
            int[] initialArray = { 1, 2, 3, 4, 5, 6 };
            int[] expected = { 6, 5, 4,3,2,1};

            //ACT	
            int[] actual = ArraysAreEqualClass.ReverseArray(initialArray);

            //ASSERT	
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(actual[i], expected[i]);                
            }            
        }

        [Fact]
        public void SymmetricArray_Should_Return_False_If_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 5;
            int[] array = new int[length];
            int[] arrayWithValue = { 1,2,2,1};

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.True(actual);				 
        }

        [Fact]
        public void SymmetricArray_Should_Return_True_If_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 4;
            int[] array = new int[length];
            int[] arrayWithValue = { 1, 2, 2, 1 };

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.True(actual);
        }

        [Fact]
        public void SymmetricArray_Should_Return_True_If_Not_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 5;
            int[] array = new int[length];
            int[] arrayWithValue = { 1, 2, 2, 1 ,5};

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.False(actual);
        }

        [Fact]
        public void MatriceArray_Should_Return_MatriceValues()
        {
            //ARRANGE					 
            int[,] matrix =
            {               
               {1, 2, 3, 4}, // row 0 values
               {5, 6, 7, 8}, // row 1 value                
            };

            //ACT	
            var actual = ArraysAreEqualClass.MatriceArray(matrix);

            //ASSERT	
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.Equal(matrix[i,j], actual[i,j]);
                }                
            }
            
        }


        [Fact]
        public void MaxPlatform2x2_Should_Return_MaximumSum()
        {
            //ARRANGE					 
            int[,] matrix = {
            { 0, 2, 4, 0, 9, 5 },
            { 7, 1, 3, 3, 2, 1 },
            { 1, 3, 9, 8, 5, 6 },
            { 4, 6, 7, 9, 1, 0 }
            };

            int bestRow = 0;
            int bestCol = 0;
            //ACT
            var actual = ArraysAreEqualClass.GetBestPlatform(matrix);


            //ASSERT					 
            Assert.Equal(actual, matrix);
        }
    }
}