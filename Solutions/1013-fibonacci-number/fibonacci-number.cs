public class Solution
{
    public int Fib(int n)
    {
        var memo = new int[n + 1];

        int dp(int num)
        {
            if (num == 0) return 0;
            if (num == 1) return 1;

            if (memo[num] != 0) return memo[num];

            memo[num] = dp(num - 1) + dp(num - 2);
            return memo[num];
        }

        return dp(n);
    }
}