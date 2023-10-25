namespace MinMax
{
    public class MinMaxClass
    {
        /// <summary>
        /// Ben has a very simple idea to make some profit: he buys something and sells it again. 
        /// Of course, this wouldn't give him any profit at all if he was simply to buy and 
        /// sell it at the same price. Instead, he's going to buy it for the lowest 
        /// possible price and sell it at the highest.

        
        /// -Write a function that returns both the minimum and maximum number of the given list/array.
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>

        public static int[] minMax(int[] lst)
        {
            Array.Sort(lst);
            var min = lst[0];
            var max = lst[lst.Length - 1];

            return new int[] { min, max };
        }
    }
}