public class Solution
{
    public IList<int> Intersection(int[][] nums)
    {
        return [..nums.SelectMany(c => c)
            .CountBy(c => c)
            .Where(c => c.Value == nums.Length)
            .Select(c => c.Key)
            .Order()];
    }
}