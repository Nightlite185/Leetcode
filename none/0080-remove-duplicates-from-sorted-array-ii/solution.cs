public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
    {
        int writeIdx = 0;
        bool seenTwice = false;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[writeIdx] && !seenTwice)
            {
                nums[++writeIdx] = nums[i];
                seenTwice = true;
            }

            else if (nums[i] != nums[writeIdx])
            {
                nums[++writeIdx] = nums[i];
                seenTwice = false;
            }
        }

        return ++writeIdx;
    }
}
