public class Solution
{
    public int MinSetSize(int[] nums)
    {
        var counted = nums
            .CountBy(x => x)
            .ToArray();

        counted.Sort(Comparer<KeyValuePair<int, int>>
            .Create((a, b) => b.Value
                .CompareTo(a.Value)));

        int curr = nums.Length;
        int half = curr / 2;

        for (int i = 0; i < counted.Length; i++)
        {
            curr -= counted[i].Value;

            if (curr <= half)
                return i + 1;
        }

        return -1;
    }
}