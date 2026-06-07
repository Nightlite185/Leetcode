public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        int maxVal = (int)Math.Pow(10, 9);
        HashSet<int> seen = [];

        for (int i = 0; i < nums.Length; i++)
            if (!seen.Add(nums[i])) return true;

        return false;
    }
}