namespace Lexicographically
{
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
            var results= string.Empty;

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
}