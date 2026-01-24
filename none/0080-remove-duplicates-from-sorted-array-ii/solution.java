class Solution {
    public int removeDuplicates(int[] nums) 
    {
        int writeIdx = 0;
        boolean seenTwice = false;

        for (int i = 1; i < nums.length; i++)
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
