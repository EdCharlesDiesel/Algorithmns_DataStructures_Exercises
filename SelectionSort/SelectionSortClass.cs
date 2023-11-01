namespace SelectionSort
{
    public class SelectionSortClass
    {      

        public int[] SelectionSort(int[] array, int numberOfElements)
        {
            for (int i = 0; i < numberOfElements - 1; i++) 
            {
                int posistion = i;
                for (int j = i+1; j < numberOfElements; j++) 
                {
                    if (array[j] < array[posistion])
                    {
                        posistion = j;
                    }
                }

                int temp = array[i];
                array[i] = array[posistion];
                array[posistion] = temp;

            }

            return array;
        }
    }
}