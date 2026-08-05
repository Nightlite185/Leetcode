public class Solution
{
    public int Rob(int[] houses)
    {
        int n = houses.Length;
        if (n == 1) return houses[0];

        var dp = new int[n];
        dp[0] = houses[0];
        dp[1] = Math.Max(houses[0], houses[1]);
        
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(
                dp[i-1],
                houses[i] + dp[i-2]);
        }

        return dp[n-1];
    }
}
