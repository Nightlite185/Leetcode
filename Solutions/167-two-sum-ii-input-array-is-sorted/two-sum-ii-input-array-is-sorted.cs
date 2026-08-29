public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int l = 0, r = nums.Length-1;

        while (l < r)
        {
            int sum = nums[l] + nums[r];
            
            if (sum > target)
                r--;

            else if (sum < target)
                l++;

            else if (sum == target)
                return [l+1, r+1];
        }

        return [];
    }
}