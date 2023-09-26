namespace LeetCode1768;
using System;
using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class MergeAlternatelySolution 
{
	static public string MergeAlternately(string word1, string word2) 
	{
		var s = new StringBuilder();
		int len1 = word1.Length;
		int len2 = word2.Length;
		int max = Math.Max(len1, len2);
        for (int i = 0; i < max ; i++)
		{
			if (i < len1)
				s.Append(word1[i]);
			if (i < len2)
				s.Append(word2[i]);
		}
		return s.ToString();
    }

	[Benchmark]
    public string MergeAlternately_Worse() 
	{
		string word1 = "Holacomo estasn";
		string word2 = "estoes un segundo string que voy a hacer un poquito mas largo que antes";
		string s = "";
		int maxLength = word1.Length > word2.Length ? word1.Length : word2.Length;

        for (int i = 0; i < maxLength ; i++)
		{
			if (i < word1.Length)
				s += word1[i];
			if (i < word2.Length)
				s += word2[i];
		}

		return s;
    }

	[Benchmark]
	public string MergeAlternately_DoubleLoopComparison_NoMax_NoLen() 
	{
		string word1 = "Holacomo estasn";
		string word2 = "estoes un segundo string que voy a hacer un poquito mas largo que antes";
		var s = new StringBuilder();

        for (int i = 0; i < word1.Length || i <  word2.Length ; i++)
		{
			if (i < word1.Length)
				s.Append(word1[i]);
			if (i <  word2.Length)
				s.Append(word2[i]);
		}

		return s.ToString();
    }

	/// <summary>
	/// This one has waaay better memory usage, looks like it happens because of StringBuilder()
	/// also access to word1.Length is not that fast, way better to store it in an int
	/// Math.Max also looks like reaaaly fast
	/// </summary>
	/// <param name="word1"></param>
	/// <param name="word2"></param>
	/// <returns></returns>
	[Benchmark]
	public string MergeAlternately_DoubleLoopComparison_NoMax() 
	{
		string word1 = "Holacomo estasn";
		string word2 = "estoes un segundo string que voy a hacer un poquito mas largo que antes";
		var s = new StringBuilder();
		int len1 = word1.Length;
		int len2 = word2.Length;

        for (int i = 0; i < len1 || i < len2 ; i++)
		{
			if (i < len1)
				s.Append(word1[i]);
			if (i < len2)
				s.Append(word2[i]);
		}

		return s.ToString();
    }

	[Benchmark]
	public string MergeAlternately_OneComparison_NoMathMax() 
	{
		string word1 = "Holacomo estasn";
		string word2 = "estoes un segundo string que voy a hacer un poquito mas largo que antes";
		var s = new StringBuilder();
		int len1 = word1.Length;
		int len2 = word2.Length;
		int max = len1 > len2 ? len1 : len2;

        for (int i = 0; i < max ; i++)
		{
			if (i < len1)
				s.Append(word1[i]);
			if (i < len2)
				s.Append(word2[i]);
		}

		return s.ToString();
    }

	[Benchmark]
	public string MergeAlternately_OneComparison_MathMax() 
	{
		string word1 = "Holacomo estasn";
		string word2 = "estoes un segundo string que voy a hacer un poquito mas largo que antes";
		var s = new StringBuilder();
		int len1 = word1.Length;
		int len2 = word2.Length;
		int max = Math.Max(len1, len2);

        for (int i = 0; i < max ; i++)
		{
			if (i < len1)
				s.Append(word1[i]);
			if (i < len2)
				s.Append(word2[i]);
		}

		return s.ToString();
    }
}