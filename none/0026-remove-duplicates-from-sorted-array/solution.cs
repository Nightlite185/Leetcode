public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
        int lastUniqueIdx = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[lastUniqueIdx])
                nums[++lastUniqueIdx] = nums[i];
        }

        return ++lastUniqueIdx;
    }
}
