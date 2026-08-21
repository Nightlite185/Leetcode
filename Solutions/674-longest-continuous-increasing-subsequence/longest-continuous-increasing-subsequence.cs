public class Solution
{
    public int FindLengthOfLCIS(int[] nums)
    {
        if (nums.Length == 1) return 1;
        int l = 0;
        int longest = 0;

        for (int r = 1; r < nums.Length; r++)
        {
            if (nums[r] <= nums[r-1])
                l = r;

            longest = Math.Max(longest, r-l + 1);
        }

        return longest;
    }
}