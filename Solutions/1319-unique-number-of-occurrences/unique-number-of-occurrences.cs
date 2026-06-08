public class Solution
{
    public bool UniqueOccurrences(int[] nums)
    {
        HashSet<int> seenFreq = [];

        foreach(int freq in nums.CountBy(x => x).Select(x => x.Value))
            if (!seenFreq.Add(freq)) return false;

        return true;
    }
}