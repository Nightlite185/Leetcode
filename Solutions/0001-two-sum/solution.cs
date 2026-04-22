public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seen = [];

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.TryGetValue(complement, out int val))
                return [i, val];

            seen[nums[i]] = i;
        }

        return [];
    }
}
