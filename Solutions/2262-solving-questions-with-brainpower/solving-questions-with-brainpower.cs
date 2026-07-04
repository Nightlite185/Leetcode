public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        var memo = new long[n];

        long dp(int i)
        {
            if (i >= n) return 0;
            if (memo[i] != 0) return memo[i];

            var q = questions[i];
            int points = q[0], skipCount = q[1] + 1;

            long ans = Math.Max(
                points + dp(i + skipCount), // if we attempt the q
                dp(i+1)); // if we skip the q

            memo[i] = ans;
            return ans;
        }

        return dp(0);
    }
}