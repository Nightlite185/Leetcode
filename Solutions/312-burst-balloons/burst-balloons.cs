public class Solution
{
    public int MaxCoins(int[] nums)
    {
        int n = nums.Length;
        var memo = new int?[n+1, n+1];
        var temp = new int[n + 2];
        
        Array.Copy(nums, 0, temp, 1, n);
        nums = temp;
        nums[0] = 1;
        nums[^1] = 1;
        
        int dp(int l, int r)
        {
            if (l > r) return 0;
            if (memo[l, r] is int m) return m;
            
            for (int i = l; i <= r; i++)
            {
                int coins = nums[l-1] * nums[i] * nums[r+1];
                coins += dp(l, i-1) + dp(i+1, r);
                memo[l,r] = Math.Max(memo[l,r] ?? 0, coins);
            }

            return (int)memo[l,r]!;
        }

        return dp(1, nums.Length - 2);
    }
}