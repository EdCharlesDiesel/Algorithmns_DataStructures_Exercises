using BinarySearchRecursive;

namespace BinarySearchRecursive
{
    public class BinarySearchRecursiveClass
    {
        /// <summary>
        /// Write a function that takes in a sorted array of integers as well as a target integer.
        /// The function should use the Binary Search algorithmn to determine if the target integer
        /// is contained in the array and should return it's index if it is, otherwise -1.        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="key"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int binarysearch(int[] A, int key, int l, int r)
        {
            if (l > r)
                return -1;
            else
            {
                int mid = (l + r) / 2;
                if (key == A[mid])
                    return mid;
                else if (key < A[mid])
                    return binarysearch(A, key, l, mid - 1);
                else if (key > A[mid])
                    return binarysearch(A, key, mid + 1, r);
            }
            return -1;
        }
    }
}


