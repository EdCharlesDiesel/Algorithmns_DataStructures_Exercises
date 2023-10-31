namespace ArraysAreEqual
{
    /// <summary>
    /// Write a program, which reads two arrays from the console and 
    /// checks whether they are equal (two arrays are equal when they 
    /// are of equal length and all of their elements, which have 
    /// the same index, are equal).
    /// </summary>
    public class ArraysAreEqualClass
    {
        public static bool ArraysEqual(int[] arrayOne, int[] arrayTwo)
        {   

            int[] arr1 = new int[arrayOne.Length];
            for (int i = 0; i < arrayOne.Length; i++)
            {
                arr1[i] = arrayOne[i];
            }
            int[] arr2 = new int[arrayTwo.Length];
            for (int i = 0; i < arrayTwo.Length; i++)
            {
                arr2[i] = arrayTwo[i];
            }

            int counterOfEqualElements = 0;
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] == arr2[i])
                    {
                        counterOfEqualElements++;
                    }
                }
                if (counterOfEqualElements == arr1.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int[] CheckArray(int[] array)
        {
            //array[0] = 1;
            //array[1] = 2;
            //array[2] = 3;
            //array[3] = 4;
            //array[4] = 5;
            //array[5] = 6;

            for (int i = 0; i <array.Length; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }

        public static int[,] GetBestPlatform(int[,] matrix)
        {
            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            int[,] newMatrix= new int[2,4];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    long sum = matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
             return   matrix;           
        }                  
                     

        public static int[,] MatriceArray(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j];
                }   
            }
            return matrix;
        }

        public static int[] ReverseArray(int[] initialArray)
        {
            // Get array size
            int length = initialArray.Length;
            // Declare and create the reversed array
            int[] reversed = new int[length];
            // Initialize the reversed array
            for (int index = 0; index < length; index++)
            {
                reversed[length - index - 1] = initialArray[index];
            }

            return reversed;
        }

        public static bool SymmetricArray(int[] arrayWithValue)
        {
            
            int n = arrayWithValue.Length;
            int[] array = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                array[i] = arrayWithValue[i];
            }
            bool symmetric = true;
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[n - i - 1])
                {
                    return symmetric = false;
                    break;
                }
            }
            return symmetric;
        }
    }
}