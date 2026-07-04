public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] memo = new int[n+1];
        
        int dp(int i)
        {
            if (i > n) return 0;
            if (i == n) return 1;

            if (memo[i] != 0) return memo[i];

            memo[i] = dp(i+1) + dp(i+2);
            return memo[i];
        }

        return dp(0);
    }
}