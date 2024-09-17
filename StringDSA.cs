using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    public  class StringDSA
    {
        public static void SubStringOfAGivenString(string val)
        {
            for(int i = 0; i < val.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for(int j=i; j < val.Length; j++)
                {
                    sb.Append(val[j]);
                    Console.WriteLine(sb);
                }
            }
        }

        //public static int LongestSubstringWithoutRepeatingCharacter(string val)
        //{
        //    int left = 0;
        //    int right = 0;
        //    int maxLength = 0;
        //    HashSet<char> chars = new();
        //    Dictionary<char, int> dict = new();

        //    while(right < val.Length) {
        //        if (!chars.Contains(val[right])) {
        //            chars.Add(val[right]);
        //            right++;
        //            maxLength = Math.Max(maxLength, right - left);
                
        //        } else
        //        {
        //            chars.Remove(val[left]);   
        //            left++;
        //        }
        //    }


        //    return maxLength;
        //}

        public static int LongestSubstringWithoutRepeatingCharacter(string val)
        {
            int left = 0, right = 0;
            int maxLength = 0;

            HashSet<char> chars = new();

            while(right < val.Length)
            {
                if (!chars.Contains(val[right])) {
                    chars.Add(val[right]);
                    right++;
                    maxLength = Math.Max(maxLength, right - left);

                } else
                {
                    chars.Remove(val[left]);
                    left++;
                }
            }
            Console.WriteLine($"{val} - {maxLength}");
            return maxLength;
        }

        public static int LongestSubstringWithoutRepeatingCharacteSlow(string val)
        {
            int maxLength = 0;

            for(int i = 0; i < val.Length;i++)
            {
                StringBuilder s = new();
                for(int j = i; j < val.Length;j++)
                {
                    if (s.ToString().IndexOf(val[j]) != -1)
                    {
                        break;
                    }
                    s.Append(val[j]);
                    maxLength = Math.Max(maxLength, s.Length);
                }
            }

            
            return maxLength;
        }

        public static string[] UncommonFromSentences(string s1, string s2)
        {
            Dictionary<string, int> dict = new();
            var s1Array = s1.Split(" ");
            var s2Array = s2.Split(" ");

            Helper.ProcessSentence(s1Array, dict);
            Helper.ProcessSentence(s2Array, dict);

            List<string> ans = new();

            foreach(var item in  dict.Keys)
            {
                if (dict[item] == 1)
                {
                    ans.Add(item);
                }
            }


            return ans.ToArray();
        }

        
    }
}
