public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int ans = nums[0];

        // XOR returns 0 for any 2 equal numbers, so they all cancel out
        // except for the single one, which remains untouched

        for (int i = 1; i < nums.Length; i++)
            ans ^= nums[i];

        return ans;
    }
}