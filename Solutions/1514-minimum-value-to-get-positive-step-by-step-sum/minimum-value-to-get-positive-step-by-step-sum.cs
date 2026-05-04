public class Solution
{
    public int MinStartValue(int[] nums)
    {
        int sum = nums[0];
        int lowest = sum;

        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];
            lowest = Math.Min(lowest, sum);
        }

        if (int.IsNegative(lowest)) 
            return -lowest + 1;

        return 1;
    }
}