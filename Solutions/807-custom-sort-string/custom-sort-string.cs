using System.Text;
using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public string CustomSortString(string order, string s)
    {
        Dictionary<char, int> charToIdx = [];
        var orderSet = order.ToHashSet();
        StringBuilder sb = new();

        foreach(char c in s)
        {
            if (!orderSet.Contains(c))
            {
                sb.Append(c);
                continue;
            }

            GetValueRefOrAddDefault(charToIdx, c, out _)++;
        }

        foreach(char c in order)
        {
            if (!charToIdx.TryGetValue(c, out var count))
                continue;

            sb.Append(value: c, repeatCount: count);
        }

        return sb.ToString();
    }
}