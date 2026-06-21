public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var set = nums.ToHashSet();
        int max = 0;

        foreach(int n in set)
        {
            int seqLength = 0;
            int num = n;

            if (set.Contains(num - 1))
                continue;

            while (set.Contains(num))
            {
                seqLength++; num++;
            }

            max = Math.Max(max, seqLength);
        }

        return max;
    }
}