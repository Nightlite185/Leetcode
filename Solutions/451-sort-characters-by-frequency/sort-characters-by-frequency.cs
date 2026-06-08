using System.Text;

public class Solution
{
    public string FrequencySort(string s)
    {
        var charsCounted = s.CountBy(x => x).ToArray();

        charsCounted.Sort(Comparer<KeyValuePair<char, int>>
            .Create((a, b) => b.Value.CompareTo(a.Value)));

        StringBuilder sb = new();

        foreach (var kvp in charsCounted)
            sb.Append(value: kvp.Key, repeatCount: kvp.Value);

        return sb.ToString();
    }
}