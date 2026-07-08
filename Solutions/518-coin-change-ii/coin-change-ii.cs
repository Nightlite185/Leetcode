public class Solution
{
    public int Change(int amount, int[] coins)
    {
        var memo = new int?[amount, coins.Length];
        
        int dp(int sum, int i)
        {
            if (sum == amount) return 1;
            if (memo[sum, i] is int m) return m;

            int ways = 0;

            for (int j = i; j < coins.Length; j++)
            {
                int added = sum + coins[j];

                if (added <= amount)
                    ways += dp(added, j);
            }

            memo[sum, i] = ways;
            return ways;
        }

        return dp(0, 0);
    }
}