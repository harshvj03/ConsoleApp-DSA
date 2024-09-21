// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

Console.WriteLine("Hello, World!");

StringDSA.SubStringOfAGivenString("abc");
StringDSA.LongestSubstringWithoutRepeatingCharacter("abcabcbb");
StringDSA.LongestSubstringWithoutRepeatingCharacteSlow("abcabcbb");
StringDSA.UncommonFromSentences("this apple is sweet", "this apple is sour");
//var ans = StringDSA.LongestPalindrome(Constants.LongString);
var ans = StringDSA.LongestPalindromeYoutube("babad");
Console.WriteLine($"{ans} - answer");
    
int[] arr = new int[] {1, 10, 2 };
StringDSA.LargestNumber(arr);

StringDSA.GenerateParenthesis(3);
Console.WriteLine("Score of Parenthesis");
StringDSA.ScoreOfParentheses("(())");

Console.WriteLine("shortest palindrome");

var ans1 = StringDSA.LexicalOrder(13);

foreach (int i in ans1)
{
    Console.WriteLine(i);
}