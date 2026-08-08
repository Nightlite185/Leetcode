public class Solution
{
    public int ClimbStairs(int n)
    {
        var dp = new int[n + 3];
        dp[n] = 1;

        for (int i = n-1; i >= 0; i--)
        {
            dp[i] = dp[i+1] + dp[i+2];
        }

        return dp[0];
    }
}
