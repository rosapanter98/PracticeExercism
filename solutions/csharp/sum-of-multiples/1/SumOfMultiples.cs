public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return multiples
            .Where(m => m > 0)
            .SelectMany(m => Enumerable.Range(1, (max - 1)/ m).Select(i => i * m))
            .Distinct()
            .Sum();
    }
}