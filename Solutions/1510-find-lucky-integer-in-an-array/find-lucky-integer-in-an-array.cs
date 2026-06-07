public class Solution
{
    const int maxValue = 500;
    public int FindLucky(int[] nums)
    {
        Span<int> counts = stackalloc int[maxValue + 1];
        
        foreach(int num in nums)
            counts[num]++;

        for (int i = maxValue; i >= 1; i--)
            if (i == counts[i]) return i;

        return -1;
    }
}