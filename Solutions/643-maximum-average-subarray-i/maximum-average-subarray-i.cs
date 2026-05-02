public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        double currSum = nums.Take(k).Sum();
        double highest = currSum / k;

        for (int i = k; i < nums.Length; i++)
        {
            currSum += nums[i] - nums[i-k];
            highest = Math.Max(highest, currSum / k);
        }

        return highest;
    }
}