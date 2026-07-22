public class Solution
{
    public int MaxValueOfCoins(IList<IList<int>> piles, int takeLimit)
    {
        int n = piles.Count;
        var memo = new int?[n, takeLimit+1];

        int dp(int p, int rem)
        {
            if (p >= n || rem <= 0) return 0;
            if (memo[p, rem] is int m) return m;

            int best = dp(p+1, rem);
            int pileHeight = Math.Min(piles[p].Count, rem);
            int wallet = 0;
            
            for (int coin = 0; coin < pileHeight; coin++)
            {
                wallet += piles[p][coin];

                best = Math.Max(best,
                    wallet + dp(p+1, rem-coin-1));
            }
            
            memo[p, rem] = best;
            return best;
        }

        return dp(0, takeLimit);
    }
}