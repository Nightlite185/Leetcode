public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount+1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int sum = 1; sum <= amount; sum++)
        {
            int min = int.MaxValue;

            foreach (int c in coins)
            {
                int i = sum - c;
                if (i < 0) continue;

                int prev = dp[i];
                min = Math.Min(min, prev);
            }

            if (min == int.MaxValue)
                continue;

            dp[sum] = min + 1;
        }

        return dp[amount] == int.MaxValue ? -1 : dp[amount];
    }
}
