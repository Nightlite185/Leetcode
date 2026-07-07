public class Solution
{
    public int Tribonacci(int n)
    {
        if (n == 0) return 0;
        if (n is 1 or 2) return 1;
        
        var memo = new int[n+1];
        memo[1] = 1; memo[2] = 1;
        
        for (int i = 3; i <= n; i++)
        {
            memo[i] = memo[i-1] + memo[i-2] + memo[i-3];
        }

        return memo[n];
    }
}