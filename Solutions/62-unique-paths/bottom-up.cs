public class Solution
{
    public int UniquePaths(int rows, int cols)
    {
        var dp = new int[rows, cols];
        dp[0,0] = 1;

        for (int r = 0; r < rows; r++)
        {
            int startCol = (r == 0)
                ? 1 : 0;

            for (int c = startCol; c < cols; c++)
            {
                int ans = 0;

                if (r > 0) ans += dp[r-1, c];
                if (c > 0) ans += dp[r, c-1];

                dp[r,c] = ans;
            }
        }

        return dp[rows-1, cols-1];
    }
}
