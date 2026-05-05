public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var sCount = s.CountBy(c => c).ToDictionary();
        var tCount = t.CountBy(c => c).ToDictionary();

        foreach(var kvp in sCount)
        {
            if (!tCount.TryGetValue(kvp.Key, out int count)
            || kvp.Value != count)
                return false;
        }

        return true;
    }
}