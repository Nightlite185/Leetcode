public class Solution
{
    public int Rob(int[] nums)
    {
        var memo = new int?[nums.Length];

        int dp(int i)
        {
            if (i == 0) return nums[0];

            if (i == 1) return Math.Max(
                nums[0], nums[1]);

            if (memo[i] is int ans) return ans;

            memo[i] = Math.Max(dp(i-1), dp(i-2) + nums[i]);
            return (int)memo[i]!;
        }

        return dp(nums.Length - 1);
    }
}