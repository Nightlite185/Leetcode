public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int[] result = new int[nums.Length];

        int left = 0;
        int right = nums.Length -1;

        int i = nums.Length-1;
        
        while (left <= right)
        {
            int abs1 = Math.Abs(nums[left]);
            int abs2 = Math.Abs(nums[right]);
            
            if (abs1 > abs2)
            {
                result[i] = abs1 * abs1;
                left++;
            }
            
            else
            {
                result[i] = abs2 * abs2;
                right--;
            }
                
            i--;
        }

        return result;
    }
}