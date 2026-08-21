public class Solution
{
    public int MinFallingPathSum(int[][] grid)
    {
        int n = grid.Length;
        if (n == 1) return grid[0][0];
        int lastIdx = n-1;
        int minLastRow = int.MaxValue;
        
        var dp        = new int[n];
        var lastRowDp = new int[n];

        for (int c = 0; c < n; c++)
            lastRowDp[c] = grid[0][c];

        for (int r = 1; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int upleft = (c == 0)
                    ? int.MaxValue
                    : lastRowDp[c-1];

                int up = lastRowDp[c];

                int upRight = (c == lastIdx)
                    ? int.MaxValue
                    : lastRowDp[c+1];

                int min = Math.Min(upleft, up);
                min     = Math.Min(min, upRight);

                dp[c] = min + grid[r][c];

                if (r == lastIdx)
                    minLastRow = Math.Min(minLastRow, dp[c]);
            }

            (dp, lastRowDp) = (lastRowDp, dp);
        }

        return minLastRow;
    }
}
