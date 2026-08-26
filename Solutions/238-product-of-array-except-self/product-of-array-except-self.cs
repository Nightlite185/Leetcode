public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        var ans = new int[n];
        ans[0] = 1;

        for (int i = 1; i < n; i++)
        {
            ans[i] = ans[i-1] * nums[i-1];
        }

        int agr = 1;

        for (int i = n-2; i >= 0; i--)
        {
            agr *= nums[i+1];
            ans[i] *= agr;
        }

        return ans;
    }
}