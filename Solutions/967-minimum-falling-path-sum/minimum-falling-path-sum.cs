public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        int rows = matrix.Length,
        cols = matrix[0].Length;
        int lastRow = rows - 1;
        var memo = new int?[rows, cols];

        int dp(int r, int c)
        {
            if (r == lastRow)
            {
                int x = matrix[r][c];

                memo[r, c] = x;
                return x;
            }

            if (memo[r, c] is int m) return m;
            int cost = matrix[r][c];
            int ans = cost + dp(r + 1, c);

            if (c != cols - 1)
                ans = Math.Min(ans, cost + dp(r + 1, c + 1));

            if (c > 0)
                ans = Math.Min(ans, cost + dp(r + 1, c - 1));

            memo[r, c] = ans;
            return ans;
        }

        int ans = int.MaxValue;

        for (int c = 0; c < cols; c++)
            ans = Math.Min(ans, dp(0, c));

        return ans;
    }
}