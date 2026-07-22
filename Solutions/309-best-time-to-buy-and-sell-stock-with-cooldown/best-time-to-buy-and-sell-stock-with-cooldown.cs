public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        var memo = new int?[n, 2];

        int dp(int i, bool hold)
        {
            if (i >= n) return 0;
            if (memo[i, ToInt(hold)] is int m) return m;

            int res = 0;

            if (!hold)
            {
                // either buy now and go to next i OR skip and go to next
                res = Math.Max(
                    -prices[i] + dp(i+1, true),
                    dp(i+1, false));
            }

            else
            {
                res = Math.Max(
                    prices[i] + dp(i+2, false),
                    dp(i+1, true)
                );
            }

            memo[i, ToInt(hold)] = res;
            return res;
        }

        return dp(0, false);
    }

    private static int ToInt(bool b) => b ? 1 : 0;
}