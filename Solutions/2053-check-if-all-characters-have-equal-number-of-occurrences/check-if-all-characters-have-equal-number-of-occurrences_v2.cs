public class Solution
{
    public bool AreOccurrencesEqual(string s)
    {
        var counts = new Dictionary<char, int>();

        foreach(char c in s)
        {
            counts.TryGetValue(c, out int val);
            counts[c] = ++val;
        }

        int sample = counts.Values.First();

        foreach(int count in counts.Values.Skip(1))
        {
            if (count != sample)
                return false;
        }

        return true;
    }
}