public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var memo = new int[nums.Length];

        int dp(int i)
        {
            if (memo[i] != 0) return memo[i];

            int ans = 1;
            int Ith = nums[i];

            for (int j = 0; j < i; j++)
                if (Ith > nums[j])
                    ans = Math.Max(ans, dp(j) + 1);

            memo[i] = ans;
            return ans;
        }

        int ans = 1;

        for (int i = 0; i < nums.Length; i++)
            ans = Math.Max(ans, dp(i));

        return ans;
    }
}