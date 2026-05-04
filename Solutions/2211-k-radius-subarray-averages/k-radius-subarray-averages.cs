public class Solution
{
    public int[] GetAverages(int[] nums, int k)
    {
        int[] avgs = new int[nums.Length];
        long[] sums = BuildSums(nums);
        int subArrElements = k * 2 + 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i < k || (nums.Length - i) <= k)
            {
                avgs[i] = -1;
                continue;
            }

            int left = i-k;

            long toSubtract = (left > 0)
                ? sums[left - 1] : 0;

            avgs[i] = (int) ((sums[i+k] - toSubtract) / subArrElements);
        }

        return avgs;
    }

    private static long[] BuildSums(int[] nums)
    {
        long[] sums = new long[nums.Length];
        sums[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
            sums[i] = sums[i-1] + nums[i];

        return sums;
    }
}