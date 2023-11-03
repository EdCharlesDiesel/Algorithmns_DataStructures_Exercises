namespace ShellSort
{
    public static class ShellSortClass
    {
        public static void ShellSort(int[] array, int length)
        {
            int gap = length / 2;
            while (gap > 0)
            {
                int i = gap;
                while (i < length)
                {
                    int temp = array[i];
                    int j = i - gap;
                    while (j >= 0 && array[j] > temp)
                    {
                        array[j + gap] = array[j];
                        j = j - gap;
                    }
                    array[j + gap] = temp;
                    i = i + 1;
                }
                gap = gap / 2;
            }
        }
    }
}