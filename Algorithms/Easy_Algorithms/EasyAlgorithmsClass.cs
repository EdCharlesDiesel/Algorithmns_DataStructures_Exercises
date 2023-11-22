using System.Text;
using static Easy_Algorithms.EasyAlgorithmsClass.BranchSumsClass;

namespace Easy_Algorithms
{
    public class EasyAlgorithmsClass
    {
        #region TwoNumberSum
        public class TwoNumberSumClass
        {
            /// <summary>
            /// Write a function that takes in a non-empty array of distinct integers and an integer 
            /// representing a target sum. If any two numbers in the input array sum the target sum,
            /// the function should return them in an array, in any order. If no two numbers sum up to 
            /// to the target sum up to the target sum, the function should return an empty.
            /// 
            /// Note that the target sum has to be obtained by summing two different integers in
            /// the array; you can't add a single integer to itself in order to obtain the target sum.
            /// 
            /// You can assume that there will be at most pair of numbers summing up to the target sum.
            /// </summary>
            /// <param name="array"></param>
            /// <param name="targetSum"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public int[] TwoNumberSum(int[] array, int targetSum)
            {
                for (var i = 0; i < array.Length - 1; i++)
                {
                    var firstNum = array[i];
                    for (var j = i + 1; j < array.Length; j++)
                    {
                        var secondNum = array[j];
                        if (firstNum + secondNum == targetSum)
                        {
                            return new int[] { firstNum, secondNum };
                        }
                    }
                }

                return Array.Empty<int>();
            }
        }
        #endregion

        #region IsValidSubsequence
        /// <summary>
        /// Given two non-empty array of integers, write a function that determines whether the second
        /// array is a subsequence of the first one.
        /// 
        /// A subsequence of an array is a set of numbers that aren't necessarily adjacent in the array 
        /// but that are in the same order as they appear in the array. Fo instance, the number [1,3,4]
        /// form a subsequence of an array [1,2,3,4]. and so do the number [2,4]. note that a single 
        /// number in an array and the array itself are both valid subsequence of the array.
        /// </summary>
        public static class ValidateSubsequenceClass
        {
            public static bool IsValidSubsequence(List<int> array, List<int> sequence)
            {
                var sequenceIndex = 0;
                foreach (var val in array)
                {
                    if (sequenceIndex == sequence.Count)
                    {
                        break;
                    }

                    if (sequence[sequenceIndex] == val)
                    {
                        sequenceIndex++;
                    }
                }
                return sequenceIndex == sequence.Count;
            }
        }
        #endregion

        #region SortedSquaredArray
        public class SortedSquaredArrayClass
        {
            /// <summary>
            /// Write a function that takes in a non-empty array of integers that are sorted
            /// in ascending  order and returns a new array of the saw length with the squares
            /// of the original integer  also sorted in ascending order.
            /// </summary>
            /// <param name="array"></param>
            /// <returns></returns>
            public int[] SortedSquaredArray(int[] array)
            {
                var sortedSquares = new int[array.Length];
                for (int index = 0; index < array.Length; index++)
                {
                    var value = array[index];
                    sortedSquares[index] = value * value;
                }

                Array.Sort(sortedSquares);
                return sortedSquares;
            }
        }
        #endregion

        #region TournamentWinner
        public class TournamentWinnerClass
        {
            /// <summary>
            /// There's an algorithms tournament taking place in which teams of programmers compete against
            /// each other to solve algorithmic problems as fast as possible. Teams compete in round robin,
            /// where each team faces off against all other teams. Only two teams compete against each team
            /// other at a time, and for each competition, one team is designated the home team, while the 
            /// other team is the away team. In each competition, there's always one winner and one loser; there
            /// are no ties. A team receives 3 points if it wins and 0 points if it loses. The winner of the 
            /// tournament is the team that receives 3 points it it wins 0 point it it loses. The winner of the 
            /// tournament is the team that receives the most points.
            /// 
            /// Given an array of pairs representing the teams that have completed against  each other and
            /// an array counting the result of each competition, Write a function that returns the winner of
            /// the tournament . The input arrays are names competitions and result, respectively. The 
            /// competitions array has elements in the form of [homeTeam, awayTeam ], where each team is a 
            /// string of at mos 30 characters representing the name of the team. The results array contains
            /// information about  the winner of each  corresponding competition in the competition array. 
            /// Specifically, results[i] denotes the winner of competitions[i], where 1 in the results array 
            /// means that the home team team in the corresponding competition won a 0 means that the away 
            /// team won.
            /// 
            /// it's guaranteed that exactly one team will win the tournament and thateach team will compete
            /// agaist all other teamns exactly once. It's also guaranteed that the tournament will always have 
            /// at leat two teamns.
            /// 
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public int HOME_TEAM_WON = 1;

            public string TournamentWinner(List<List<string>> competitions, List<int> results)
            {
                var currentBestTeam = "";
                var scores = new Dictionary<string, int>();
                scores[currentBestTeam] = 0;

                for (int index = 0; index < competitions.Count; index++)
                {
                    List<string> competition = competitions[index];
                    int result = results[index];

                    var homeTeam = competition[0];
                    var awayTeam = competition[1];

                    string winingTeam = (result == HOME_TEAM_WON) ? homeTeam : awayTeam;

                    updateScores(winingTeam, 3, scores);

                    if (scores[winingTeam] > scores[currentBestTeam])
                    {
                        currentBestTeam = winingTeam;
                    }
                }

                return currentBestTeam;
            }

            private void updateScores(string winingTeam, int points, Dictionary<string, int> scores)
            {
                if (!scores.ContainsKey(winingTeam))
                {
                    scores[winingTeam] = 0;
                }

                scores[winingTeam] += points;
            }
        }
        #endregion

        #region NonConstructibleChange
        /// <summary>
        /// Given an array of positive integers representing the values of coins in your possession,
        /// write a function that returns the minimum amount of change (minimum sum of money) that
        /// you cannot create. The given coins can have any positive integer value and arent 
        /// necessarily unique (i.e., you can have multiple coins of the same value). 
        /// 
        /// For example, if you're given coins = [1,2,5], the minimum amount of change that you
        /// can't create is 4. If you're given no coins, the minimum amount of change that you can't
        /// is 1.
        /// 
        /// </summary>
        public class NonConstructibleChangeClass
        {
            // O(nlogn) time | O(1) space - where n is the number of coins
            public int NonConstructibleChange(int[] coins)
            {
                Array.Sort(coins);

                var currentChangeCreated = 0;
                foreach (var coin in coins)
                {
                    if (coin > currentChangeCreated + 1)
                    {
                        return currentChangeCreated + 1;
                    }
                    currentChangeCreated += coin;
                }

                return currentChangeCreated + 1;
            }
        }
        #endregion

        #region TransposeMatrix
        /// <summary>
        /// You're given a 2D array of integers matrix. Write a function that returns the transpose
        /// of the matrix.
        /// 
        /// The transpose of a matrix is a flipped version of the original matrix across it's main diagonal
        /// (which runs from top-left to bottom-righ); It switches the row and column indices of the
        /// original matrix.
        /// 
        /// You can assume that the inout matrix always has atleast 1 value;however its width and heigh 
        /// are not necessarily the same.
        /// </summary>
        public class TransposeMatrixClass
        {
            public int[,] TransposeMatrix(int[,] matrix)
            {
                var transposeMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        transposeMatrix[col, row] = matrix[row, col];
                    }
                }

