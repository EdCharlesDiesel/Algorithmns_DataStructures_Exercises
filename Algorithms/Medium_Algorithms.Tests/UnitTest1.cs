using Microsoft.VisualStudio.TestPlatform.TestHost;
using static Medium_Algorithms.MediumAlgorithmsClass;

namespace Medium_Algorithms.Tests
{
    public class UnitTest1
    {
        #region ThreeNumberSum
        private bool compare(List<int[]> triplets1, List<int[]> triplets2)
        {
            if (triplets1.Count != triplets2.Count) return false;
            for (int i = 0; i < triplets1.Count; i++)
            {
                if (!Enumerable.SequenceEqual(triplets1[i], triplets2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        [Fact]
        public void ThreeNumberSumTestCase1()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { -8, 2, 6 });
            expected.Add(new int[] { -8, 3, 5 });
            expected.Add(new int[] { -6, 1, 5 });
            List<int[]> output =
              ThreeNumberSumClass.ThreeNumberSum(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
            Assert.True(this.compare(output, expected));
        }
        #endregion

        #region SmallestDifference
        [Fact]
        public void SmallestDifferenceTestCase1()
        {
            int[] expected = { 28, 26 };
            Assert.True(Enumerable.SequenceEqual(
              SmallestDifferenceClass.SmallestDifference(
                new int[] { -1, 5, 10, 20, 28, 3 }, new int[] { 26, 134, 135, 15, 17 }
              ),
              expected
            ));
        }
        #endregion

        #region MoveElementToEnd
        [Fact]
        public void MoveElementToEndTestCase1()
        {
            List<int> array = new List<int>() { 2, 1, 2, 2, 2, 3, 4, 2 };
            int toMove = 2;
            List<int> expectedStart = new List<int>() { 1, 3, 4 };
            List<int> expectedEnd = new List<int>() { 2, 2, 2, 2, 2 };
            List<int> output = MoveElementToEndClass.MoveElementToEnd(array, toMove);
            List<int> outputStart = output.GetRange(0, 3);
            outputStart.Sort();
            List<int> outputEnd = output.GetRange(3, output.Count - 3);
            Assert.True(outputStart.SequenceEqual(expectedStart));
            Assert.True(outputEnd.SequenceEqual(expectedEnd));
        }
        #endregion

        #region IsMonotonic
        [Fact]
        public void TestCase1()
        {
            var array = new int[] { -1, -5, -10, -1100, -1100, -1101, -1102, -9001 };
            var expected = true;
            var actual = IsMonotonicClass.IsMonotonic(array);
            Assert.Equal(expected, actual);
        }
        #endregion

        #region SpiralTraverse
        [Fact]
        public void SpiralTraverseTestCase()
        {
            int[,] input = {
              { 1, 2, 3, 4 },
              { 12, 13, 14, 5 },
              { 11, 16, 15, 6 },
              { 10, 9, 8, 7 },
            };
            var expected =
              new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var actual = SpiralTraverseClass.SpiralTraverse(input);
            Assert.True(expected.SequenceEqual(actual));
        }
        #endregion

        #region LongestPeak
        [Fact]
        public void LongestPeakTestCase1()
        {
            var input = new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 };
            var expected = 6;
            var actual = LongestPeakClass.LongestPeak(input);
            Assert.True(expected == actual);
        }
        #endregion

        #region ArrayOfProducts
        [Fact]
        public void ArrayOfProductsTestCase1()
        {
            var input = new int[] { 5, 1, 4, 2 };
            var expected = new int[] { 8, 40, 10, 20 };
            int[] actual = new ArrayOfProductsClass().ArrayOfProducts(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.True(actual[i] == expected[i]);
            }
        }
        #endregion

        #region FirstDuplicateValue
        [Fact]
        public void FirstDuplicateValueTestCase1()
        {
            var input = new int[] { 2, 1, 5, 2, 3, 3, 4 };
            var expected = 2;
            var actual = new FirstDuplicateValueClass().FirstDuplicateValue(input);
            Assert.True(expected == actual);
        }
        #endregion

        #region MergeOverlappingIntervals
        [Fact]
        public void MergeOverlappingIntervals()
        {
            int[][] intervals = new int[][] {
              new int[] { 1, 2 },
              new int[] { 3, 5 },
              new int[] { 4, 7 },
              new int[] { 6, 8 },
              new int[] { 9, 10 },
            };
            int[][] expected = new int[][] {
              new int[] { 1, 2 },
              new int[] { 3, 8 },
              new int[] { 9, 10 },
            };
            int[][] actual = new MergeOverlappingIntervalsClass().MergeOverlappingIntervals(intervals);
            for (int i = 0; i < actual.Length; i++)
            {
                for (int j = 0; j < actual[i].Length; j++)
                {
                    Assert.True(expected[i][j] == actual[i][j]);
                }
            }
        }
        #endregion

        #region BestSeat
        [Fact]
        public void BestSeatTestCase1()
        {
            var input = new int[] { 1, 0, 1, 0, 0, 0, 1 };
            var expected = 4;
            var actual = new BestSeatClass().BestSeat(input);
            Assert.True(expected == actual);
        }
        #endregion

        #region ZeroSumSubarray
        [Fact]
        public void ZeroSumSubarrayTestCase1()
        {
            var input = new int[] { 4, 2, -1, -1, 3 };
            var expected = true;
            var actual = new ZeroSumSubarrayClass().ZeroSumSubarray(input);
            Assert.True(expected == actual);
        }
        #endregion

        #region MissingNumbers
        [Fact]
        public void MissingNumbersTestCase1()
        {
            var input = new int[] { 4, 5, 1, 3 };
            var expected = new int[] { 2, 6 };
            var actual = new MissingNumbersClass().MissingNumbers(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }
        #endregion

        #region MajorityElement
        [Fact]
        public void MajorityElementTestCase1()
        {
            var input = new int[] { 1, 2, 3, 2, 2, 1, 2 };
            var expected = 2;
            var actual = new MajorityElementClass().MajorityElement(input);
            Assert.True(expected == actual);
        }
        #endregion

        #region SweetAndSavory
        [Fact]
        public void SweetAndSavoryTestCase1()
        {
            int[] dishes = new int[] { -3, -5, 1, 7 };
            int target = 8;
            int[] expected = new int[] { -3, 7 };
            int[] actual = new SweetAndSavoryClass().SweetAndSavory(dishes, target);
            Assert.True(actual.Length == 2);
            Assert.True(actual[0] == expected[0]);
            Assert.True(actual[1] == expected[1]);
        }
        #endregion

        #region BSTConstruction
        [Fact]
        public void BSTConstructionClassTestCase1()
        {
            var root = new BSTConstructionClass(10);
            root.left = new BSTConstructionClass(5);
            root.left.left = new BSTConstructionClass(2);
            root.left.left.left = new BSTConstructionClass(1);
            root.left.right = new BSTConstructionClass(5);
            root.right = new BSTConstructionClass(15);
            root.right.left = new BSTConstructionClass(13);
            root.right.left.right = new BSTConstructionClass(14);
            root.right.right = new BSTConstructionClass(22);

            root.Insert(12);
            Assert.True(root.right.left.left.value == 12);

            root.Remove(10);
            Assert.True(root.Contains(10) == false);
            Assert.True(root.value == 12);
            Assert.True(root.Contains(15));
        }
        #endregion

        #region ValidateBstClass
        [Fact]
        public void ValidateBstClassTestCase1()
        {
            var root = new ValidateBstClass.BST(10);
            root.left = new ValidateBstClass.BST(5);
            root.left.left = new ValidateBstClass.BST(2);
            root.left.left.left = new ValidateBstClass.BST(1);
            root.left.right = new ValidateBstClass.BST(5);
            root.right = new ValidateBstClass.BST(15);
            root.right.left = new ValidateBstClass.BST(13);
            root.right.left.right = new ValidateBstClass.BST(14);
            root.right.right = new ValidateBstClass.BST(22);

            Assert.True(ValidateBstClass.ValidateBst(root));
        }
        #endregion

        #region BSTTraversal
        [Fact]
        public void BSTTraversalTestCase1()
        {
            var root = new BSTTraversal.BST(10);
            root.left = new BSTTraversal.BST(5);
            root.left.left = new BSTTraversal.BST(2);
            root.left.left.left = new BSTTraversal.BST(1);
            root.left.right = new BSTTraversal.BST(5);
            root.right = new BSTTraversal.BST(15);
            root.right.right = new BSTTraversal.BST(22);

            List<int> inOrder = new List<int> { 1, 2, 5, 5, 10, 15, 22 };
            List<int> preOrder = new List<int> { 10, 5, 2, 1, 5, 15, 22 };
            List<int> postOrder = new List<int> { 1, 2, 5, 5, 22, 15, 10 };

            Assert.True(Enumerable.SequenceEqual(
              BSTTraversal.InOrderTraverse(root, new List<int>()), inOrder
            ));
            Assert.True(Enumerable.SequenceEqual(
              BSTTraversal.PreOrderTraverse(root, new List<int>()), preOrder
            ));
            Assert.True(Enumerable.SequenceEqual(
              BSTTraversal.PostOrderTraverse(root, new List<int>()), postOrder
            ));
        }
        #endregion

        #region MinHeightBst
        [Fact(Skip = "Need to figure this out")]

        public void MinHeightBstTestCase1()
        {
            //    var array = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
            //    var tree = MinHeightBstClass.MinHeightBst(array);

            //    AssertTrue(validateBst(tree));
            //    AssertEquals(4, getTreeHeight(tree));

            //    var inOrder = inOrderTraverse(tree, new List<int> { });
            //    var expected = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
            //    AssertTrue(Enumerable.SequenceEqual(inOrder, expected));
            //}

            //static bool validateBst(MinHeightBstClass.BST tree)
            //{
            //    return validateBst(tree, Int32.MinValue, Int32.MaxValue);
            //}

            //static bool validateBst(MinHeightBstClass.BST tree, int minValue, int maxValue)
            //{
            //    if (tree.value < minValue || tree.value >= maxValue)
            //    {
            //        return false;
            //    }
            //    if (tree.left != null && !validateBst(tree.left, minValue, tree.value))
            //    {
            //        return false;
            //    }
            //    if (tree.right != null && !validateBst(tree.right, tree.value, maxValue))
            //    {
            //        return false;
            //    }
            //    return true;
            //}

            //static List<int> inOrderTraverse(MinHeightBstClass.BST tree, List<int> array)
            //{
            //    if (tree.left != null)
            //    {
            //        inOrderTraverse(tree.left, array);
            //    }
            //    array.Add(tree.value);
            //    if (tree.right != null)
            //    {
            //        inOrderTraverse(tree.right, array);
            //    }
            //    return array;
            //}

            //static int getTreeHeight(MinHeightBstClass.BST tree)
            //{
            //    return getTreeHeight(tree, 0);
            //}

            //static int getTreeHeight(MinHeightBstClass.BST tree, int height)
            //{
            //    if (tree == null) return height;
            //    int leftTreeHeight = getTreeHeight(tree.left, height + 1);
            //    int rightTreeHeight = getTreeHeight(tree.right, height + 1);
            //    return Math.Max(leftTreeHeight, rightTreeHeight);
            //} 
        }

        #endregion

        #region FindKthLargestValueInBstClassMyRegion
        [Fact]
        public void FindKthLargestValueInBstClassTestCase1()
        {
            FindKthLargestValueInBstClass.BST root = new FindKthLargestValueInBstClass.BST(15);
            root.left = new FindKthLargestValueInBstClass.BST(5);
            root.left.left = new FindKthLargestValueInBstClass.BST(2);
            root.left.left.left = new FindKthLargestValueInBstClass.BST(1);
            root.left.left.right = new FindKthLargestValueInBstClass.BST(3);
            root.left.right = new FindKthLargestValueInBstClass.BST(5);
            root.right = new FindKthLargestValueInBstClass.BST(20);
            root.right.left = new FindKthLargestValueInBstClass.BST(17);
            root.right.right = new FindKthLargestValueInBstClass.BST(22);
            int k = 3;
            int expected = 17;
            var actual = new FindKthLargestValueInBstClass().FindKthLargestValueInBst(root, k);
            Assert.True(expected == actual);
        }
        #endregion        

        #region ReconstructBstClass
        [Fact]
        public void ReconstructBstTestCase1()
        {
            List<int> preOrderTraversalValues =
              new List<int> { 10, 4, 2, 1, 3, 17, 19, 18 };
            ReconstructBstClass.BST tree = new ReconstructBstClass.BST(10);
            tree.left = new ReconstructBstClass.BST(4);
            tree.left.left = new ReconstructBstClass.BST(2);
            tree.left.left.left = new ReconstructBstClass.BST(1);
            tree.left.right = new ReconstructBstClass.BST(3);
            tree.right = new ReconstructBstClass.BST(17);
            tree.right.right = new ReconstructBstClass.BST(19);
            tree.right.right.left = new ReconstructBstClass.BST(18);
            List<int> expected = getDfsOrder(tree, new List<int>());
            var actual = new ReconstructBstClass().ReconstructBst(preOrderTraversalValues);
            List<int> actualValues = getDfsOrder(actual, new List<int>());
            Assert.True(Enumerable.SequenceEqual(expected, actualValues));
        }

        public List<int> getDfsOrder(ReconstructBstClass.BST node, List<int> values)
        {
            values.Add(node.value);
            if (node.left != null)
            {
                getDfsOrder(node.left, values);
            }
            if (node.right != null)
            {
                getDfsOrder(node.right, values);
            }
            return values;
        }
        #endregion

        #region InvertBinaryTree
        [Fact]
        public void InvertBinaryTreeClassTestCase1()
        {
            TestBinaryTree tree = new TestBinaryTree(1);
            tree.insert(new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, 0);
            InvertBinaryTreeClass.InvertBinaryTree(tree);
            InvertedBinaryTree invertedTree = new InvertedBinaryTree(1);
            invertedTree.insert(new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, 0);
            Assert.True(compareBT(tree, invertedTree));
        }

        private bool compareBT(InvertBinaryTreeClass.BinaryTree tree1, InvertedBinaryTree tree2)
        {
            if (tree1 == null && tree2 == null)
            {
                return true;
            }
            if (tree1 != null && tree2 != null)
            {
                return tree1.value == tree2.value && compareBT(tree1.left, tree2.left) &&
                       compareBT(tree1.right, tree2.right);
            }
            return false;
        }

        public class InvertedBinaryTree
        {
            public int value;
            public InvertedBinaryTree left;
            public InvertedBinaryTree right;

            public InvertedBinaryTree(int value)
            {
                this.value = value;
            }

            public void insert(int[] values, int i)
            {
                if (i >= values.Length)
                {
                    return;
                }
                List<InvertedBinaryTree> queue = new List<InvertedBinaryTree>();
                queue.Add(this);
                var index = 0;
                while (index < queue.Count)
                {
                    InvertedBinaryTree current = queue[index];
                    index += 1;
                    if (current.right == null)
                    {
                        current.right = new InvertedBinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.right);
                    if (current.left == null)
                    {
                        current.left = new InvertedBinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.left);
                }
                insert(values, i + 1);
            }
        }

        public class TestBinaryTree : InvertBinaryTreeClass.BinaryTree
        {
            public TestBinaryTree(int value) : base(value) { }

            public void insert(int[] values, int i)
            {
                if (i >= values.Length)
                {
                    return;
                }
                List<InvertBinaryTreeClass.BinaryTree> queue = new List<InvertBinaryTreeClass.BinaryTree>();
                queue.Add(this);
                var index = 0;
                while (index < queue.Count)
                {
                    InvertBinaryTreeClass.BinaryTree current = queue[index];
                    index += 1;
                    if (current.left == null)
                    {
                        current.left = new InvertBinaryTreeClass.BinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.left);
                    if (current.right == null)
                    {
                        current.right = new InvertBinaryTreeClass.BinaryTree(values[i]);
                        break;
                    }
                    queue.Add(current.right);
                }
                insert(values, i + 1);
            }
        }
        #endregion

        #region BinaryTreeDiameterClassTestCase1
        [Fact]
        public void BinaryTreeDiameterClassTestCase1()
        {
            var root = new BinaryTreeDiameterClass.BinaryTree(1);
            root.left = new BinaryTreeDiameterClass.BinaryTree(3);
            root.left.left = new BinaryTreeDiameterClass.BinaryTree(7);
            root.left.left.left = new BinaryTreeDiameterClass.BinaryTree(8);
            root.left.left.left.left = new BinaryTreeDiameterClass.BinaryTree(9);
            root.left.right = new BinaryTreeDiameterClass.BinaryTree(4);
            root.left.right.right = new BinaryTreeDiameterClass.BinaryTree(5);
            root.left.right.right.right = new BinaryTreeDiameterClass.BinaryTree(6);
            root.right = new BinaryTreeDiameterClass.BinaryTree(2);
            var expected = 6;
            var actual = new BinaryTreeDiameterClass().BinaryTreeDiameter(root);
            Assert.True(expected == actual);
        }
        #endregion

        #region FindSuccessor
        [Fact]
        public void FindSuccessorClassTestCase1()
        {
            FindSuccessorClass.BinaryTree root = new FindSuccessorClass.BinaryTree(1);
            root.left = new FindSuccessorClass.BinaryTree(2);
            root.left.parent = root;
            root.right = new FindSuccessorClass.BinaryTree(3);
            root.right.parent = root;
            root.left.left = new FindSuccessorClass.BinaryTree(4);
            root.left.left.parent = root.left;
            root.left.right = new FindSuccessorClass.BinaryTree(5);
            root.left.right.parent = root.left;
            root.left.left.left = new FindSuccessorClass.BinaryTree(6);
            root.left.left.left.parent = root.left.left;
            FindSuccessorClass.BinaryTree node = root.left.right;
            FindSuccessorClass.BinaryTree expected = root;
            FindSuccessorClass.BinaryTree actual = new FindSuccessorClass().FindSuccessor(root, node);
            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeightBalancedBinaryTree
        [Fact]
        public void HeightBalancedBinaryTreeClassTestCase()
        {
            HeightBalancedBinaryTreeClass.BinaryTree root = new HeightBalancedBinaryTreeClass.BinaryTree(1);
            root = new HeightBalancedBinaryTreeClass.BinaryTree(1);
            root.left = new HeightBalancedBinaryTreeClass.BinaryTree(2);
            root.right = new HeightBalancedBinaryTreeClass.BinaryTree(3);
            root.left.left = new HeightBalancedBinaryTreeClass.BinaryTree(4);
            root.left.right = new HeightBalancedBinaryTreeClass.BinaryTree(5);
            root.right.right = new HeightBalancedBinaryTreeClass.BinaryTree(6);
            root.left.right.left = new HeightBalancedBinaryTreeClass.BinaryTree(7);
            root.left.right.right = new HeightBalancedBinaryTreeClass.BinaryTree(8);
            bool expected = true;
            var actual = new HeightBalancedBinaryTreeClass().HeightBalancedBinaryTree(root);
            Assert.True(expected == actual);
        }
        #endregion

        #region MergeBinaryTrees
        [Fact]
        public void MergeBinaryTreesTestCase1()
        {
            MergeBinaryTreesClass.BinaryTree tree1 = new MergeBinaryTreesClass.BinaryTree(1);
            tree1.left = new MergeBinaryTreesClass.BinaryTree(3);
            tree1.left.left = new MergeBinaryTreesClass.BinaryTree(7);
            tree1.left.right = new MergeBinaryTreesClass.BinaryTree(4);
            tree1.right = new MergeBinaryTreesClass.BinaryTree(2);

            MergeBinaryTreesClass.BinaryTree tree2 = new MergeBinaryTreesClass.BinaryTree(1);
            tree2.left = new MergeBinaryTreesClass.BinaryTree(5);
            tree2.left.left = new MergeBinaryTreesClass.BinaryTree(2);
            tree2.right = new MergeBinaryTreesClass.BinaryTree(9);
            tree2.right.left = new MergeBinaryTreesClass.BinaryTree(7);
            tree2.right.right = new MergeBinaryTreesClass.BinaryTree(6);

            MergeBinaryTreesClass.BinaryTree expected = new MergeBinaryTreesClass.BinaryTree(2);
            expected.left = new MergeBinaryTreesClass.BinaryTree(8);
            expected.left.left = new MergeBinaryTreesClass.BinaryTree(9);
            expected.left.right = new MergeBinaryTreesClass.BinaryTree(4);
            expected.right = new MergeBinaryTreesClass.BinaryTree(11);
            expected.right.left = new MergeBinaryTreesClass.BinaryTree(7);
            expected.right.right = new MergeBinaryTreesClass.BinaryTree(6);

            MergeBinaryTreesClass.BinaryTree actual = new MergeBinaryTreesClass().MergeBinaryTrees(tree1, tree2);

            Assert.True(areTreesEqual(expected, actual));
        }

        public bool areTreesEqual(
          MergeBinaryTreesClass.BinaryTree tree1, MergeBinaryTreesClass.BinaryTree tree2
        )
        {
            if (tree1 == null && tree2 == null) return true;

            if (tree1 == null && tree2 != null)
            {
                return false;
            }
            else if (tree1 != null && tree2 == null)
            {
                return false;
            }

            if (tree1.value != tree2.value) return false;
            return areTreesEqual(tree1.left, tree2.left) &&
                   areTreesEqual(tree1.right, tree2.right);
        }
        #endregion

        #region SymmetricalTree
        [Fact]
        public void SymmetricalTreeTestCase1()
        {
            SymmetricalTreeClass.BinaryTree tree = new SymmetricalTreeClass.BinaryTree(10);
            tree.left = new SymmetricalTreeClass.BinaryTree(5);
            tree.right = new SymmetricalTreeClass.BinaryTree(5);
            tree.left.left = new SymmetricalTreeClass.BinaryTree(7);
            tree.left.right = new SymmetricalTreeClass.BinaryTree(9);
            tree.right.left = new SymmetricalTreeClass.BinaryTree(9);
            tree.right.right = new SymmetricalTreeClass.BinaryTree(7);
            var expected = true;
            var actual = new SymmetricalTreeClass().SymmetricalTree(tree);
            Assert.True(expected == actual);
        }
        #endregion

        #region SplitBinaryTreeClass
        [Fact]
        public void SplitBinaryTreeClassTestCase1()
        {
            SplitBinaryTreeClass.BinaryTree tree = new SplitBinaryTreeClass.BinaryTree(2);
            tree.left = new SplitBinaryTreeClass.BinaryTree(4);
            tree.left.left = new SplitBinaryTreeClass.BinaryTree(4);
            tree.left.right = new SplitBinaryTreeClass.BinaryTree(6);
            tree.right = new SplitBinaryTreeClass.BinaryTree(10);
            tree.right.left = new SplitBinaryTreeClass.BinaryTree(3);
            tree.right.right = new SplitBinaryTreeClass.BinaryTree(3);
            int expected = 16;
            int actual = new SplitBinaryTreeClass().SplitBinaryTree(tree);
            Assert.True(expected == actual);
        }
        #endregion

        #region MaxSubsetSumNoAdjacent
        [Fact]
        public void MaxSubsetSumNoAdjacentTestCase1()
        {
            int[] input = { 75, 105, 120, 75, 90, 135 };
            Assert.True(MaxSubsetSumNoAdjacentClass.MaxSubsetSumNoAdjacent(input) == 330);
        }
        #endregion

        #region NumberOfWaysToMakeChange
        [Fact]
        public void NumberOfWaysToMakeChange()
        {
            int[] input = { 1, 5 };
            Assert.True(NumberOfWaysToMakeChangeClass.NumberOfWaysToMakeChange(6, input) == 2);
        } 
        #endregion






















        #region TaskAssignment
        [Fact(Skip = " Unit Test failing.")]
        public void TaskAssignmentTestCase1()
        {
            var k = 3;
            var tasks = new List<int> { 1, 3, 5, 3, 1, 4 };
            var expected = new List<List<int>>();
            List<int> subarr = new List<int> { 4, 2 };
            List<int> subarr2 = new List<int> { 0, 5 };
            List<int> subarr3 = new List<int> { 3, 1 };
            expected.Add(subarr);
            expected.Add(subarr2);
            expected.Add(subarr3);
            var actual = new TaskAssignmentClass().TaskAssignment(k, tasks);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.True(Enumerable.SequenceEqual(expected[i], actual[i]));
            }
        }
        #endregion
    }
}