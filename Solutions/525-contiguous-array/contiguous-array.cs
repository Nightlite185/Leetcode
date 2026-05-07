public class Solution
{
    public int FindMaxLength(int[] nums)
    {
        int curr = 0, longest = 0;
        Dictionary<int, int> seenFirst = new()
            { [0] = -1 };

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            curr += (num == 1)
                ? 1 : -1;

            if (seenFirst.TryGetValue(curr, out int val))
                longest = Math.Max(longest, i - val);

            else seenFirst[curr] = i;
        }

        return longest;
    }
}