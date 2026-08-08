public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        var dp = new long[n];

        for (int i = n - 1; i >= 0; i--)
        {
            var q = questions[i];
            int pts = q[0], nextIdxIfSkip = i + q[1] + 1;
            int nextIdx = i + 1;

            long take = pts + (nextIdxIfSkip >= n 
                ? 0 
                : dp[nextIdxIfSkip]);
            
            long skip = (nextIdx >= n)
                ? 0 
                : dp[nextIdx];

            dp[i] = Math.Max(take, skip);
        }

        return dp[0];
    }
}
