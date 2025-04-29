/* File Name: LeetCodeProblem030.cs
 * Name: Ayah Faour
 * Email:faouraj@mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 04/29/2025
 * Course #/Section: 3050/001
 * Semester/Year: Spring/2025
 * Brief Description of the assignment: Solving a LeetCode problem and printing it onto a web page.
 * Brief Description of what this module does: Allows us the show off our skills using asp controls.
 * Citations: https://chatgpt.com/ the prompt was "You are given a string s and an array of strings words. All the strings of words are of the same length.
A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated. For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order." and then I asked it to write it in C#.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forecasters_FinalProject
{
    public class LeetCodeProblem030
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (words.Length == 0 || s.Length == 0) return result;

            int wordLength = words[0].Length;
            int wordCount = words.Length;
            int totalLength = wordLength * wordCount;

            // Build a frequency map of words
            Dictionary<string, int> wordDict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordDict.ContainsKey(word))
                    wordDict[word]++;
                else
                    wordDict[word] = 1;
            }

            // Check for each possible offset
            for (int i = 0; i < wordLength; i++)
            {
                int left = i;
                int right = i;
                Dictionary<string, int> windowDict = new Dictionary<string, int>();
                int count = 0;

                while (right + wordLength <= s.Length)
                {
                    string word = s.Substring(right, wordLength);
                    right += wordLength;

                    if (wordDict.ContainsKey(word))
                    {
                        if (windowDict.ContainsKey(word))
                            windowDict[word]++;
                        else
                            windowDict[word] = 1;

                        count++;

                        // If the window contains more of 'word' than needed, shrink from the left
                        while (windowDict[word] > wordDict[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            windowDict[leftWord]--;
                            count--;
                            left += wordLength;
                        }

                        // If all words matched
                        if (count == wordCount)
                        {
                            result.Add(left);
                        }
                    }
                    else
                    {
                        // Reset the window
                        windowDict.Clear();
                        count = 0;
                        left = right;
                    }
                }
            }

            return result;
        }
    }
}