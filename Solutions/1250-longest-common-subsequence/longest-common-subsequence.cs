public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var memo = new int?[text1.Length, text2.Length];

        int dp(int p1, int p2)
        {
            if (p1 == text1.Length || p2 == text2.Length)
                return 0;

            if (memo[p1,p2] is int m) return m;

            int res = (text1[p1] == text2[p2]) 
                ? dp(p1+1, p2+1) + 1
                
                : Math.Max(
                    dp(p1+1, p2),
                    dp(p1, p2+1));

            memo[p1,p2] = res;

            return res;
        }

        return dp(0,0);
    }
}