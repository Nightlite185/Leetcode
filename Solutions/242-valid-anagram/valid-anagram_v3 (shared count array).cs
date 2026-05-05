public class Solution
{
    private const byte EngAlphabetLength = 26;

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        
        var counts = new int[EngAlphabetLength];

        for (int i = 0; i < s.Length; i++)
        {
            // subtracting 'a' gives us 0-indexed char value (0-26)
            // meaning that every char will have its own spot in the array.

            counts[s[i] - 'a']++; // adding here
            counts[t[i] - 'a']--; // subtracting here
        }

        // if all equal zero - means that the count of characters in s was the same as in t
        // since we added if its in s and subtracted in t - should zero out
        return counts.All(c => c == 0);
    }
}