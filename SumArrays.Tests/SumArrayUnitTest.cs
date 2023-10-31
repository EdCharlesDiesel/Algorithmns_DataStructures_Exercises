using System;

namespace SumArrays.Tests
{
    public class SumArrayUnitTest
    {       

        [Fact]
        public void Test1()
        {
            //Arrange 
            double[] inputArray1 = { 1, 5.2, 4, 0, -1, 9.2 };
            double[] inputArray2 = { 0 };
            
            var actual = SumArrays.SumArrayClass.SumArray(inputArray1);                

             Assert.Equal(18.399999999999999, actual); 
        }


    }
}