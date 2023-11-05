namespace MergeSort
{
    public static class MergeSortClass
    {
        public static void MergeSort(int[] arrayOne, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arrayOne, left, mid);
                MergeSort(arrayOne, mid + 1, right);
                Merge(arrayOne, left, mid, right);
            }
        }

        public static void Merge(int[] arrayOne, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;
            int[] arrayTwo = new int[right + 1];
            while (i <= mid && j <= right)
            {
                if (arrayOne[i] < arrayOne[j])
                {
                    arrayTwo[k] = arrayOne[i];
                    i = i + 1;
                }
                else
                {
                    arrayTwo[k] = arrayOne[j];
                    j = j + 1;
                }
                k = k + 1;
            }
            while (i <= mid)
            {
                arrayTwo[k] = arrayOne[i];
                i = i + 1;
                k = k + 1;
            }
            while (j <= right)
            {
                arrayTwo[k] = arrayOne[j];
                j = j + 1;
                k = k + 1;
            }
            for (int x = left; x < right + 1; x++)
                arrayOne[x] = arrayTwo[x];
        }
    }
}