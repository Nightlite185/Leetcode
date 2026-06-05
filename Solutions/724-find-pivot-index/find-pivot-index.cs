public class Solution
{
    public int PivotIndex(int[] nums)
    {
        var sums = new int[nums.Length];
        int curr = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            sums[i] = curr;
        }

        for (int i = 0; i < sums.Length; i++)
        {
            int left = sums.ElementAtOrDefault(i-1);
            int right = sums[^1] - sums[i];

            if (left == right) return i;
        }

        return -1;
    }
}