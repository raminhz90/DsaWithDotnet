using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DsaDotNet.TwoSum;

namespace twosumbenchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class Benchmark
{

	private static readonly int[] InputArray = Enumerable.Range(0, 100000).ToArray();
	private readonly int target = InputArray[^1] + InputArray[^2];

	[Benchmark(Baseline = true)]
	public ValueTask<TwoSumResult> TwoSumDictionaryReturnsRecordAsync()
		=> TwoSum.TwoSumWithDictionaryAsync(InputArray, this.target);
	[Benchmark]
	public TwoSumResult TwoSumDictionaryReturnsRecord()
	=> TwoSum.TwoSumWithDictionary(InputArray, this.target);
	[Benchmark]
	public ValueTask<IReadOnlyCollection<int>> TwoSumDictionaryReturnsArrayAsync()
		=> TwoSum.TwoSumWithDictionaryReturningArrayAsync(InputArray, this.target);
	[Benchmark]
	public void TwoSumDictionaryReturnsArray()
		=> TwoSum.TwoSumWithDictionaryReturningArray(InputArray, this.target);
}
