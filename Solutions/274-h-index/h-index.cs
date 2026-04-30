public class Solution
{
    public int HIndex(int[] citations)
    {
        int[] ordered = [..citations.OrderDescending()];

        for (int i = 0; i < ordered.Length; i++)
        {
            // i + 1 = count of numbers where x => x >= num
            if (i + 1 > ordered[i]) return i;
        }

        return ordered.Length;
    }
}