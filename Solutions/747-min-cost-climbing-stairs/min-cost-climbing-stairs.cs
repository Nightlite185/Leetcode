public class Solution
{
    public int MinCostClimbingStairs(int[] costs)
    {
        var memo = new int?[costs.Length];

        int dp(int i)
        {
            if (i >= costs.Length) return 0;
            if (memo[i] is int memoized) return memoized;

            int cost = costs[i];

            int ans = Math.Min(cost + dp(i+1), cost + dp(i+2));
            memo[i] = ans;
            
            return ans;
        }

        return Math.Min(dp(0), dp(1));
    }
}