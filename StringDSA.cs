using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    public class StringDSA
    {
        public static void SubStringOfAGivenString(string val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = i; j < val.Length; j++)
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

            while (right < val.Length)
            {
                if (!chars.Contains(val[right]))
                {
                    chars.Add(val[right]);
                    right++;
                    maxLength = Math.Max(maxLength, right - left);

                }
                else
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

            for (int i = 0; i < val.Length; i++)
            {
                StringBuilder s = new();
                for (int j = i; j < val.Length; j++)
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

            foreach (var item in dict.Keys)
            {
                if (dict[item] == 1)
                {
                    ans.Add(item);
                }
            }


            return ans.ToArray();
        }

        public static string LongestPalindromeTLE(string s)
        {
            string revString = Helper.ReveseString(s);
            if (revString == s)
            {
                return s;
            }
            Dictionary<string, int> dict = new();
            // substring of a given substring
            for (int i = 0; i < s.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = i; j < s.Length; j++)
                {
                    sb.Append(s[j]);
                    Console.WriteLine(sb);
                    string sb1 = sb.ToString();
                    if (sb1 == Helper.ReveseString(sb1))
                    {
                        if (!dict.ContainsKey(sb1.ToString()))
                        {
                            dict.Add(sb1.ToString(), sb1.ToString().Length);
                        }
                    }
                }

            }

            int maxLength = 0;
            string ans = "";
            foreach (var item in dict.Keys)
            {
                Console.WriteLine($"{item} - {dict[item]}");
                maxLength = Math.Max(maxLength, dict[item]);
            }

            if (dict.ContainsValue(maxLength))
            {
                string key = dict.FirstOrDefault(x => x.Value == maxLength).Key;
                ans = key;
            }

            return ans;
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int start = 0, maxLength = 1;

            // All substrings of length 1 are palindromes
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            // Check for substrings of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2
            for (int length = 3; length <= n; length++)
            {
                for (int i = 0; i < n - length + 1; i++)
                {
                    int j = i + length - 1;
                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        start = i;
                        maxLength = length;
                    }
                }
            }

            return s.Substring(start, maxLength);
        }

        public static string LongestPalindromeYoutube(string s)
        {
            string res = "";
            int resLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //odd
                int left = i, right = i + 1;

                while (left >= 0 && right < s.Length && s[left] == s[right])
                {

                    if (right - left + 1 > resLen)
                    {
                        res = s.Substring(left, right + 1);
                        resLen = right - left + 1;
                    }
                    left--;
                    right++;
                }
                // even length
                left = i; right = i + 1;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    if (right - left + 1 > resLen)
                    {
                        res = s.Substring(left, right + 1);
                        resLen = right - left + 1;
                    }
                    left -= 1;
                    right += 1;
                }
            }

            return res;
        }

        public static string LargestNumber(int[] nums)
        {
            Console.WriteLine("******Largest Number******");
            

            string[] arr = new string[nums.Length];

            if (nums[0] == 0)
            {
                return "0";
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = nums[i].ToString();
            }
            Array.Sort(arr ,(x,y) => (y + x).CompareTo(x + y));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
            }

            Console.WriteLine(sb.ToString());

            return sb.ToString();


        }

    }
}
