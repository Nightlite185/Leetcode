public class Solution
{
    public int CountElements(int[] arr)
    {
        var set = arr.ToHashSet();
        int count = 0;

        foreach (int num in arr)
            if (set.Contains(num + 1))
                count++;

        return count;
    }
} 