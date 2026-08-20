public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var dp = new int[rows, cols];
        dp[0,0] = grid[0][0];

        for (int r = 0; r < rows; r++)
        {
            int startCol = (r == 0) ? 1 : 0;

            for (int c = startCol; c < cols; c++)
            {
                int up   = (r > 0) ? dp[r-1, c] : int.MaxValue;
                int left = (c > 0) ? dp[r, c-1] : int.MaxValue;
                
                dp[r,c] = Math.Min(up, left) + grid[r][c];
            }
        }

        return dp[rows-1, cols-1];
    }
}
