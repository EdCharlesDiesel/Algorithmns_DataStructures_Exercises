using System;
using System.Collections.Generic;
namespace WellofIdeasEasyVersion
{
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
}