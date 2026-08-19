public class Solution
{    
    public int MaxValueOfCoins(IList<IList<int>> piles, int takeLimit)
    {
        int n = piles.Count;
        var dp = new int[n+2, takeLimit+2];

        for (int i = n-1; i >= 0; i--)
        {
            var pile = piles[i];

            for (int rem = 1; rem <= takeLimit; rem++)
            {
                int pileHeight = Math.Min(pile.Count-1, rem);
                int best = dp[i+1, rem];
                int wallet = 0;

                for (int coin = 0; coin <= pileHeight; coin++)
                {
                    wallet += pile[coin];

                    int coinsLeft = rem - coin - 1;

                    if (coinsLeft < 0) break;

                    best = Math.Max(best,
                        wallet + dp[i+1, coinsLeft]);
                }

                dp[i, rem] = best;
            }
        }

        return dp[0, takeLimit];
    }
}
