public class Solution
{
    public int LongestSubsequence(int[] nums, int diff)
    {
        var seenDiff = new Dictionary<int, int>(nums.Length);
        int longest = 1;
        
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            if (seenDiff.TryGetValue(num - diff, out int val))
                seenDiff[num] = val + 1;

            else seenDiff[num] = 1;

            longest = Math.Max(longest, seenDiff[num]);
        }

        return longest;
    }
}