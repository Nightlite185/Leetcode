public class Solution
{
    const int maxValue = 100;
    public int NumIdenticalPairs(int[] nums)
    {
        int n = nums.Length;
        int pairs = 0;

        Span<int> freqByNum = stackalloc int[maxValue + 1];

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];

            if (freqByNum[num] > 0)
                pairs += freqByNum[num];

            freqByNum[num]++;
        }

        return pairs;
    }
}