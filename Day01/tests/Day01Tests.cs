using System;
using System.Linq;
using Xunit;

namespace tests;

public class Day01Tests
{
    [Fact]
    public void SingleNumIncreases_WithSampleInput_ShouldReturn7()
    {
        string[] data = "199 200 208 210 200 207 240 269 260 263".Split(' ', StringSplitOptions.TrimEntries);
        int[] input = Array.ConvertAll(data, s => int.Parse(s));
        int numIncreases = Enumerable.Range(1, input.Length-1).Where( index => input[index] > input[index-1] ).Count();

        Assert.Equal(7, numIncreases);
    }

    [Fact]
    public void TripleNumIncreases_WithSampleInput_ShouldReturn5()
    {
        string[] data = "199 200 208 210 200 207 240 269 260 263".Split(' ', StringSplitOptions.TrimEntries);
        int[] input = Array.ConvertAll(data, s => int.Parse(s));
        int[] triples = Enumerable.Range(0, input.Length-2).Select(x => input[x] + input[x+1] + input[x+2]).ToArray();
        int numIncreases = Enumerable.Range(1, triples.Length-1).Where( index => triples[index] > triples[index-1] ).Count();

        Assert.Equal(5, numIncreases);
    }
}