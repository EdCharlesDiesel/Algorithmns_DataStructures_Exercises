namespace Medium_Algorithms
{
    public class MediumAlgorithmsClass
    {
        #region ThreeNumberSum
        /// <summary>
        /// Write a function that takes in a non-empty array of distinct intergers and the integers
        /// representing a target sum
        /// </summary>
        public class ThreeNumberSumClass
        {
            public static List<int[]> ThreeNumberSum(int[] inputArray, int targetSum)
            {
                Array.Sort(inputArray);
                List<int[]> triplets = new List<int[]>();
                for (int i = 0; i < inputArray.Length - 2; i++)
                {
                    var left = i + 1;
                    int right = inputArray.Length - 1;
                    while (left < right)
                    {
                        int currentSum = inputArray[i] + inputArray[left] + inputArray[right];
                        if (currentSum == targetSum)
                        {
                            int[] newTriplet = { inputArray[i], inputArray[left], inputArray[right] };
                            triplets.Add(newTriplet);
                            left++;
                            right--;
                        }
                        else if (currentSum < targetSum)
                        {
                            left++;
                        }
                        else if (currentSum > targetSum)
                        {
                            right--;
                        }
                    }
                }

                return triplets;
            }
        }
        #endregion

        #region SmallestDifference
        /// <summary>
        /// 
        /// </summary>
        public class SmallestDifferenceClass
        {
            public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
            {
                // Write your code here.
                Array.Sort(arrayOne);
                Array.Sort(arrayTwo);
                int indexOne = 0;
                int indexTwo = 0;
                int smallest = Int32.MaxValue;
                int current = Int32.MaxValue;
                int[] smallestpair = new int[2];
                while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length)
                {
                    int firstNumber = arrayOne[indexOne];
                    int secondNumber = arrayTwo[indexTwo];

                    if (firstNumber < secondNumber)
                    {
                        current = secondNumber - firstNumber;
                        indexOne++;
                    }
                    else if (secondNumber < firstNumber)
                    {
                        current = firstNumber - secondNumber;
                        indexTwo++;
                    }
                    else
                    {
                        return new int[] { firstNumber, secondNumber };
                    }

                    if (smallest > current)
                    {
                        smallest = current;
                        smallestpair = new int[] { firstNumber, secondNumber };
                    }
                }
                return smallestpair;
            }
        }
        #endregion

        #region MoveElementToEnd
        /// <summary>
        /// 
        /// </summary>
        public class MoveElementToEndClass
        {
            public static List<int> MoveElementToEnd(List<int> array, int toMove)
            {
                int i = 0;
                int j = array.Count - 1;
                while (i < j)
                {
                    while (i < j && array[j] == toMove) j--;
                    if (array[i] == toMove) Swap(i, j, array);
                    i++;
                }

                return array;
            }

            private static void Swap(int i, int j, List<int> array)
            {
                int temop = array[j];
                array[j] = array[i];
                array[i] = temop;
            }
        }
        #endregion

        #region IsMonotonic
        /// <summary>
        /// 
        /// </summary>
        public static class IsMonotonicClass
        {
            public static bool IsMonotonic(int[] array)
            {
                // Write your code here.
                var isNonDecreasing = true;
                var isNonIncreasing = true;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        isNonDecreasing = false;
                    }

                    if (array[i] > array[i - 1])
                    {
                        isNonIncreasing = false;
                    }
                }

                return isNonDecreasing || isNonIncreasing;
            }
        }
        #endregion

        #region SpiralTraverse
        /// <summary>
        /// 
        /// </summary>
        public class SpiralTraverseClass
        {
            public static List<int> SpiralTraverse(int[,] array)
            {
                // Write your code here.
                if (array.GetLength(0) == 0) return new List<int>();

                var result = new List<int>();
                var startRow = 0;
                var endRow = array.GetLength(0) - 1;
                var startCol = 0;
                var endCol = array.GetLength(1) - 1;
                while (startRow <= endRow && startCol <= endCol)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        result.Add(array[startRow, col]);
                    }

                    for (int row = startRow + 1; row <= endRow; row++)
                    {
                        result.Add(array[row, endCol]);
                    }

                    for (int col = endCol - 1; col >= startCol; col--)
                    {
                        // Handle the edge case there's a single row
                        // in the middle of the matrix. In this case, we don't
                        // want  to double-count the values in this row, which
                        // we've already counted inthe first the loop above.
                        // See the test Case 8 for an example of this edge case
                        if (startRow == endRow) break;
                        result.Add(array[endRow, col]);

                    }

                    for (int row = endRow - 1; row > startRow; row--)
                    {
                        // handle the edge case when there's a sing;e column
                        // in the middle of the matrix. In this case, we don't
                        // want to double-count the values in the column, which
                        // we've already counted in the second for loop above.
                        // See Test case 9 for an example of the edge case.

                        if (startCol == endCol) break;
                        result.Add(array[row, startCol]);
                    }

                    startRow++;
                    endRow--;
                    startCol++;
                    endCol--;
                }

                return result;
            }
        }
        #endregion

        #region LongestPeak
        /// <summary>
        /// 
        /// </summary>
        public class LongestPeakClass
        {
            public static int LongestPeak(int[] array)
            {
                // Write your code here.
                int longestPeakLength = 0;
                int i = 1;
                while (i < array.Length - 1)
                {
                    bool isPeak = array[i - 1] < array[i] && array[i] > array[i + 1];
                    if (!isPeak)
                    {
                        i += 1;
                        continue;
                    }

                    int leftIndex = i - 2;
                    while (leftIndex >= 0 && array[leftIndex] < array[leftIndex + 1])
                    {
                        leftIndex -= 1;
                    }

                    int rightIndex = i + 2;
                    while (rightIndex < array.Length && array[rightIndex] < array[rightIndex - 1])
                    {
                        rightIndex += 1;
                    }

                    int currentPeakLenghth = rightIndex - leftIndex - 1;
                    if (currentPeakLenghth > longestPeakLength)
                    {
                        longestPeakLength = currentPeakLenghth;
                    }

                    i = rightIndex;
                }

                return longestPeakLength;

            }
        }
        #endregion

        #region ArrayOfProducts
        /// <summary>
        /// 
        /// </summary>
        public class ArrayOfProductsClass
        {
            public int[] ArrayOfProducts(int[] array)
            {
                int[] products = new int[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    int runningProduct = 1;
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (i != j)
                        {
                            runningProduct *= array[j];
                        }
                        products[i] = runningProduct;
                    }
                }

                return products;
            }
        }
        #endregion

        #region FirstDuplicateValue
        /// <summary>
        /// 
        /// </summary>
        public class FirstDuplicateValueClass
        {
            public int FirstDuplicateValue(int[] array)
            {
                int minimumSecondIndex = array.Length;
                for (int i = 0; i < array.Length; i++)
                {
                    int value = array[i];
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        int valueToCompare = array[j];
                        if (value == valueToCompare)
                        {
                            minimumSecondIndex = Math.Min(minimumSecondIndex, j);
                        }
                    }
                }

                if (minimumSecondIndex == array.Length)
                {
                    return -1;
                }


                return array[minimumSecondIndex];
            }
        }
        #endregion

        #region MergeOverlappingIntervals
        /// <summary>
        /// 
        /// </summary>
        public class MergeOverlappingIntervalsClass
        {
            public int[][] MergeOverlappingIntervals(int[][] intervals)
            {


                int[][] sortedIntervals = intervals.Clone() as int[][];
                Array.Sort(sortedIntervals, (a, b) => a[0].CompareTo(b[0]));

                List<int[]> mergedIntervals = new List<int[]>();
                int[] currentIntevaal = sortedIntervals[0];
                mergedIntervals.Add(currentIntevaal);

                foreach (var nextInterval in sortedIntervals)
                {
                    int currentIntervalEnd = currentIntevaal[1];
                    int nextIntervalStart = nextInterval[0];
                    int nextIntervalEnd = nextInterval[1];

                    if (currentIntervalEnd >= nextIntervalStart)
                    {
                        currentIntevaal[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
                    }
                    else
                    {
                        currentIntevaal = nextInterval;
                        mergedIntervals.Add(currentIntevaal);
                    }
                }

                return mergedIntervals.ToArray();
            }
        }
        #endregion

        #region BestSeat
        /// <summary>
        /// 
        /// </summary>
        public class BestSeatClass
        {
            public int BestSeat(int[] seats)
            {
                int bestSeat = -1;
                int maxSpace = 0;

                int left = 0;
                while (left < seats.Length)
                {
                    int right = left + 1;
                    while (right < seats.Length && seats[right] == 0)
                    {
                        right++;
                    }

                    int availableSpace = right - left - 1;
                    if (availableSpace > maxSpace)
                    {
                        bestSeat = (left + right) / 2;
                        maxSpace = availableSpace;
                    }
                    left = right;
                }
                return bestSeat;
            }
        }
        #endregion

        #region ZeroSumSubarray
        public class ZeroSumSubarrayClass
        {
            public bool ZeroSumSubarray(int[] nums)
            {
                HashSet<int> sums = new HashSet<int>();
                sums.Add(0);
                int currentSum = 0;
                foreach (int i in nums)
                {
                    currentSum += i;
                    if (sums.Contains(currentSum))
                    {
                        return true;
                    }
                    sums.Add(currentSum);
                }

                return false;
            }
        }
        #endregion

        #region MissingNumbers
        /// <summary>
        /// 
        /// </summary>
        public class MissingNumbersClass
        {
            public int[] MissingNumbers(int[] numbers)
            {
                // Write your code here.
                HashSet<int> includedNums = new HashSet<int>();
                foreach (int number in numbers)
                {
                    includedNums.Add(number);
                }
                int[] solution = new int[] { -1, -1 };
                for (int num = 1; num < numbers.Length + 3; num++)
                {
                    if (!includedNums.Contains(num))
                    {
                        if (solution[0] == -1)
                        {
                            solution[0] = num;
                        }
                        else
                        {
                            solution[1] = num;
                        }
                    }
                }

                return solution;
            }
        }
        #endregion

        #region MajorityElement
        /// <summary>
        /// 
        /// </summary>
        public class MajorityElementClass
        {
            public int MajorityElement(int[] array)
            {
                int answer = 0;

                for (int currentBit = 0; currentBit < 32; currentBit++)
                {
                    int currentBitValue = 1 << currentBit;
                    int onesCount = 0;
                    foreach (int bit in array)
                    {
                        if ((bit & currentBitValue) != 0)
                        {
                            onesCount++;
                        }
                    }

                    if (onesCount > array.Length / 2)
                    {
                        answer += currentBitValue;
                    }
                }
                return answer;
            }
        }
        #endregion

        #region SweetAndSavory
        /// <summary>
        /// 
        /// </summary>
        public class SweetAndSavoryClass
        {
            public int[] SweetAndSavory(int[] dishes, int target)
            {
                List<int> sweetDishes = new List<int>();
                List<int> savouryDishes = new List<int>();

                foreach (var dish in dishes)
                {
                    if (dish < 0)
                    {
                        sweetDishes.Add(dish);
                    }
                    else
                    {
                        savouryDishes.Add(dish);
                    }
                }

                sweetDishes.Sort((a, b) => Math.Abs(a) - Math.Abs(b));
                savouryDishes.Sort();

                int[] bestPair = new int[2];
                int bestDifference = Int32.MaxValue;
                int sweetIndex = 0, savoryIndex = 0;

                while (sweetIndex < sweetDishes.Count && savoryIndex < savouryDishes.Count)
                {
                    int currentSum = sweetDishes[sweetIndex] + savouryDishes[savoryIndex];

                    if (currentSum <= target)
                    {
                        int currentDifference = target - currentSum;
                        if (currentDifference < bestDifference)
                        {
                            bestDifference = currentDifference;
                            bestPair[0] = sweetDishes[sweetIndex];
                            bestPair[1] = savouryDishes[savoryIndex];
                        }
                        savoryIndex++;
                    }
                    else
                    {
                        sweetIndex++;
                    }
                }

                return bestPair;
            }
        }
        #endregion

        #region BSTConstruction
        /// <summary>
        /// 
        /// </summary>
        public class BSTConstructionClass
        {
            public int value;
            public BSTConstructionClass left;
            public BSTConstructionClass right;

            public BSTConstructionClass(int value)
            {
                this.value = value;
            }

            // Average: O(log(n)) time | O(log(n)) space
            // Worst: O(n) time | O(n) space
            public BSTConstructionClass Insert(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        BSTConstructionClass newBST = new BSTConstructionClass(value);
                        left = newBST;
                    }
                    else
                    {
                        left.Insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        var newBST = new BSTConstructionClass(value);
                        right = newBST;
                    }
                    else
                    {
                        right.Insert(value);
                    }
                }
                return this;
            }
            // Average: O(log(n)) time | O(log(n)) space
            // Worst: O(n) time | O(n) space
            public bool Contains(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        return false;
                    }
                    else
                    {
                        return left.Contains(value);
                    }
                }
                else if (value > this.value)
                {
                    if (right == null)
                    {
                        return false;
                    }
                    else
                    {
                        return right.Contains(value);
                    }
                }
                else
                {
                    return true;
                }
            }

            // Average: O(log(n)) time | O(log(n)) space
            // Worst: O(n) time | O(n) space
            public BSTConstructionClass Remove(int value)
            {
                Remove(value, null);
                return this;
            }
            public void Remove(int value, BSTConstructionClass parent)
            {
                if (value < this.value)
                {
                    if (left != null)
                    {
                        left.Remove(value, this);
                    }
                }
                else if (value > this.value)
                {
                    if (right != null)
                    {
                        right.Remove(value, this);
                    }
                }
                else
                {
                    if (left != null && right != null)
                    {
                        this.value = right.GetMinValue();
                        right.Remove(this.value, this);
                    }
                    else if (parent == null)
                    {
                        if (left != null)
                        {
                            this.value = left.value;
                            right = left.right;
                            left = left.left;
                        }
                        else if (right != null)
                        {
                            this.value = right.value;
                            left = right.left;
                            right = right.right;
                        }
                        else
                        {
                            // This is a single-node tree; do nothing.
                        }
                    }
                    else if (parent.left == this)
                    {
                        parent.left = left != null ? left : right;
                    }
                    else if (parent.right == this)
                    {
                        parent.right = left != null ? left : right;
                    }
                }
            }

            public int GetMinValue()
            {
                if (left == null)
                {
                    return this.value;
                }
                else
                {
                    return left.GetMinValue();
                }
            }
        }

        #endregion

        #region ValidateBst
        /// <summary>
        /// 
        /// </summary>
        public class ValidateBstClass
        {
            public static bool ValidateBst(BST tree)
            {
                return ValidateBst(tree, Int32.MinValue, Int32.MaxValue);
            }
            public static bool ValidateBst(BST tree, int minValue, int maxValue)
            {
                if (tree.value < minValue || tree.value >= maxValue)
                {
                    return false;
                }
                if (tree.left != null && !ValidateBst(tree.left, minValue, tree.value))
                {
                    return false;
                }
                if (tree.right != null && !ValidateBst(tree.right, tree.value, maxValue))
                {
                    return false;
                }
                return true;
            }
            public class BST
            {
                public int value;
                public BST left;
                public BST right;
                public BST(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region BSTTraversal
        /// <summary>
        /// 
        /// </summary>
        public class BSTTraversal
        {
            // O(n) time | O(n) space
            public static List<int> InOrderTraverse(BST tree, List<int> array)
            {
                if (tree.left != null)
                {
                    InOrderTraverse(tree.left, array);
                }
                array.Add(tree.value);
                if (tree.right != null)
                {
                    InOrderTraverse(tree.right, array);
                }
                return array;
            }
            // O(n) time | O(n) space
            public static List<int> PreOrderTraverse(BST tree, List<int> array)
            {
                array.Add(tree.value);
                if (tree.left != null)
                {
                    PreOrderTraverse(tree.left, array);
                }
                if (tree.right != null)
                {
                    PreOrderTraverse(tree.right, array);
                }
                return array;
            }
            // O(n) time | O(n) space
            public static List<int> PostOrderTraverse(BST tree, List<int> array)
            {
                if (tree.left != null)
                {
                    PostOrderTraverse(tree.left, array);
                }
                if (tree.right != null)
                {
                    PostOrderTraverse(tree.right, array);
                }
                array.Add(tree.value);
                return array;
            }
            public class BST
            {
                public int value;
                public BST left;
                public BST right;
                public BST(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region MinHeightBSTClass
        public class MinHeightBSTClass
        {

            public static BST MinHeightBst(List<int> array)
            {
                return constructMinHeightBst(array, null, 0, array.Count - 1);
            }
            public static BST constructMinHeightBst(List<int> array, BST bst, int startIdx,
            int endIdx)
            {
                if (endIdx < startIdx) return null;
                int midIdx = (startIdx + endIdx) / 2;
                int valueToAdd = array[midIdx];
                if (bst == null)
                {
                    bst = new BST(valueToAdd);
                }
                else
                {
                    bst.insert(valueToAdd);
                }
                constructMinHeightBst(array, bst, startIdx, midIdx - 1);
                constructMinHeightBst(array, bst, midIdx + 1, endIdx);
                return bst;
            }
            public class BST
            {
                public int value;
                public BST left;
                public BST right;
                public BST(int value)
                {
                    this.value = value;
                    left = null;
                    right = null;
                }
                public void insert(int value)
                {
                    if (value < this.value)
                    {
                        if (left == null)
                        {
                            left = new BST(value);
                        }
                        else
                        {
                            left.insert(value);
                        }
                    }
                    else
                    {
                        if (right == null)
                        {
                            right = new BST(value);
                        }
                        else
                        {
                            right.insert(value);
                        }
                    }
                }
            }
        }
        #endregion

        #region FindKthLargestValueInBst
        /// <summary>
        /// 
        /// </summary>
        public class FindKthLargestValueInBstClass
        {
            // This is an input class. Do not edit.
            public class BST
            {
                public int value;
                public BST left = null;
                public BST right = null;

                public BST(int value)
                {
                    this.value = value;
                }
            }

            public int FindKthLargestValueInBst(BST tree, int k)
            {
                List<int> sortedNodeValues = new List<int>();
                InOrderTraverse(tree, sortedNodeValues);
                return sortedNodeValues[sortedNodeValues.Count - k];
            }

            public void InOrderTraverse(BST tree, List<int> sortedNodeValues)
            {
                if (tree == null)
                {
                    return;
                }

                InOrderTraverse(tree.left, sortedNodeValues);
                sortedNodeValues.Add(tree.value);
                InOrderTraverse(tree.right, sortedNodeValues);
            }
        }
        #endregion

        #region ReconstructBst
        /// <summary>
        /// 
        /// </summary>
        public class ReconstructBstClass
        {
            public class BST
            {
                public int value;
                public BST left = null;
                public BST right = null;

                public BST(int value)
                {
                    this.value = value;
                }
            }

            public BST ReconstructBst(List<int> preOrderTraversalValues)
            {
                if (preOrderTraversalValues.Count == 0)
                    return null;

                int cuurentValue = preOrderTraversalValues[0];
                int rightSubtreeRootIndex = preOrderTraversalValues.Count;

                for (int index = 1; index < preOrderTraversalValues.Count; index++)
                {
                    var value = preOrderTraversalValues[index];
                    if (value >= cuurentValue)
                    {
                        rightSubtreeRootIndex = index;
                        break;
                    }
                }

                BST leftSubtree = ReconstructBst(
                    preOrderTraversalValues.GetRange(1, rightSubtreeRootIndex - 1)
                    );

                BST rightSubtree = ReconstructBst(preOrderTraversalValues.GetRange(
                    rightSubtreeRootIndex,
                    preOrderTraversalValues.Count - rightSubtreeRootIndex)
                    );

                BST bst = new BST(cuurentValue);
                bst.left = leftSubtree;
                bst.right = rightSubtree;

                return bst;
            }
        }
        #endregion

        #region InvertBinaryTree
        /// <summary>
        /// 
        /// </summary>
        public class InvertBinaryTreeClass
        {
            public static void InvertBinaryTree(BinaryTree tree)
            {
                List<BinaryTree> queue = new List<BinaryTree>();
                queue.Add(tree);
                var index = 0;
                while (index < queue.Count)
                {
                    BinaryTree current = queue[index];
                    index += 1;
                    if (current == null)
                    {
                        continue;
                    }
                    SwapLeftAndRight(current);
                    if (current.left != null)
                    {
                        queue.Add(current.left);
                    }
                    if (current.right != null)
                    {
                        queue.Add(current.right);
                    }
                }
            }
            private static void SwapLeftAndRight(BinaryTree tree)
            {
                BinaryTree left = tree.left;
                tree.left = tree.right;
                tree.right = left;
            }
            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;
                public BinaryTree(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region BinaryTreeDiameter
        /// <summary>
        /// 
        /// </summary>
        public class BinaryTreeDiameterClass
        {
            public int BinaryTreeDiameter(BinaryTree tree)
            {

                return GetTreeInfo(tree).diameter;
            }

            private TreeInfo GetTreeInfo(BinaryTree tree)
            {
                if (tree == null)
                {
                    return new TreeInfo(0, 0);
                }

                var leftTreeInfo= GetTreeInfo(tree.left);
                var rightTreeInfo = GetTreeInfo(tree.right);

                int longestPathThroughRoot= leftTreeInfo.height
                    + rightTreeInfo.height;
                int maxDiameterSoFar= Math.Max(leftTreeInfo.diameter,rightTreeInfo.diameter);

                int currentDiameter= Math.Max(longestPathThroughRoot,maxDiameterSoFar);
                int currentHeight= 1+ Math.Max(leftTreeInfo.height,rightTreeInfo.height);

                return new TreeInfo(currentDiameter,currentHeight);
            }

            public class TreeInfo
            {
                public int diameter;
                public int height;
                public TreeInfo(int diameter, int height)
                {
                    this.diameter = diameter;
                    this.height = height;
                }
            }

            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;

                public BinaryTree(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion





        #region TaskAssignment
        /// <summary>
        /// 
        /// </summary>
        public class TaskAssignmentClass
        {
            public List<List<int>> TaskAssignment(int k, List<int> tasks)
            {
                List<List<int>> pairedTasks = new List<List<int>>();
                Dictionary<int, List<int>> taskDurationsToIndices = GetTaskDurationsToIndices(tasks);

                List<int> sortedTasks = tasks;
                sortedTasks.Sort();

                for (int index = 0; index < k; index++)
                {
                    int task1Duration = sortedTasks[index];
                    List<int> indicesWithTask1Duration = taskDurationsToIndices[task1Duration];
                    int task1Index = indicesWithTask1Duration[indicesWithTask1Duration.Count - 1];
                    indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);

                    int taskSortedIndex = tasks.Count - 1 - index;
                    int task2Duration = sortedTasks[taskSortedIndex];
                    List<int> indicesWithTask2Duration = taskDurationsToIndices[task2Duration];

                    int task2Index = indicesWithTask2Duration[indicesWithTask1Duration.Count - 1];
                    indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);

                    List<int> pairedTask = new List<int>();
                    pairedTask.Add(task1Index);
                    pairedTask.Add(task2Index);
                    pairedTasks.Add(pairedTask);
                }

                return pairedTasks;
            }

            private Dictionary<int, List<int>> GetTaskDurationsToIndices(List<int> tasks)
            {
                Dictionary<int, List<int>> taskDurationsToIndices = new Dictionary<int, List<int>>();

                for (int i = 0; i < tasks.Count; i++)
                {
                    int taskDuration = tasks[i];
                    if (taskDurationsToIndices.ContainsKey(taskDuration))
                    {
                        taskDurationsToIndices[taskDuration].Add(i);
                    }
                    else
                    {
                        List<int> temp = new List<int>();
                        temp.Add(i);
                        taskDurationsToIndices[taskDuration] = temp;
                    }
                }

                return taskDurationsToIndices;
            }
        }
        #endregion

    }
}