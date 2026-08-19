using static System.Math;
public class Solution
{
    public int MaxProfit(int limit, int[] prices)
    {
        int n = prices.Length;
        var dp = new int[n+1, limit+1, 2];

        for (int i = n - 1; i >= 0; i--)
        for (int rem = 1; rem <= limit; rem++)
        for (int holding = 0; holding <= 1; holding++)
        {
            int profit = dp[i+1, rem, holding];
            
            if (holding == 1)
            {
                profit = Max(profit, 
                    dp[i+1, rem-1, 0] + prices[i]);
            }

            else profit = Max(profit,
                dp[i+1, rem, 1] - prices[i]);

            dp[i, rem, holding] = profit;
        }

        return dp[0, limit, 0];
    }
}
