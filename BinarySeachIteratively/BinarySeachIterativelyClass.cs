namespace BinarySeachIteratively
{
    public class BinarySeachIterativelyClass
    {
        public int binarySearchIteritevely(int[] inputArray, int numberOfElements, int key)
        {
            Array.Sort(inputArray);
            int leftIndex = 0;
            int rightIndex = numberOfElements - 1;
            while (leftIndex <= rightIndex)
            {
                int middleElement = (leftIndex + rightIndex) / 2;
                if (key == inputArray[middleElement])
                    return middleElement;
                else if (key < inputArray[middleElement])
                    rightIndex = middleElement - 1;
                else if (key > inputArray[middleElement])
                    leftIndex = middleElement + 1;
            }
            return -1;
        }
    }
}