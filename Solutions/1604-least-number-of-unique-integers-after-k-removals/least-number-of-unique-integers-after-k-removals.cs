public class Solution
{
    public int FindLeastNumOfUniqueInts(int[] nums, int maxRemovals)
    {
        var numsByCount = nums
            .CountBy(x => x)
            .ToArray();

        numsByCount.Sort(Comparer<KeyValuePair<int, int>>
            .Create((x, y) => x.Value
            .CompareTo(y.Value)));

        int totalUniques = numsByCount.Length;
        int uniqueLeft = totalUniques;
        int removals = 0;

        for (int i = 0; i < totalUniques; i++)
        {
            var kvp = numsByCount[i];

            removals += kvp.Value;

            if (removals > maxRemovals)
                return uniqueLeft;

            uniqueLeft--;
        }

        return 0;
    }
}