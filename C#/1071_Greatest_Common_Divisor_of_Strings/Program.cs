namespace MyApp; 
using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet;
using System.Text;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;

[MemoryDiagnoser]
public class Solution
{
	public string GcdOfStrings(string str1, string str2)
	{
		int len1 = str1.Length;
		int len2 = str2.Length;
		int gcdLen = GCD(len1, len2);
		string candidate = str1.Substring(0, gcdLen);
		
		if (IsDivisor(str1, candidate) && IsDivisor(str2, candidate)) {
			return candidate;
		}
		
		return "";
	}

	[Benchmark]
	public string GcdOfStrings_attempt() 
	{
		string str1 = "ABABABABABABABABABABABABABABABABAB";
		string str2 = "ABABABAB";
        string auxStr = new(str1.Length < str2.Length ? str1 : str2);
		int strLen = auxStr.Length;
		var s = new StringBuilder();
		bool exactDivision;

		s.Append(auxStr);
		for (int i = 0; i < strLen; i++)
		{
			exactDivision = true;
			foreach(var str in str1.Split(s.ToString()))
			{
				if (str.Length != 0)
				{
					exactDivision = false;
					break;
				}
			}
			if (!exactDivision)
			{
				s.Remove(strLen - 1 - i, 1);
				continue ;
			}

			foreach(var str in str2.Split(s.ToString()))
			{
				if (str.Length != 0)
				{
					exactDivision = false;
					break;
				}
			}
			if (exactDivision)
			{
				return s.ToString();
			}
			s.Remove(strLen - 1 - i, 1);
		}
		return "";
    }

	[Benchmark]
	public string GcdOfStrings_recursive()
	{
		return GcdOfStrings_recursive("ABABABABABABABABABABABABABABABABAB", "ABABABAB");
	}

	public string GcdOfStrings_recursive(string str1, string str2)
	{
		if (str1.Length < str2.Length)
			return GcdOfStrings_recursive(str2, str1);
		else if (!str1.StartsWith(str2))
			return "";
		else if (str2.Length == 0)
			return str1;
		else
			return GcdOfStrings_recursive(str1.Substring(str2.Length), str2);
	}

	[Benchmark]
	public string GcdOfStrings_optimal() {
		string str1 = "ABABABABABABABABABABABABABABABABAB";
		string str2 = "ABABABAB";
		int len1 = str1.Length;
		int len2 = str2.Length;
		int gcdLen = GCD(len1, len2);
		string candidate = str1.Substring(0, gcdLen);
		
		if (IsDivisor(str1, candidate) && IsDivisor(str2, candidate)) {
			return candidate;
		}
		
		return "";
    }
    
	// Euclidean algorithm
    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    private bool IsDivisor(string str, string candidate) {
        int len = str.Length;
        int candidateLen = candidate.Length;
        
        if (len % candidateLen != 0) {
            return false;
        }
        
        for (int i = 0; i < len; i += candidateLen) {
            if (str.Substring(i, candidateLen) != candidate) {
                return false;
            }
        }
        
        return true;
    }
}

internal class Program
{
	static void Main(string[] args)
	{
		Solution sol = new();
		//Console.WriteLine(sol.GcdOfStrings("LEET", "CODE"));
		var summary = BenchmarkRunner.Run<Solution>();
	}
}
