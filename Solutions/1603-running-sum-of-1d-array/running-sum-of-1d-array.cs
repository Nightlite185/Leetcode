public class Solution
{
    public int[] RunningSum(int[] nums)
    {
        if (nums.Length == 0) return [];

        int[] sums = new int[nums.Length];
        sums[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
            sums[i] = (nums[i] + sums[i-1]);

        return sums;
    }
}