// This version is faster than the "lazy" LINQ 1-liner, due to its overhead.
// But in terms of memory its rly similar.

public class Solution
{
    public IList<int> Intersection(int[][] nums)
    {
        var counts = new Dictionary<int, int>();
        List<int> result = [];

        foreach (int[] arr in nums)
            foreach (int num in arr)
            {
                counts.TryGetValue(num, out int val);
                counts[num] = ++val;
            }

        foreach (var kvp in counts)
        {
            if (kvp.Value == nums.Length)
                result.Add(kvp.Key);
        }

        result.Sort();
        return result;
    }
}