namespace SumArrays
{
    public static class SumArrayClass
    {
        /// <summary>
        /// Write a function that takes an array of numbers 
        /// and returns the sum of the numbers. The numbers 
        /// can be negative or non-integer. If the array 
        /// does not contain any numbers then you should return 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double SumArray(double[] array)
        {
            double[] newArray = new double[array.Length];
            double sumArray = 0;

            foreach (var item in array)
            {
                sumArray = item + item;
            }

            return sumArray;
        }

    }
}