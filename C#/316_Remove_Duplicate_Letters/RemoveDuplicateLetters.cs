namespace LeetCode316; 
using System;
using System.Collections.Generic;
using System.Linq;


public class RemoveDuplicateLettersSolution 
{
    static public string RemoveDuplicateLetters_Fail(string s) 
	{
		string sorted = string.Concat(s.OrderByDescending(c => c));
		int firstIndex, lastIndex;

		foreach(var letter in sorted)
		{
			firstIndex = s.IndexOf(letter);
			lastIndex = s.LastIndexOf(letter);
			if (firstIndex != lastIndex)
			{
				if (string.CompareOrdinal(s, s.Remove(firstIndex, 1)) < 0 )
					s = s.Remove(lastIndex, 1);
				else
					s = s.Remove(firstIndex, 1);
			}
		}

        return s;
    }

	static public string RemoveDuplicateLetters(string s) {
        Stack<char> stack = new Stack<char>();
        HashSet<char> seen = new HashSet<char>();
        Dictionary<char, int> lastOcc = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            lastOcc[s[i]] = i;
        }
        
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (!seen.Contains(c)) {
                while (stack.Count > 0 && c < stack.Peek() && i < lastOcc[stack.Peek()]) {
                    seen.Remove(stack.Pop());
                }
                seen.Add(c);
                stack.Push(c);
            }
        }
        
        char[] result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }

}