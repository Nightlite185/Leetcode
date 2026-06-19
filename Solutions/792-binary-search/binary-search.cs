public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length-1;

        while (left <= right)
        {
            int mid = left + (right-left) / 2;
            int num = nums[mid];

            if (num == target)
                return mid;

            else if (num < target)
                left = mid + 1;

            else right = mid - 1;
        }

        return -1;
    }
}