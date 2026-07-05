public class Solution
{
    public int CoinChange(int[] coins, int target)
    {
        var memo = new int[target+1];

        int dp(int remain)
        {
            if (remain < 0) return -1;
            if (remain == 0) return 0;

            if (memo[remain] > 0) return memo[remain];

            int min = int.MaxValue;

            foreach(int c in coins)
            {
                int res = dp(remain-c);

                if (res >= 0 && res < min)
                    min = res + 1;
            }

            memo[remain] = min;
            return memo[remain];
        }

        var res = dp(target);
        
        return (res == int.MaxValue )
            ? -1 : res;
    }
}