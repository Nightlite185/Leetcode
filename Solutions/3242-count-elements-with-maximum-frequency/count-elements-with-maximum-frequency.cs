public class Solution
{
    const int maxValue = 100;
    public int MaxFrequencyElements(int[] nums)
    {
        int maxFreq = 0, maxFreqCount = 0;
        Span<int> counts = stackalloc int[maxValue + 1];

        foreach(int num in nums)
            maxFreq = Math.Max(maxFreq, ++counts[num]);

        for (int i = 1; i <= maxValue; i++)
        {
            if (counts[i] == maxFreq)
                maxFreqCount++;
        }

        return maxFreqCount * maxFreq;
    }
}