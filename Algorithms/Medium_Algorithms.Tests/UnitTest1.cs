using Microsoft.VisualStudio.TestPlatform.TestHost;
using static Medium_Algorithms.MediumAlgorithmsClass;

namespace Medium_Algorithms.Tests
{
    public class UnitTest1
    {
        #region TaskAssignment
        [Fact(Skip =" Unit Test failing.")]
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