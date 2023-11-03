namespace InsertionSortExercise
{
    public class InsertionSortExerciseClass
    {
        public static void InsertionSort(int[] array, int limit)
        {
            for (int i = 1; i < limit; i++)
            {
                int temp = array[i];
                int position = i;

                while (position > 0 && array[position- 1] > temp) 
                {
                    array[position] = array[position- 1];
                    position = position - 1;
                }

                array[position] = temp;
            }
        }
    }
}