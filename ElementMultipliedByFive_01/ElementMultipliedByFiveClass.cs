namespace ElementMultipliedByFive_01
{  
    /// <summary>
    /// Write a program, which creates an array of 20 elements of type integer and 
    /// initializes each of the elements with a value equals to the index of the 
    /// element multiplied by 5. Print the elements to the console.
    /// </summary>
    public static class ElementMultipliedByFiveClass
    {
        public static int[] MultiplyByFive(int[] arrayOfTwenty)
        {
            List<int> result = new List<int>();

            int muliplier = 0;
            if (arrayOfTwenty.Length > 20)
            {
                new ArgumentOutOfRangeException("Please provide values no less than more than 20");
            }

            for (int i = 0; i < arrayOfTwenty.Length; i++)
            {
                muliplier = arrayOfTwenty[i] * 5;

                result.Add(muliplier);
            }
            return result.ToArray();
        }

    }

}