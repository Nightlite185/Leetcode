public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        var memo = new int?[rows, cols];
        int colBound = cols-1, rowBound = rows-1;
        memo[rowBound, colBound] = grid[rowBound][colBound];
        
        int dp(int r, int c)
        {
            if (r >= rows || c >= cols) return 0;
            if (memo[r,c] is int m)     return m;

            int cost = grid[r][c];
            int ans = int.MaxValue;

            if (r + 1 < rows)
                ans = Math.Min(ans, dp(r+1, c));

            if (c + 1 < cols)
                ans = Math.Min(ans, dp(r, c+1));

            ans += cost;
            memo[r,c] = ans;
            return ans;
        }

        return dp(0, 0);
    }
}