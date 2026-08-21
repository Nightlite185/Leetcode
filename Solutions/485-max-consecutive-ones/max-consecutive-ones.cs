public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max = 0;
        int ones = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) ones++;
            else ones = 0;

            max = Math.Max(max, ones);
        }

        return max;
    }
}