namespace MyApp; 
using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet;

internal class Program
{
	static void Main(string[] args)
	{
		Solution sol = new();
		var summary = BenchmarkRunner.Run<Solution>();
	}
}