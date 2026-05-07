public class Solution
{
    public int LargestUniqueNumber(int[] nums)
    {
        Dictionary<int, int> counts = [];
        int highest = -1;

        foreach(int num in nums)
            counts[num] = counts.GetValueOrDefault(num) + 1;

        foreach(var kvp in counts)
        {
            if (kvp.Value == 1) 
                highest = Math.Max(highest, kvp.Key);
        }

        return highest;
    }
}