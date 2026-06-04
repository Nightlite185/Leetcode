public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int writeIdx = -1;
        
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (num != 0) nums[++writeIdx] = num;
        }

        for (int i = nums.Length - 1; i > writeIdx; i--)
            nums[i] = 0;
    }
}