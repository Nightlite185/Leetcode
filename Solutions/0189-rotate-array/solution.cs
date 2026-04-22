public class Solution 
{
    public void Rotate(int[] nums, int k) 
    {
        k %= nums.Length; // handle k > length
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    private void Reverse(int[] nums, int left, int right) 
    {
        while (left < right) 
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++; right--;
        }
    }
}
