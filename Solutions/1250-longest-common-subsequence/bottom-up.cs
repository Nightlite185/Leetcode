public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n = text1.Length;
        int m = text2.Length;
        var dp = new int[n+1, m+1];
        
        for (int i = n-1; i >= 0; i--)
        for (int j = m-1; j >= 0; j--)
        {
            dp[i,j] = (text1[i] == text2[j])
                ? dp[i+1, j+1] + 1
                : Math.Max(dp[i+1, j], dp[i, j+1]);
        }

        return dp[0,0];
    }
}
