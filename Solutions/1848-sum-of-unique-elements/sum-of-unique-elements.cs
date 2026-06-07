public class Solution
{
    const int MaxNumValue = 100;
    public int SumOfUnique(int[] nums)
    {
        Span<int> count = stackalloc int[MaxNumValue + 1];
        int sum = 0;

        foreach(int num in nums)
            count[num]++;

        for (int num = 1; num < count.Length; num++)
            if (count[num] == 1) sum += num;

        return sum;
    }
}