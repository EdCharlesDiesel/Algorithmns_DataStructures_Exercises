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

        public int binarysearchRecursion(int[] A, int key, int l, int r)
        {
            if (l > r)
                return -1;
            else
            {
                int mid = (l + r) / 2;
                if (key == A[mid])
                    return mid;
                else if (key < A[mid])
                    return binarysearchRecursion(A, key, l, mid - 1);
                else if (key > A[mid])
                    return binarysearchRecursion(A, key, mid + 1, r);
            }
            return -1;
        }
    }
}