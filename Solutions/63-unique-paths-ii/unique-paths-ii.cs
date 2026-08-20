public class Solution
{
    const int Obstacle = 1;
    public int UniquePathsWithObstacles(int[][] grid)
    {
        if (grid[0][0] == Obstacle) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        var dp = new int[rows, cols];
        dp[0,0] = 1;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == Obstacle) continue;

                if (r > 0) dp[r,c] += dp[r-1, c];
                if (c > 0) dp[r,c] += dp[r, c-1];
            }
        }

        return dp[rows-1, cols-1];
    }
}