namespace ListFilterer
{
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
}