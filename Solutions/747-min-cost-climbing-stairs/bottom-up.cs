public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int n = cost.Length;
        var dp = new int[n+2];

        for (int i = n-1; i >= 0; i--)
        {
            dp[i] = cost[i] + Math.Min(dp[i+1], dp[i+2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}
