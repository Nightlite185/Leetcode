public class Solution
{
    public IList<int> FindClosestElements(int[] nums, int k, int target)
    {
        int[] ans = new int[k];
        int left = 0, right = nums.Length - 1;
        
        while (left < right)
        {
            if (right - left + 1 == k)
                break;

            int leftDiff = Math.Abs(nums[left] - target),
                rightDiff = Math.Abs(nums[right] - target);

            if (leftDiff <= rightDiff)
                right--;

            else left++;
        }

        for (int i = 0; i < k; i++)
            ans[i] = nums[left++];

        return ans;
    }
}