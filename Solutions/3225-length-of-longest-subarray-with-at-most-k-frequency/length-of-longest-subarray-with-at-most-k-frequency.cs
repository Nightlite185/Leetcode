using static System.Runtime.InteropServices.CollectionsMarshal;
public class Solution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        Dictionary<int, int> counts = [];
        int ans = 0, left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            ref int count = ref GetValueRefOrAddDefault(counts, nums[right], out _);
            count++;

            while (count > k)
                counts[nums[left++]]--;

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}