public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        return s.Order().SequenceEqual(t.Order());
    }
}