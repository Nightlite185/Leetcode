public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        int ans = 1;
        var dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                    ans = Math.Max(ans, dp[i]);
                }
            }
        }

        return ans;
    }
}
