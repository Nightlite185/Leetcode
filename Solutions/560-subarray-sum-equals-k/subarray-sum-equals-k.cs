public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> sumCounts = new()
            {[0] = 1};

        int curr = 0, result = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            
            result += sumCounts.GetValueOrDefault(curr - k);
            sumCounts[curr] = sumCounts.GetValueOrDefault(curr) + 1;
        }

        return result;
    }
}