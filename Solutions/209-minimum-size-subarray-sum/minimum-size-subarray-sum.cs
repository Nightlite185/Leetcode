public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int sum = 0, left = 0, ans = int.MaxValue;

        for (int right = 0; right < nums.Length; right++)
        {
            int num = nums[right];
            sum += num;

            while (sum >= target)
            {
                ans = Math.Min(ans, right - left + 1);
                sum -= nums[left++];
            }

        }

        return ans == int.MaxValue ? 0 : ans;
    }
}