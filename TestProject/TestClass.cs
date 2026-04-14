using System;
using AnalyzerProject;
using GeneratedNamespace;

namespace TestProject;

[GenerateSimple]
public class TestClass
{
	public void Check()
	{
		Console.WriteLine(GeneratedSimple.TestProperty);
	}
}