public class Solution
{
    public int MissingNumber(int[] nums)
    {
        nums.Sort();

        for (int i = 0; i < nums.Length; i++)
            if (nums[i] != i) return i;

        return nums.Length;
    }
}