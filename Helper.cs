using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public  class Helper
    {
        public static void ProcessSentence(string[] s1Array, Dictionary<string, int> dict)
        {
            for (int i = 0; i < s1Array.Length; i++)
            {
                if (!dict.ContainsKey(s1Array[i]))
                {
                    dict.Add(s1Array[i], 1);
                }
                else
                {
                    dict[s1Array[i]] = dict[s1Array[i]] + 1;
                }


            }

        }
    }
}
