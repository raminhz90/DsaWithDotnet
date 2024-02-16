namespace DsaDotNet.TwoSum;
public static class TwoSum
{
	public static ValueTask<TwoSumResult>  TwoSumWithDictionaryAsync(int[] input, int target)
		=> new(TwoSumWithDictionary(input, target));
	public static TwoSumResult TwoSumWithDictionary(int[] input, int target)
	{
		var dict = new Dictionary<int, int>(input.Length);

		for (var i = 0; i < input.Length; i++)
		{
			var complement = target - input[i];
			if (dict.TryGetValue(complement, out var value))
			{
				return new TwoSumResult(value, i);
			}
			dict.Add(input[i], i);
		}

		return new TwoSumResult(-1, -1);
	}
	public static ValueTask<IReadOnlyCollection<int>> TwoSumWithDictionaryReturningArrayAsync(int[] input, int target)
		=> ValueTask.FromResult<IReadOnlyCollection<int>>(TwoSumWithDictionaryReturningArray(input, target));
	public static int[] TwoSumWithDictionaryReturningArray(int[] input, int target)
	{
		var dict = new Dictionary<int, int>(input.Length);

		for (var i = 0; i < input.Length; i++)
		{
			var complement = target - input[i];
			if (dict.TryGetValue(complement, out var value))
			{
				return [value,i];
			}
			dict.Add(input[i], i);
		}

		return [-1,-1];
	}


}
public record TwoSumResult(int Index1, int Index2);
