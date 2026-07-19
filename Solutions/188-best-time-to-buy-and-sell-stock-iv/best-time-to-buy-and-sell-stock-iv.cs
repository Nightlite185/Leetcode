public class Solution
{
    private static int ToInt(bool b) => b ? 1 : 0;
    public int MaxProfit(int limit, int[] prices)
    {
        int n = prices.Length;
        var memo = new int?[n, limit+1, 2]; // 2 bc true and false for holding state

        int dp(bool holding, int transRem, int i)
        {
            if (i == n || transRem <= 0) return 0;
            if (memo[i, transRem, ToInt(holding)] is int m) return m;

            int profit = 0;

            if (!holding)
            {
                profit = Math.Max(
                    dp(false, transRem, i+1),
                    -prices[i] + dp(true, transRem, i+1));
            }

            else
            {
                profit = Math.Max(
                    prices[i] + dp(false, transRem - 1, i + 1),
                    dp(true, transRem, i+1));
            }

            memo[i, transRem, ToInt(holding)] = profit;
            return profit;
        }

        return dp(false, limit, 0);
    }
}