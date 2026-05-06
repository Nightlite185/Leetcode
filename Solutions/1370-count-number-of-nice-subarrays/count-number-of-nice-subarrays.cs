public class Solution
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        var counts = new Dictionary<int, int>()
            {[0] = 1};

        int oddCount = 0, result = 0;

        foreach (int num in nums)
        {
            oddCount += num % 2;

            result += counts.GetValueOrDefault(oddCount - k);
            counts[oddCount] = counts.GetValueOrDefault(oddCount) + 1;
        }

        return result;
    }
}