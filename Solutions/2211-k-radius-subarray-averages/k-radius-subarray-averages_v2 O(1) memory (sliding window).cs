public class Solution
{
    public int[] GetAverages(int[] nums, int k)
    {
        if (k == 0) return nums;
        
        int[] avgs = new int[nums.Length];
        Array.Fill(avgs, -1);

        if (nums.Length < 2*k+1)
            return avgs;

        int winSize = 2 * k + 1;
        int rightBound = nums.Length - k;
        long sum = 0;

        for (int i = 0; i < winSize; i++)
            sum += nums[i];

        avgs[k] = (int)(sum / winSize);

        for (int i = k+1; i < rightBound; i++)
        {
            sum += nums[i+k] - nums[i-k-1];
            avgs[i] = (int)(sum / winSize);
        }

        return avgs;
    }
}