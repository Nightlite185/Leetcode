public class Solution {
    public int RemoveElement(int[] nums, int val) 
    {
        int writeIdx = 0;
        int k = 0;

        for(int readIdx = 0; readIdx < nums.Length; readIdx++)
        {
            if (nums[readIdx] != val)
            {
                nums[writeIdx] = nums[readIdx];
                writeIdx++;
            }
        }

        return writeIdx;
    }
}
