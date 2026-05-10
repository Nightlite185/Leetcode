public class Solution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        HashSet<char> jewelsSet = jewels.ToHashSet();
        int count = 0;

        foreach(char c in stones)
        {
            if (jewelsSet.Contains(c))
                count++;
        }

        return count;
    }
};