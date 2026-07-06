public class Solution
{
    public int MaxJumps(int[] heights, int maxJump)
    {
        int n = heights.Length;
        var memo = new int?[n];

        int dp(int i)
        {
            if (memo[i] is int m) return m;

            int leftmost = Math.Max(i - maxJump, 0);
            int rightmost = Math.Min(i + maxJump, n-1);
            int currHeight = heights[i];
            int maxReach = 1;

            for (int j = i-1; j >= leftmost; j--)
            {
                if (heights[j] >= currHeight)
                    break;

                maxReach = Math.Max(maxReach, dp(j) + 1);
            }

            for (int j = i+1; j <= rightmost; j++)
            {
                if (heights[j] >= currHeight)
                    break;

                maxReach = Math.Max(maxReach, dp(j) + 1);
            }

            memo[i] = maxReach;
            return (int)memo[i]!;
        }

        int maxVisited = 1;

        for (int i = 0; i < n; i++)
        {
            maxVisited = Math.Max(
                maxVisited, dp(i));
        }

        return maxVisited;
    }
}