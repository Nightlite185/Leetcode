public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;

        var memo = new int?[n,2];
        
        int dp(int i, bool holding)
        {
            if (i == n) return 0;
            
            if (memo[i, Convert.ToInt32(holding)] is int m)
                return m;

            int ans;

            if (holding) ans = Math.Max(
                prices[i] + dp(i+1, false),
                dp(i+1, true));

            else ans = Math.Max(
                dp(i+1, true) - prices[i],
                dp(i+1, false));

            memo[i, Convert.ToInt32(holding)] = ans;
            return ans;
        }

        return dp(0, false);
    }
}