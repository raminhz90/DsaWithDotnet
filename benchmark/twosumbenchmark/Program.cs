using BenchmarkDotNet.Running;

namespace twosumbenchmark;

public class Program
{
	public static void Main()
	{
		var summary = BenchmarkRunner.Run<Benchmark>();
	}
}