                return transposeMatrix;
            }
        }
        #endregion

        #region BranchSums
        /// <summary>
        /// Write a function that takes in a binary tree and returns a list of its branch sums ordered from
        /// leftmost branch sum to rightmost branch sum.
        /// 
        /// A branch sum is the sum of all the values in a binary tree branch. A binary tree branch is a path
        /// of nodes in a tree that starts at the root node and ends at any leaf node.
        /// 
        /// Each BinaryTree node has an integer value, a left child node, and a right child node. Children
        /// nodes can either be BinaryTree nodes themselves or None/null.
        ///          
        /// </summary>
        public class BranchSumsClass
        {
            public class BinaryTree
            {
                public int value;
                public BinaryTree? left;
                public BinaryTree? right;
                public BinaryTree(int value)
                {
                    this.value = value;
                    this.left = null;
                    this.right = null;
                }
            }
            public static List<int> BranchSums(BinaryTree root)
            {
                List<int> sums = new List<int>();
                calculateBranchSums(root, 0, sums);
                return sums;
            }

            public static void calculateBranchSums(
                BinaryTree node, int runningSum, List<int> sums)
            {
                if (node == null) return;
                int newRunningSum = runningSum + node.value;
                if (node.left == null && node.right == null)
                {
                    sums.Add(newRunningSum);
                    return;
                }

                calculateBranchSums(node.left,newRunningSum, sums);
                calculateBranchSums(node.right, newRunningSum, sums);
            }

            
        }
        #endregion

        #region NodeDepths
        /// <summary>
        /// The distance between a node in a Binary Tree and the tree's root is called the node's
        /// depth. Write a function that takes in a Binary Tree and returns the sum of its node's 
        /// depths. Each BinaryTree node has an integer value, a left child node, and a right child
        /// node. Children nodes can either be BinaryTree nodes themselves or Node/null.
        /// </summary>
        public class NodeDepthsClass
        {
            // Average case: when the tree is balanced
            // O(n) time | O(h) space - where n is the number of nodes in
            // the Binary Tree and h is the height of the Binary Tree
            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;
                public BinaryTree(int value)
                {
                    this.value = value;
                    left = null;
                    right = null;
                }
            }

            public class Level
            {
                public BinaryTree root;
                public int depth;
                public Level(BinaryTree root, int depth)
                {
                    this.root = root;
                    this.depth = depth;
                }
            }
            public static int NodeDepths(BinaryTree root)
            {
                int sumOfDepths = 0;
                Stack<Level> stack = new Stack<Level>();
                stack.Push(new Level(root, 0));
                while (stack.Count > 0)
                {
                    Level top = stack.Pop();
                    BinaryTree node = top.root;
                    int depth = top.depth;
                    if (node == null) continue;
                    sumOfDepths += depth;
                    stack.Push(new Level(node.left, depth + 1));
                    stack.Push(new Level(node.right, depth + 1));
                }
                return sumOfDepths;
            }
        }


        public class NodeDepthsClass_Solution2
        {
            // Average case: when the tree is balanced
            // O(n) time | O(h) space - where n is the number of nodes in
            // the Binary Tree and h is the height of the Binary Tree
            public static int NodeDepths(BinaryTree root)
            {
                return nodeDepthsHelper(root, 0);
            }

            public static int nodeDepthsHelper(BinaryTree root, int depth)
            {
                if (root == null) return 0;
                return depth + nodeDepthsHelper(root.left, depth + 1) + nodeDepthsHelper(root.right,
                depth + 1);
            }
        }



        #endregion

        #region EvaluateExpressionTree
        /// <summary>
        /// You're given a binary expression tree. Write a function to evaluate this tree
        /// mathematically and return a single resulting integer.
        /// 
        /// All leaf nodes in the tree represent operands, which will always be positive 
        /// integers. All of the other nodes represent operators. There are 4 operators
        /// supported, each of which is represented by a negative integer:
        /// -> -1: Addition operator, adding the left and right subtrees/
        /// -> -2: Subtraction operator, subtracting the right subtree from the left subtree.
        /// -> -3: Division operators, dividing the left subtree by the right subtree. If the result
        /// is a decimal, it should be rounded towards zero.
        /// -> -4: Multiplication operator, multiplying the left and right subtrees.
        ///
        /// You can assume the tree will always be a valid expression tree. Each operator also
        /// works as a grouping symbol, meaning the bottom of the tree is always evaluated first,
        /// regardless of the operator.
        ///
        /// tree =   -1
        ///         /   \
        ///       -2    -3
        ///       / \   / \
        ///     -4   2 8   3
        ///     / \
        ///    2  3
        ///
        /// Sample output
        /// 6 // (((2*3) -2) + (8/3))
        /// </summary>
        public class EvaluateExpressionTreeClass
        {
            public int EvaluateExpressionTree(BinaryTree tree)
            {
                if (tree.value >= 0)
                {
                    return tree.value;
                }

                int leftValue = EvaluateExpressionTree(tree.left);
                int rightValue = EvaluateExpressionTree(tree.right);

                if (tree.value == -1)
                {
                    return leftValue + rightValue;
                }
                else if (tree.value == -2)
                {
                    return leftValue - rightValue;
                }
                else if (tree.value == -3)
                {
                    return leftValue / rightValue;
                }

                return leftValue * rightValue;
            }
            public class BinaryTree
            {
                public int value;
                public BinaryTree left = null;
                public BinaryTree right = null;

                public BinaryTree(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region DepthFirstSearch
        /// <summary>
        /// You're given a Node class that has a name and an array of optional children
        /// nodes. When put together, nodes form an acyclic tree-like structure.
        ///
        /// Implement the depthFirstSearch method on the Node class, which takes in an
        /// empty array. traverse the tree using Depth-First Search approach( specifically navigating
        /// the tree from left to right), stores all of the nodes, names in the input array, and returns it.
        ///
        /// graph =  A
        ///       /  |  \ 
        ///      B   C   D
        ///    /  \     / \
        ///   E   F    G   H
        ///      / \   \
        ///     I   J  K
        /// 
        /// Sample output
        /// ["A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"]
        /// </summary>
        public class DepthFirstSearchClass
        {
            public class Node
            {
                public string name;
                public List<Node> children = new List<Node>();

                public Node(string name)
                {
                    this.name = name;
                }

                public List<string> DepthFirstSearch(List<string> array)
                {
                    array.Add(name);
                    foreach (var node in children)
                    {
                        node.DepthFirstSearch(array);
                    }
                    return array;
                }

                public Node AddChild(string name)
                {
                    Node child = new Node(name);
                    children.Add(child);
                    return this;
                }
            }
        }
        #endregion

        #region MinimumWaitingTime
        /// <summary>
        /// You're given a non-empty array of positive integers representing the amounts of the time
        /// that specific queries take to execute. Only one query can be executed at a time, but the
        /// queries can be executed in any order.
        ///
        /// A queries waiting time is defined as the amount of time that it must wait before its
        /// execution starts. In other words, if a query is executed second, them its waiting time
        /// is the duration of the first query; if the a query is executed third, then its waiting
        /// time is the sum of the durations of the first two queries.
        ///
        /// Write a function that returns the minimum amount of the total waiting time for all of the
        /// queries. For example, If you're given the queries of durations[1,4,5], then the total waiting
        /// time if the queries were executed in the order of [5,1,4] would be (0)+(5)(5+1)=11. The first
        /// query of duration 5 would be executed immediately, so its waiting time would be 0, the second
        /// (the duration of the first query) to be executed, and the last query would have to wait the
        /// duration of the first two queries before being executed.
        ///
        /// queries = [3,2,1,2,6]
        /// Sample Input = 17
        /// </summary>
        public class MinimumWaitingTimeClass
        {
            public int MinimumWaitingTime(int[] queries)
            {
                Array.Sort(queries);
                var totalWaitingTime = 0;
                for (int index = 0; index < queries.Length; index++)
                {
                    var duration = queries[index];
                    var queriesLeft = queries.Length - (index + 1);
                    totalWaitingTime += duration * queriesLeft;
                }
                return totalWaitingTime;
            }
        }
        #endregion

        #region ClassPhotos
        /// <summary>
        /// It's photo day at the local school, and you're the photographer assigned to take class
        /// photos. The class that you'll be photographing has an even number of students, and all
        /// these students are wearing red or blue shirt. Half red, half blue. You're responsible
        /// for arranging the student in two rows before taking the photo. Each row should contain the
        /// same number of students and should adhere to the following guidelines
        /// -> All Students wearing red shirts must be in the same row.
        /// -> All Students wearing blue shirts must be in the same row.
        /// -> Each student in the back row must be strictly taller than student directly in front
        /// of them in the first row.
        ///
        /// You're given two input arrays: one containing the heights of all the students with red
        /// shirts and another one containing the heights of all the students with blue shirts. These
        /// arrays will always have the same length, and each height will be a positive integer. Write
        /// a function that returns whether or not a class photo follows the stated can be taken.
        ///
        ///  Note: You can assume that each class has at least 2 students.
        /// </summary>
        public class ClassPhotosClass
        {
            public bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
            {
                redShirtHeights.Sort((a, b) => b.CompareTo(a));
                blueShirtHeights.Sort((a, b) => b.CompareTo(a));

                string shirtColorInFirstRow =
                    (redShirtHeights[0] < blueShirtHeights[0]) ? "RED" : "BLUE";
                for (int i = 0; i < redShirtHeights.Count; i++)
                {
                    int redShirtHeight = redShirtHeights[i];
                    int blueShirtHeight = blueShirtHeights[i];

                    if (shirtColorInFirstRow == "RED")
                    {
                        if (redShirtHeight >= blueShirtHeight)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (blueShirtHeight >= redShirtHeight)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        #endregion

        #region TandemBicycle
        /// <summary>
        /// A tandem bicycle is a bicycle that's operated by two people: Person A and Person B. Both
        /// people pedal bicycle, but the person that pedals faster dictates the speed of the bicycle.
        /// So if person A pedals at speed of 5, and person B pedal at a sped of 4, the tandem bicycle
        /// moved st a speed of 5(i.e tandemSped = Max(speedA,speedB).
        ///
        /// You're give tow list of positive integer: one that contains the speed of riders is wearing
        /// red shirts, and another is wearing blue shirts. Each rider is represented by a single positive
        /// integer, which is the speed that the pedal a tandem bicyle at. Both lists have the same length
        /// meaning  that there are as many red shirt riders as there are blue shirt riders. Your goal os
        /// to pair every rider wearing a red shirt with a rider wearing a blue shirt to operate a tandem
        /// blue shirt.
        ///
        /// Write a function that returns the maximum possible total speed or the minimum possible total speed
        /// of all the tandem bicycle being ridden based on the input parameter, fastest. if fastest = tru.
        /// your function should return the maximum possible  total speed; otherwise it should return
        /// the minimum total speed.
        ///
        /// Total speed is defined as the sum of the speeds of the tandem bicycle being ridden. For example
        /// if there are 4 riders who have speeds 1 3 4 5 and if they're paired to tandem bicycle as follows
        /// [1,4],[5,3] then the total speed of these tandem bicycle is 4 + 5 = 9
        /// </summary>
        public class TandemBicycleClass
        {
            public int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
            {
                Array.Sort(redShirtSpeeds);
                Array.Sort(blueShirtSpeeds);

                if (!fastest)
                {
                    ReverseArrayInPlace(redShirtSpeeds);
                }

                var totalSpeed = 0;
                for (int index = 0; index < redShirtSpeeds.Length; index++)
                {
                    var riderOne = redShirtSpeeds[index];
                    var riderTwo = blueShirtSpeeds[blueShirtSpeeds.Length - index - 1];
                    totalSpeed += Math.Max(riderOne, riderTwo);
                }
                return totalSpeed;
            }

            private void ReverseArrayInPlace(int[] array)
            {
                var start = 0;
                var end = array.Length - 1;
                while (start < end)
                {
                    var temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    
                    start += 1;
                    end -= 1;
                }
            }
        }
        #endregion

        #region OptimalFreelancing
        /// <summary>
        /// You're recently started freelancing software development and have been offered a variety of job
        /// oppotunities. Each job has a deadline ,meaning there is no value in completing the work after the
        /// deadline.Additionally, each job has an associate payment representing the profit for completing 
        /// that job. Givem this information, write a function that returns the maximum profit that can be obtained in 
        /// a 7-day period.
        /// 
        /// Each job will take one full day to complete, and the deadline will be given as the number of days left
        /// to complete the job. For example, if a job has deadline of 1, then it can only be completed if it is
        /// the first job worked on. if a job has a deadline of 2, then it could be started on the first or second
        /// day.
        /// 
        /// 
        /// Note: There is no requirement complete all of the jobs. Only one job can be worked on at a time, meaning 
        /// that in some screnarios it will be impossible to complete them all.
        /// 
        /// Samle Input: 
        /// Jobs =[
        ///     {"deadline":1,"payment":1},
        ///     {"deadline":2,"payment":1},
        ///     {"deadline":2,"payment":2}
        /// ]
        /// 
        /// Output= 3 
        /// </summary>
        public class OptimalFreelancingClass
        {
            public int OptimalFreelancing(Dictionary<string, int>[] jobs)
            {
                const int LENGTH_OF_WEEK = 7;
                int profit = 0;
                Array.Sort(jobs, Comparer<Dictionary<string, int>>.Create((jobOne, JobTwo) => JobTwo["payment"]
                .CompareTo(jobOne["payment"])));

                bool[] timeline = new bool[LENGTH_OF_WEEK];

                foreach (var job in jobs)
                {
                    int maxTime = Math.Min(job["deadline"], LENGTH_OF_WEEK);
                    for (int time = maxTime - 1; time >= 0; time--)
                    {
                        if (!timeline[time])
                        {
                            timeline[time] = true;
                            profit += job["payment"];
                            break;
                        }
                    }
                }

                return profit;
            }
        }
        #endregion

        #region RemoveDuplicatesFromLinkedList
        /// <summary>
        /// You're given the head of a Singly Linked list whose nodes are in sorted order with respect 
        /// to their values. Write a function that returns a modified version of the linked List that doesn't
        /// contain any nodes with duplicated values. The Linked List should be modified in place (i:e, you
        /// shouldn't create a brand new list), and the modified Linked List should still its modified Linked
        /// List should still have its nodes sorted with respect to their values.
        ///
        /// Each Linked List node has integer has an integer value as well as a next node pointing to the next
        /// node in the list or to Node/null if it's the tail of the list.
        /// </summary>
        public class RemoveDuplicatesFromLinkedListClass
        {
            public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
            {
                LinkedList currentNode = linkedList;
                while (currentNode != null)
                {
                    LinkedList nextDistince = currentNode.next;
                    while (nextDistince != null && nextDistince.value == currentNode.value)
                    {
                        nextDistince = nextDistince.next;
                    }

                    currentNode.next = nextDistince;
                    currentNode = nextDistince;
                }

                return linkedList;
            }

            public class LinkedList
            {
                public int value;
                public LinkedList next = null;
                public LinkedList(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region MiddleNode
        /// <summary>
        /// 
        /// </summary>
        public class MiddleNodeClass
        {
            public class LinkedList
            {
                public int value;
                public LinkedList next;

                public LinkedList(int value)
                {
                    this.value = value;
                    this.next = null;
                }
            }

            public LinkedList MiddleNode(LinkedList linkedList)
            {
                LinkedList slowNode = linkedList;
                LinkedList fastnode = linkedList;
                while (fastnode != null && fastnode.next != null)
                {
                    slowNode = slowNode.next;
                    fastnode = fastnode.next.next;
                }

                return slowNode;
            }
        }
        #endregion

        #region NthFibonacci
        /// <summary>
        /// 
        /// </summary>
        public static class NthFibonacciClass
        {
            public static int GetNthFib(int n)
            {
                if (n == 2)
                {
                    return 1;
                }
                else if (n == 1)
                {
                    return 0;
                }
                else
                    return GetNthFib(n - 1) + GetNthFib(n - 2);
            }
        }
        #endregion

        #region ProductSum
        /// <summary>
        /// 
        /// </summary>
        public static class ProductSumClass
        {
            public static int ProductSum(List<object> array)
            {
                return ProductSumHelper(array, 1);
            }

            public static int ProductSumHelper(List<object> array, int multiplier)
            {
                int sum = 0;
                foreach (object item in array)
                {
                    if (item is IList<Object>)
                    {
                        sum += ProductSumHelper((List<object>)item, multiplier + 1);
                    }
                    else
                    {
                        sum += (int)item;
                    }
                }
                return sum * multiplier;
            }
        }
        #endregion

        #region BinarySeach
        /// <summary>
        /// 
        /// </summary>
        public class BinarySeachIterativelyClass
        {
            public int BinarySearchIteritevely(int[] inputArray, int numberOfElements, int key)
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

            public int BinarysearchRecursion(int[] A, int key, int l, int r)
            {
                if (l > r)
                    return -1;
                else
                {
                    int mid = (l + r) / 2;
                    if (key == A[mid])
                        return mid;
                    else if (key < A[mid])
                        return BinarysearchRecursion(A, key, l, mid - 1);
                    else if (key > A[mid])
                        return BinarysearchRecursion(A, key, mid + 1, r);
                }
                return -1;
            }
        }
        #endregion

        #region FindThreeLargestNumbers
        /// <summary>
        /// 
        /// </summary>
        public static class FindThreeLargestNumbersClass
        {
            public static int[] FindThreeLargestNumbers(int[] array)
            {
                int[] threeLargest = { Int32.MinValue, Int32.MinValue, Int32.MinValue };
                foreach (int num in array)
                {
                    updateLargest(threeLargest, num);
                }
                return threeLargest;
            }
            public static void updateLargest(int[] threeLargest, int num)
            {
                if (num > threeLargest[2])
                {
                    shiftAndUpdate(threeLargest, num, 2);
                }
                else if (num > threeLargest[1])
                {
                    shiftAndUpdate(threeLargest, num, 1);
                }
                else if (num > threeLargest[0])
                {
                    shiftAndUpdate(threeLargest, num, 0);
                }
            }
            public static void shiftAndUpdate(int[] array, int num, int idx)
            {
                for (int i = 0; i <= idx; i++)
                {
                    if (i == idx)
                    {
                        array[i] = num;
                    }
                    else
                    {
                        array[i] = array[i + 1];
                    }
                }
            }
        }
        #endregion

        #region BubbleSort
        /// <summary>
        /// 
        /// </summary>
        public static class BubbleSortClass
        {
            public static int[] BubbleSort(int[] array)
            {
                if (array.Length == 0)
                {
                    return new int[] { };
                }
                bool isSorted = false;
                int counter = 0;
                while (!isSorted)
                {
                    isSorted = true;
                    for (int i = 0; i < array.Length - 1 - counter; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            swap(i, i + 1, array);
                            isSorted = false;
                        }
                    }
                    counter++;
                }
                return array;
            }
            public static void swap(int i, int j, int[] array)
            {
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
        #endregion

        #region InsertionSort
        /// <summary>
        /// 
        /// </summary>
        public class InsertionSortClass
        {
            // Best: O(n) time | O(1) space
            // Average: O(n^2) time | O(1) space
            // Worst: O(n^2) time | O(1) space
            public static int[] InsertionSort(int[] array)
            {
                if (array.Length == 0)
                {
                    return new int[] { };
                }
                for (int i = 1; i < array.Length; i++)
                {
                    int j = i;
                    while (j > 0 && array[j] < array[j - 1])
                    {
                        swap(j, j - 1, array);
                        j -= 1;
                    }
                }
                return array;
            }
            public static void swap(int i, int j, int[] array)
            {
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
        #endregion

        #region SelectionSort
        /// <summary>
        /// 
        /// </summary>
        public class SelectionSortClass
        {

            public int[] SelectionSort(int[] array, int numberOfElements)
            {
                for (int i = 0; i < numberOfElements - 1; i++)
                {
                    int posistion = i;
                    for (int j = i + 1; j < numberOfElements; j++)
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
        #endregion

        #region IsPalindrome
        /// <summary>
        /// 
        /// </summary>
        public class PalindromeCheckClass
        {
            // O(n) time | O(1) space
            public static bool IsPalindrome(string str)
            {
                int leftIdx = 0;
                int rightIdx = str.Length - 1;
                while (leftIdx < rightIdx)
                {
                    if (str[leftIdx] != str[rightIdx])
                    {
                        return false;
                    }
                    leftIdx++;
                    rightIdx--;
                }
                return true;
            }
        }
        #endregion

        #region CaesarCypherEncryptor
        /// <summary>
        /// Given a non empty string of lowercase letters and non-negative
        /// integer representing a key. write a function that returns a
        /// new string obtained by shifting every letter in the input
        /// string by k position in the alphabet,
        /// where k is the key.
        /// 
        /// Note that letters should "wrap" around;
        /// in other words, the letter  shifted by
        /// one returns letter a
        /// 
        /// </summary>
        public class CaesarCipherEncryptorClass
        {
            // O(n) time | O(n) space
            public static string CaesarCypherEncryptor(string str, int key)
            {
                char[] newLetters = new char[str.Length];
                int newKey = key % 26;
                for (int i = 0; i < str.Length; i++)
                {
                    newLetters[i] = GetNewLetter(str[i], newKey);
                }
                return new string(newLetters);
            }
            public static char GetNewLetter(char letter, int key)
            {
                int newLetterCode = letter + key;
                return newLetterCode <= 122 ? (char)newLetterCode : (char)(96 + newLetterCode % 122);
            }
        }
        #endregion

        #region RunLengthEncoding
        /// <summary>
        /// Write a function that takes in a non-empty
        /// string and returns it's run-length encoding.
        /// From Wikipedia, "run-length encoding is a form
        /// of lossless data compression in which runs of
        /// data are stored as a single data value and count
        /// rather than as the original run". For this problem,
        /// a run of data is any sequence consecutive, identical
        /// characters. So the run "AAA" would be run-length-encoded
        /// as "3A".
        /// 
        /// To make things more complicated, however, the input string
        /// can contain all sorts of special characters, including numbers
        /// And since encoded data must be decodable, this means that
        /// we can't naively run-length-encode long runs. For example,
        /// the run "AAAAAAAAAAAA" (12A)s, can naively be decoded as "12A"
        /// sinc this string can be decoded as either "AAAAAAAAAAAA" or
        /// "1AA". Thus, long runs(runs of 10 or more characters) should
        /// be encoded in a split fashion; the aforementioned run should be
        /// encoded as "9A3A".
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns>String</returns>
        public class RunLengthEncodingClass
        {
            public string RunLengthEncoding(string stringArray)
            {
                //O(n) time | O(n) space - where n is the length of the input string
                StringBuilder stringBuilder = new StringBuilder();
                int currentLength = 1;
                for (int i = 1; i < stringArray.Length; i++)
                {
                    char currentChar = stringArray[i];
                    char previousChar = stringArray[i - 1];

                    if ((currentChar != previousChar) || (currentLength == 9))
                    {
                        stringBuilder.Append(currentLength.ToString());
                        stringBuilder.Append(previousChar);
                        currentLength = 0;
                    }

                    currentLength += 1;
                }

                stringBuilder.Append(currentLength.ToString());

                stringBuilder.Append(stringArray[stringArray.Length - 1]);

                return stringBuilder.ToString();
            }
        }
        #endregion

        #region CommonCharacters
        /// <summary>
        /// 
        /// </summary>
        public class CommonCharactersClass
        {
            public string[] CommonCharacters(string[] strings)
            {
                Dictionary<char, int> characterCounts = new Dictionary<char, int>();
                foreach (var str in strings)
                {
                    HashSet<char> uniqueStringChars = new HashSet<char>();
                    for (int i = 0; i < str.Length; i++)
                    {
                        uniqueStringChars.Add(str[i]);
                    }

                    foreach (var character in uniqueStringChars)
                    {
                        if (!characterCounts.ContainsKey(character))
                        {
                            characterCounts[character] = 0;
                        }
                        characterCounts[character] = characterCounts[character] + 1;
                    }
                }

                List<char> finalChars = new List<char>();
                foreach (var characterCount in characterCounts)
                {
                    char charater = characterCount.Key;
                    int count = characterCount.Value;
                    if (count == strings.Length)
                    {
                        finalChars.Add(charater);
                    }
                }

                string[] finalCharArray = new string[finalChars.Count];
                for (int i = 0; i < finalCharArray.Length; i++)
                {
                    finalCharArray[i] = finalChars[i].ToString();
                }
                return finalCharArray;
            }
        }
        #endregion

        #region GenerateDocument
        /// <summary>
        /// 
        /// </summary>
        public class GenerateDocumentClass
        {
            public bool GenerateDocument(string characters, string document)
            {
                HashSet<char> alreadyCounted = new HashSet<char>();

                for (int index = 0; index < document.Length; index++)
                {
                    char character = document[index];
                    if (alreadyCounted.Contains(character))
                    {
                        continue;
                    }

                    int documentFrequency = CountcharFrequency(character, document);
                    int characterFrequency = CountcharFrequency(character, characters);
                    if (documentFrequency > characterFrequency)
                    {
                        return false;
                    }

                    alreadyCounted.Add(character);
                }

                return true;
            }

            private int CountcharFrequency(char character, string target)
            {
                int frequency = 0;
                for (int index = 0; index < target.Length; index++)
                {
                    char c = target[index];
                    if (c == character)
                    {
                        frequency += 1;
                    }
                }

                return frequency;
            }
        }
        #endregion

        #region FirstNonRepeatingCharacter
        /// <summary>
        /// 
        /// </summary>
        public class FirstNonRepeatingCharacterClass
        {
            public int FirstNonRepeatingCharacter(string str)
            {
                Dictionary<Char, int> charaterFrequency = new Dictionary<Char, int>();

                for (int i = 0; i < str.Length; i++)
                {
                    char character = str[i];
                    charaterFrequency[character] =
                        charaterFrequency.GetValueOrDefault(character, 0) + 1;
                }

                for (int i = 0; i < str.Length; i++)
                {
                    char character = str[i];
                    if (charaterFrequency[character] == 1)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }
        #endregion  

        #region Semordnilap
        /// <summary>
        /// 
        /// </summary>
        public class SemordnilapClass
        {
            public List<List<string> > Semordnilap(string[] input) {
                HashSet<string> wordsSet = new HashSet<string>(input);
                List<List<string>> semordnilapPairs = new List<List<string>>();

                foreach (string word in input) 
                {
                    char[] chars = word.ToCharArray();
                    Array.Reverse(chars);
                    string reverse = new string(chars);
                    if (wordsSet.Contains(reverse) && !reverse.Equals(word))
                    {
                        List<string> semordnilapPair = new List<string> { word, reverse };
                        semordnilapPairs.Add(semordnilapPair);
                        wordsSet.Remove(word);
                        wordsSet.Remove(reverse);
                    }
                }
                return semordnilapPairs;
            }
            
        }
        #endregion

        #region ReverseWordsInString
        /// <summary>
        /// 
        /// </summary>
        public class ReverseWordsInStringClass
        {
            public string ReverseWordsInString(string str)
            {
                List<string> words = new List<string>();
                int startOfWord = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    char charecter = str[i];

                    if (charecter == ' ')
                    {
                        words.Add(str.Substring(startOfWord, i - startOfWord));
                        startOfWord = i;
                    }
                    else if (str[startOfWord] == ' ')
                    {
                        words.Add(" ");
                        startOfWord = i;
                    }
                }

                words.Add(str.Substring(startOfWord));
                words.Reverse();
                return String.Join(" ", words);
            }
        } 
        #endregion

        /*********************************************OTHER ALGORITHMS******************************************************************/

        #region FindClosestValueInBst
        /// <summary>
        /// Write a function that takes in a Binary Tree(BTS) and a target integer value and returns
        /// the closest value to that target value contained in the BTS.
        ///
        /// You can assume that there will only be one closet value.
        ///
        /// Each BTS node has an integer valie, a left child node, and right child node.A node is
        /// said to be a valid BTS node id and only id it satisfies the BTS property: its value is
        /// strictly greater than the values of every node to its value; its value is less than or
        /// equal to the values of every node to its right
        /// tha
        /// </summary>
        public static class FindClosestValueInBstClass
        {
            // Average: O(log(n)) time | O(log(n)) space
            // Worst: O(n) time | O(n) space
            public static int FindClosestValueInBst(Bst tree, int target)
            {
                return FindClosestValueInBst(tree, target, Int32.MaxValue);
            }

            private static int FindClosestValueInBst(Bst tree, int target, double closest)
            {
                if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
                {
                    closest = tree.value;
                }
                if (target < tree.value && tree.left != null)
                {
                    return FindClosestValueInBst(tree.left, target, closest);
                }
                else if (target > tree.value && tree.right != null)
                {
                    return FindClosestValueInBst(tree.right, target, closest);
                }
                else
                {
                    return (int)closest;
                }
            }
            public class Bst
            {
                public int value;
                public Bst left = null!;
                public Bst right = null!;
                public Bst(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

        #region TwoToOneTests
        /// <summary>
        /// Take 2 strings s1 and s2 including only letters from a to z. 
        /// Return a new sorted string, the longest possible, containing
        /// distinct letters - each taken only once - coming from s1 or s2.
        /// </summary>
        public class TwoToOneTestsClass
        {
            public static string Longest(string arrayOne, string arrayTwo)
            {


                return string.Concat((arrayOne + arrayTwo).Distinct().OrderBy(x => x));
            }

            public static string LongestTwo(string s1, string s2)
            {
                return
                        new string(
                            s1.ToCharArray()
                                .Distinct()
                                .Concat(s2.ToCharArray().Distinct())
                                .Distinct()
                                .OrderBy(x => x)
                                .ToArray());
            }

            public static string LongestDictionary(string s1, string s2)
            {
                Dictionary<char, int> table = new Dictionary<char, int>();
                foreach (char c in s1)
                {
                    if (!table.ContainsKey(c)) table[c] = 0;
                    table[c] = table[c] + 1;
                }
                foreach (char c in s2)
                {
                    if (!table.ContainsKey(c)) table[c] = 0;
                    table[c] = table[c] + 1;
                }
                char[] lstr = table.Keys.ToArray();
                Array.Sort(lstr);
                string res = string.Join("", lstr);
                return res;
            }


        }
        #endregion

        #region SumTwoSmallestNumbers
        /// <summary>
        /// Create a function that returns the sum of the two lowest positive numbers 
        /// given an array of minimum 4 positive integers. No floats or non-positive 
        /// integers will be passed.

        /// For example, when an array is passed like[19, 5, 42, 2, 77], the output should be 7.
        /// [10, 343445353, 3453445, 3453545353453] should return 3453455.
        /// </summary>
        public class SumTwoSmallestNumbersClass
        {
            public static int SumTwoSmallestNumbers(int[] numbers)
            {
                Array.Sort(numbers);
                var result = 0;
                for (int i = 0; i < 2; i++)
                {
                    result += numbers[i];
                }
                return result;
            }
        }
        #endregion

        #region StringExtensions

        /// <summary>
        /// Create a method to see whether the string is ALL CAPS.
        /// </summary>
        public class StringExtensionsClass
        {
            public static bool StringExtensions(string value)
            {
                return !value.Any(x => Char.IsLower(x));
            }
        }
        #endregion

        #region QuickSort        
        public class QuickSortExerciseClass
        {
            public static void QuickSort(int[] array, int low, int high)
            {
                if (low > high)
                {
                    int pi = Partition(array, low, high);
                    QuickSort(array, low, pi - 1);
                    QuickSort(array, pi + 1, high);
                }
                throw new NotImplementedException();

            }

            private static int Partition(int[] array, int low, int high)
            {
                int pivot = array[low];
                int i = array[low + 1];
                int j = array[high];

                do
                {
                    while (i <= j && array[i] <= pivot)
                    {
                        i = i + 1;
                    }
                    while (i <= j && array[j] > pivot)
                        j = j - 1;
                    if (i <= j)
                        Swap(array, i, j);

                } while (i < j);
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
        #endregion

        #region MinMax
        /// <summary>
        /// Ben has a very simple idea to make some profit: he buys something and sells it again. 
        /// Of course, this wouldn't give him any profit at all if he was simply to buy and 
        /// sell it at the same price. Instead, he's going to buy it for the lowest 
        /// possible price and sell it at the highest.


        /// -Write a function that returns both the minimum and maximum number of the given list/array.
        /// </summary>
        /// <returns></returns>
        public class MinMaxClass
        {
            public static int[] MinMax(int[] lst)
            {
                Array.Sort(lst);
                var min = lst[0];
                var max = lst[lst.Length - 1];

                return new int[] { min, max };
            }
        }
        #endregion

        #region InsertionSort        
        public class InsertionSortExerciseClass
        {
            public static void InsertionSort(int[] array, int limit)
            {
                for (int i = 1; i < limit; i++)
                {
                    int temp = array[i];
                    int position = i;

                    while (position > 0 && array[position - 1] > temp)
                    {
                        array[position] = array[position - 1];
                        position = position - 1;
                    }

                    array[position] = temp;
                }
            }
        }
        #endregion

        #region HighAndLow
        /// <summary>
        /// In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.
        /// 
        /// -All numbers are valid Int32, no need to validate them.
        /// -There will always be at least one number in the input string.
        /// -Output string must be two numbers separated by a single space, and highest number is first.
        /// </summary>
        public class HighAndLowClass
        {
            public static string HighAndLow(string numbers)
            {
                var parsed = numbers.Split().Select(int.Parse);
                return parsed.Max() + " " + parsed.Min();
            }

            public static string HighAndLowSolutionTwo(string numbers)
            {
                var parsed = numbers.Split().Select(int.Parse);
                return parsed.Max() + " " + parsed.Min();
            }

            public static string HighAndLowSolutionThree(string numbers)
            {
                var numbersList = numbers.Split(' ').Select(x => Convert.ToInt32(x));
                return string.Format("{0} {1}", numbersList.Max(), numbersList.Min());
            }

            public static string HighAndLowSolutionFour(string numbers)
            {
                var nums = numbers.Split(' ').Select(Int32.Parse).ToArray();
                return $"{nums.Max()} {nums.Min()}";
            }


        }
        #endregion

        #region DescendingOrder
        /// <summary>
        /// Your task is to make a function that can take any non-negative 
        /// integer as an argument and return it with its digits in 
        /// descending order. Essentially, rearrange the digits to 
        /// create the highest possible number.
        /// </summary>
        public class DescendingOrderClass
        {
            public static int DescendingOrder(int number)
            {
                var splittedList = number.ToString().Select(x => (int)char.GetNumericValue(x)).ToArray();
                Array.Sort(splittedList);
                Array.Reverse(splittedList);

                var result = String.Join("", new List<int>(splittedList).ConvertAll(i => i.ToString()).ToArray());

                return Convert.ToInt32(result);
            }

            public static int DescendingOrderSolutionTwo(int number)
            {
                return int.Parse(string.Concat(number.ToString().OrderByDescending(x => x)));
            }

            public static int DescendingOrderSolutionThree(int num)
            {
                char[] arr = num.ToString().ToCharArray();
                Array.Sort(arr);
                Array.Reverse(arr);
                return Convert.ToInt32(new string(arr));
            }
        }
        #endregion

        #region BreakCamelCaseClass
        /// <summary>
        /// Complete the solution so that the function will break up 
        /// camel casing, using a space between words.
        ///
        /// Example
        /// "camelCasing"  =>  "camel Casing"
        /// "identifier"   =>  "identifier"
        /// ""             =>  ""
        /// </summary>
        public class BreakCamelCaseClass
        {
            public static string BreakCamelCase(string str)
            {
                return String.Join("", str.Select(x => char.IsUpper(x) ? " " + x : x.ToString()));
            }

            public static string BreakCamelCaseSolutionOne(string str)
            {
                var sb = new StringBuilder();
                foreach (var symbol in str)
                {
                    if (char.IsUpper(symbol)) sb.Append(" ");
                    sb.Append(symbol);
                }
                return sb.ToString().Trim();
            }

            public static string BreakCamelCaseSecondSolution(string str)
            {
                var res = new StringBuilder();
                foreach (var ch in str)
                {
                    if (ch >= 'A' && ch <= 'Z')
                    {
                        res.Append(" ");
                    }
                    res.Append(ch);
                }
                return res.ToString();
            }
        }
        #endregion

        #region WellofIdeasEasyVersion
        /// <summary>
        /// For every good kata idea there seem to be quite a few bad ones!
        //In this kata you need to check the provided array (x) for good
        //ideas 'good' and bad ideas 'bad'. If there are one or two good
        //ideas, return 'Publish!', if there are more than 2 return
        //'I smell a series!'. If there are no good ideas, as is often
        //the case, return 'Fail!'.
        /// </summary>
        public class WellofIdeasEasyVersionClass
        {
            public static IEnumerable<char> Well(string[] stringsArray)
            {
                IEnumerable<char> result = new char[stringsArray.Length];
                for (int i = 0; i < stringsArray.Length; i++)
                {
                    if (stringsArray.Contains(stringsArray[i]))
                    {
                        //result[]
                    }

                }


                //string[] badwords = newStringArray.Split(newStringArray, StringSplitOptions.None);
                //foreach (string firstName in firstNames)
                //    Console.WriteLine(firstName);
                //string[] authorsList = stringsArray.Split(" ,");

                return result;
            }
        }
        #endregion

        #region ArraysEqual
        /// <summary>
        /// Write a program, which reads two arrays from the console and 
        /// checks whether they are equal (two arrays are equal when they 
        /// are of equal length and all of their elements, which have 
        /// the same index, are equal).
        /// </summary>
        public class ArraysAreEqualClass
        {
            public static bool ArraysEqual(int[] arrayOne, int[] arrayTwo)
            {

                int[] arr1 = new int[arrayOne.Length];
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    arr1[i] = arrayOne[i];
                }
                int[] arr2 = new int[arrayTwo.Length];
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    arr2[i] = arrayTwo[i];
                }

                int counterOfEqualElements = 0;
                if (arr1.Length != arr2.Length)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (arr1[i] == arr2[i])
                        {
                            counterOfEqualElements++;
                        }
                    }
                    if (counterOfEqualElements == arr1.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public static int[] CheckArray(int[] array)
            {
                //array[0] = 1;
                //array[1] = 2;
                //array[2] = 3;
                //array[3] = 4;
                //array[4] = 5;
                //array[5] = 6;

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i + 1;
                }

                return array;
            }

            public static int[,] GetBestPlatform(int[,] matrix)
            {
                long bestSum = long.MinValue;
                int bestRow = 0;
                int bestCol = 0;
                int[,] newMatrix = new int[2, 4];

                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        long sum = matrix[row, col] +
                            matrix[row, col + 1] +
                            matrix[row + 1, col] +
                            matrix[row + 1, col + 1];

                        if (sum > bestSum)
                        {
                            bestSum = sum;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }
                return matrix;
            }


            public static int[,] MatriceArray(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i, j];
                    }
                }
                return matrix;
            }

            public static int[] ReverseArray(int[] initialArray)
            {
                // Get array size
                int length = initialArray.Length;
                // Declare and create the reversed array
                int[] reversed = new int[length];
                // Initialize the reversed array
                for (int index = 0; index < length; index++)
                {
                    reversed[length - index - 1] = initialArray[index];
                }

                return reversed;
            }

            public static bool SymmetricArray(int[] arrayWithValue)
            {

                int n = arrayWithValue.Length;
                int[] array = new int[n];

                for (int i = 0; i < n; i++)
                {
                    array[i] = arrayWithValue[i];
                }
                bool symmetric = true;
                for (int i = 0; i < array.Length / 2; i++)
                {
                    if (array[i] != array[n - i - 1])
                    {
                        return symmetric = false;
                        break;
                    }
                }
                return symmetric;
            }
        }
        #endregion        

        #region SumArray
        /// <summary>
        /// Write a function that takes an array of numbers 
        /// and returns the sum of the numbers. The numbers 
        /// can be negative or non-integer. If the array 
        /// does not contain any numbers then you should return 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static class SumArrayClass
        {
            public static double SumArray(double[] array)
            {
                double[] newArray = new double[array.Length];
                double sumArray = 0;

                foreach (var item in array)
                {
                    sumArray = item + item;
                }

                return sumArray;
            }
        }
        #endregion

        #region SubsequenceWithMaxSum
        /// <summary>
        /// Write a program, which finds a subsequence of 
        /// numbers with maximal sum. E.g.: 
        /// {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> 11
        /// </summary>
        public class SubsequenceWithMaxSumClass
        {
            public void SubsequenceWithMaxSum()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int maxSum = 0;
                int currentSum = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    currentSum += arr[i];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                    else if (currentSum < 0)
                    {
                        currentSum = 0;
                    }
                }

                Console.WriteLine(maxSum);

            }
        }
        #endregion

        #region ShellSort
        /// <summary>
        /// Need to complete this
        /// </summary>
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
        #endregion   

        #region Linearsearch
        /// <summary>
        /// 
        /// </summary>
        public class LinearSearchclass
        {
            public static int Linearsearch(int[] inputArray, int numberOfElements, int key)
            {
                int index = 0;
                while (index < numberOfElements)
                {
                    if (inputArray[index] == key)
                        return index;
                    index++;
                }
                return -1;
            }
        }
        #endregion

        #region PrintMatrix
        /// <summary>
        /// Write a program, which creates square matrices like those in the 
        /// figures below and prints them formatted to the console. 
        /// The size of the matrices will be read from the console. 
        /// See the examples for matrices with size of 4 x 4 and 
        /// make the other sizes in a similar fashion:
        /// </summary>
        public class PrintMatrixClass
        {
            public static void PrintMatrix()
            {
                int n = int.Parse(Console.ReadLine());

                int[,] matrix = DoMatrixA(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixB(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixC(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixD(n);
                PrintMatrix(matrix);

                Console.WriteLine();
            }

            static int[,] DoMatrixA(int dim)
            {
                int[,] matrix = new int[dim, dim];

                matrix[0, 0] = 1;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    matrix[0, i] = matrix[0, i - 1] + dim;
                }

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i - 1, j] + 1;
                    }
                }

                return matrix;
            }

            static int[,] DoMatrixB(int dim)
            {
                int[,] matrix = new int[dim, dim];
                matrix[0, 0] = 1;

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (i % 2 == 1)
                    {
                        matrix[0, i] = matrix[0, i - 1] + dim * 2 - 1;
                    }
                    else
                    {
                        matrix[0, i] = matrix[0, i - 1] + 1;
                    }
                }

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j % 2 == 1)
                        {
                            matrix[i, j] = matrix[i - 1, j] - 1;
                        }
                        else
                        {
                            matrix[i, j] = matrix[i - 1, j] + 1;
                        }
                    }
                }

                return matrix;
            }

            static int[,] DoMatrixC(int dim)
            {
                int[,] matrix = new int[dim, dim];
                matrix[dim - 1, 0] = 1;
                int counter = 1;
                for (int row = dim - 2; row >= 0; row--)
                {
                    matrix[row, 0] = matrix[row + 1, 0] + counter;
                    int newRow = row;
                    for (int diagonal = 1; diagonal <= counter; diagonal++)
                    {
                        matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                        newRow++;
                    }
                    counter++;
                }

                matrix[0, dim - 1] = dim * dim;
                int diagonalLength = 2;
                int posX = 1;
                int posY = dim - 1;
                int prevX = 0;
                int prevY = dim - 1;

                for (int i = 1; i < counter - 1; i++)
                {
                    for (int j = 1; j <= diagonalLength; j++)
                    {
                        matrix[posX, posY] = matrix[prevX, prevY] - 1;
                        prevX = posX;
                        prevY = posY;
                        posX--;
                        posY--;
                    }
                    diagonalLength++;
                    posX = i + 1;
                    posY = dim - 1;
                }

                return matrix;
            }

            static int[,] DoMatrixD(int dim)
            {
                int[,] matrix = new int[dim, dim];
                int numConcentricSquares = (int)Math.Ceiling((dim) / 2.0);
                int j;
                int sideLen = dim;
                int currNum = 0;

                for (int i = 0; i < numConcentricSquares; i++)
                {

                    // do left side
                    for (j = 0; j < sideLen; j++)
                    {
                        matrix[i + j, i] = ++currNum;
                    }

                    // do bottom side
                    for (j = 1; j < sideLen - 1; j++)
                    {
                        matrix[dim - 1 - i, i + j] = ++currNum;
                    }

                    // do right side
                    for (j = sideLen - 1; j > 0; j--)
                    {
                        matrix[i + j, dim - 1 - i] = ++currNum;
                    }

                    // do top side
                    for (j = sideLen - 1; j > 0; j--)
                    {
                        matrix[i, i + j] = ++currNum;
                    }

                    sideLen -= 2;
                }

                return matrix;
            }

            static void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0, 4}", matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
        #endregion

        #region MostFrequentNumber
        /// <summary>
        /// 
        /// </summary>
        public class MostFrequentNumberClass
        {
            public static void MostFrequentNumber()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int tempCounter = 1;
                int counter = 0;
                int index = 0;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            tempCounter++;
                        }
                    }
                    if (tempCounter > counter)
                    {
                        counter = tempCounter;
                        index = i;
                    }
                    tempCounter = 0;

                }
                Console.WriteLine(arr[index] + "  " + counter + " times");

            }
        }
        #endregion

        #region MergeSort
        /// <summary>
        /// 
        /// </summary>
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
        #endregion

        #region MaximalSequenceOfIncreasingElements
        /// <summary>
        /// Write a program, which finds the maximal sequence of increasing 
        /// elements in an array arr[n]. It is not necessary the elements
        /// to be consecutively placed. 
        /// E.g.: {9, 6, 2, 7, 4, 7, 6, 5, 8, 4} > {2, 4, 6, 8}.
        /// </summary>
        public class MaximalSequenceOfIncreasingElementsClass
        {

        }
        #endregion

        #region LongestSeqOfEqualElements
        /// <summary>
        /// 
        /// </summary>
        public class LongestSeqOfEqualElementsClass
        {
            public static string[] LongestSeqOfEqualElements()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int counter = 0;
                int maxSequence = 0;
                int index = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    counter = 0;
                    int j = i;

                    while (arr[i] == arr[j])
                    {
                        counter++;
                        j++;
                        if (j >= arr.Length)
                        {
                            break;
                        }
                    }

                    if (counter > maxSequence)
                    {
                        maxSequence = counter;
                        index = i;
                    }
                }

                for (int i = index; i <= index + maxSequence - 1; i++)
                {
                    if (i != index + maxSequence - 1)
                    {
                        Console.Write(arr[i] + ", ");
                    }
                    else
                    {
                        Console.WriteLine(arr[i]);
                    }

                    //return arr[i].ToCharArray();
                }

                return new string[0];
            }
        }
        #endregion

        #region ListFilterer
        /// <summary>
        /// 
        /// </summary>
        public class ListFiltererClass
        {
            public static IEnumerable<int> GetIntegersFromList(List<object> list)
            {
                var intergerList = new List<int>();
                foreach (var item in list)
                {
                    if (item is int)
                    {
                        intergerList.Add((int)item);
                    }
                }

                return intergerList;
            }

            public static IEnumerable<int> GetIntegersFromListCast(List<object> list)
            {

                return list.OfType<int>().Cast<int>();
            }
        }
        #endregion

        #region LinkedList
        public class LinkedListClass
        {
            private class Node
            {
                public int element;
                public Node next;
                public Node(int e, Node n)
                {
                    element = e;
                    next = n;
                }
            }
            private Node? first;
            private Node? last;
            private int size;

            public LinkedListClass()
            {
                first = null;
                last = null;
                size = 0;
            }

            public int Count()
            {
                return size;
            }

            public bool isEmpty()
            {
                return size == 0;
            }

            public void AddLast(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                    first = newest;
                else
                    last.next = newest;
                last = newest;
                size = size + 1;
            }

            public void AddFirst(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    first = newest;
                    last = newest;
                }
                else
                {
                    newest.next = first;
                    first = newest;
                }
                size = size + 1;
            }

            public void AddAny(int e, int position)
            {
                if (position <= 0 || position >= size)
                {
                    Console.WriteLine("Invalid Position");
                    return;
                }
                Node newest = new Node(e, null);
                Node p = first;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                newest.next = p.next;
                p.next = newest;
                size = size + 1;
            }

            public int RemoveFirst()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is Empty");
                    return -1;
                }
                else
                {
                    int e = first.element;
                    first = first.next;
                    size = size - 1;
                    if (isEmpty())
                        last = null;
                    return e;
                }
            }

            public int RemoveLast()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is Empty");
                    return -1;
                }
                Node p = first;
                int i = 1;
                while (i < size - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                last = p;
                p = p.next;
                int e = p.element;
                last.next = null;
                size = size - 1;
                return e;
            }

            public int RemoveAny(int position)
            {
                if (position <= 0 || position >= size - 1)
                {
                    Console.WriteLine("Invalid Position");
                    return -1;
                }
                Node p = first;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                int e = p.next.element;
                p.next = p.next.next;
                size = size - 1;
                return e;
            }
            /// <summary>
            /// Search linkedlist by key
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public int Search(int key)
            {
                Node p = first;
                int index = 0;
                while (p != null)
                {
                    if (p.element == key)
                        return index;
                    p = p.next;
                    index = index + 1;
                }
                return -1;
            }
        }
        #endregion

        #region Lexicographically
        /// <summary>
        /// Write a program, which compares two arrays of type char lexicographically 
        /// (character by character) and checks, which one is first in the lexicographical order.
        /// </summary>
        public static class LexicographicallyClass
        {
            public static string Lexicographically(string inputArr1, string inputArr2)
            {

                char[] arr1 = inputArr1.ToCharArray();
                char[] arr2 = inputArr2.ToCharArray();
                var results = string.Empty;

                int i = 0;
                int j = 0;
                bool equal = false;

                while (i < arr1.Length && j < arr2.Length)
                {
                    if (arr1[i] > arr2[j])
                    {

                        equal = false;
                        break;
                    }
                    else if (arr1[i] < arr2[j])
                    {

                        equal = false;
                        break;
                    }
                    else
                    {
                        equal = true;
                    }

                    i++;
                    j++;
                }

                if (equal == true)
                {
                    if (arr1.Length < arr2.Length)
                    {
                        results = inputArr1;
                    }
                    else if (arr1.Length > arr2.Length)
                    {
                        results = inputArr2;
                    }
                    else
                    {
                        results = "No difference";
                    }
                }
                return results;
            }
        }
        #endregion

        #region FindTheLongestSubsequeanceOfEqualElements
        /// <summary>
        /// Write a program, which finds the longest sequence of equal string
        /// elements in a matrix.A sequence in a matrix we define as a set of
        /// neighbor elements on the same row, column or diagonal.
        /// </summary>
        public class FindTheLongestSubsequeanceOfEqualElementsClass
        {
            static string[,]? matrix;
            public static void FindTheLongestSubsequeanceOfEqualElements()
            {
                // Initialize the matrix
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                matrix = new string[n, m];

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    string[] transformation = input.Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = transformation[j];
                    }

                }

                // Find the longest sequence of equal strings
                Dictionary<string, int> sequence = new Dictionary<string, int>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int neighbourCount = LookupNeighbours(row, col);
                        if (neighbourCount == 0)
                        {
                            if (sequence.ContainsKey(matrix[row, col]))
                            {
                                sequence.Remove(matrix[row, col]);
                            }
                        }
                        else
                        {
                            if (sequence.ContainsKey(matrix[row, col]))
                            {
                                sequence[matrix[row, col]]++;
                            }
                            else
                            {
                                sequence.Add(matrix[row, col], 1);
                            }
                        }
                    }
                }

                var sortedDict = (from entry in sequence orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                KeyValuePair<string, int> element;
                int index = sortedDict.Count - 1;
                element = sortedDict.ElementAt(index);

                int repeats = element.Value;
                string str = element.Key;

                string result = "";
                for (int i = 1; i <= repeats; i++)
                {
                    result += " ";
                    result += str;
                }

                Console.WriteLine(result);

            }

            private static int LookupNeighbours(int x, int y)
            {
                int result = 0;
                for (int row = x - 1; row <= x + 1; row++)
                {
                    if (row < 0 || row > matrix.GetLength(0) - 1)
                    {
                        continue;
                    }
                    for (int col = y - 1; col <= y + 1; col++)
                    {
                        if (col < 0 || col > matrix.GetLength(1) - 1 || (row == x && col == y))
                        {
                            continue;
                        }
                        if (matrix[row, col] == matrix[x, y])
                        {
                            result++;
                        }
                    }
                }
                return result;
            }

        }
        #endregion

        #region FindSubsequenceOfGivenSum
        /// <summary>
        /// Write a program to find a sequence of neighbor numbers 
        /// in an array, which has a sum of certain number S. 
        /// Example: {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}.
        /// </summary>
        public class FindSubsequenceOfGivenSumClass
        {
            public static int[] FindSequenceOfGivenSum(int[] numbersArray, int sum)
            {
                long currentSum = 0;
                for (int currentEndIndex = 0; currentEndIndex < numbersArray.Length; currentEndIndex++)
                {
                    currentSum = 0;
                    for (int currentSumIndex = currentEndIndex; currentSumIndex >= 0; currentSumIndex--)
                    {
                        currentSum += numbersArray[currentSumIndex];
                        if (currentSum == sum)
                        {
                            PrintArray(currentSumIndex, currentEndIndex, numbersArray);
                            break;
                            //return;
                        }
                    }
                }
                Console.WriteLine("There is no sequence of given sum!");
                return numbersArray;
            }

            static void PrintArray(int startIndex, int endIndex, int[] array)
            {
                Console.WriteLine("Sequence of given sum is present:");
                Console.Write("{ ");
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.Write("}");
            }

        }
        #endregion

        #region Find3x3MatrixWithMaxSum
        /// <summary>
        /// Write a program, which creates a rectangular array with size of n by m
        /// elements.The dimensions and the elements should be read from the
        /// console.Find a platform with size of(3, 3) with a maximal sum.
        /// </summary>
        public class Find3x3MatrixWithMaxSumClass
        {
            private static int j;
            public static void Find3x3MatrixWithMaxSum()
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                int[,] matrix = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    string[] transformation = input.Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = int.Parse(transformation[j]);
                    }

                }

                int currentSum = 0;
                int maxSum = 0;
                int maxSquareX = 0;
                int maxSquareY = 0;
                // find square
                for (int i = 0; i < n - 2; i++)
                {
                    for (int j = 0; j < m - 2; j++)
                    {
                        for (int i2 = i; i2 < i + 3; i2++)
                        {
                            for (int j2 = j; j2 < j + 3; j2++)
                            {
                                currentSum += matrix[i2, j2];
                            }
                        }

                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            maxSquareX = j;
                            maxSquareY = i;
                        }
                        currentSum = 0;
                    }
                }
                // output
                for (int i2 = maxSquareY; i2 < maxSquareY + 3; i2++)
                {
                    for (int j2 = maxSquareX; j2 < maxSquareX + 3; j2++)
                    {
                        Console.Write(matrix[i2, j2] + " ");
                    }
                    Console.WriteLine();
                }

            }

        }
        #endregion
    }
}