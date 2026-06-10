public class Solution
{
    public bool CloseStrings(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int n = s1.Length;

        Span<int> counts1 = stackalloc int[26+1];
        Span<int> counts2 = stackalloc int[26+1];
        HashSet<char> chars1 = [], chars2 = [];


        for (int i = 0; i < n; i++)
        {
            char c1 = s1[i], c2 = s2[i];

            counts1[c1 - 'a']++;
            counts2[c2 - 'a']++;

            chars1.Add(c1);
            chars2.Add(c2);
        }

        counts1.Sort(); counts2.Sort();
        
        return counts1.SequenceEqual(counts2)
            && chars1.SetEquals(chars2);
    }
}