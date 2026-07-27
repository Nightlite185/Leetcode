public class Solution
{
    public string StoneGameIII(int[] stones)
    {
        int n = stones.Length;
        var memo = new int?[n];

        int dp(int i)
        {
            if (i >= n) return 0;
            if (memo[i] is int m) return m;

            int best = int.MinValue;
            int take = 0;
            int bound = Math.Min(i+2, n-1);

            for (int j = i; j <= bound; j++)
            {
                take += stones[j];
                best = Math.Max(best, take - dp(j+1));
            }

            memo[i] = best;
            return best;
        }

        return dp(0) switch
        {
            > 0 => "Alice",
            < 0 => "Bob",

            _ => "Tie"
        };
    }
}