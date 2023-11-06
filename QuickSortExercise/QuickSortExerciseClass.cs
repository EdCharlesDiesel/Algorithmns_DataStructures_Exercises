namespace QuickSortExercise
{
    public class QuickSortExerciseClass
    {
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low >high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi -1);
                QuickSort(array,pi + 1,high);
            }
            throw new NotImplementedException();

        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[low];
            int i = array[low+1];
            int j = array[high];

            do
            {
                while (i<= j && array[i]<= pivot)
                {
                    i=i+1;
                }
                while (i <= j && array[j] > pivot)
                    j = j - 1;
                if (i <= j)
                    Swap(array, i, j);

            } while (i<j);
            Swap(array, low, j);
            return j;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
} 