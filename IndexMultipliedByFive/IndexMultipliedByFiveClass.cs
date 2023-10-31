namespace IndexMultipliedByFive
{
    /// <summary>
    /// Write a program, which creates an array of 20 elements of type integer and
    /// initializes each of the elements with a value equals to the index of 
    /// the element multiplied by 5. Print the elements to the console.
    /// </summary>
    public static class IndexMultipliedByFiveClass
    {
      
        public static IEnumerable<int> IndexMultipliedByFive(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            return array;
        }
    }
}