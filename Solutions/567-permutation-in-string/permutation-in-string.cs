public class Solution
{
    const int alphabetLength = 26;
    public bool CheckInclusion(string perm, string s)
    {
        if (perm.Length > s.Length)
            return false;

        int n = s.Length;
        int left = 0;
        int windowSize = perm.Length;

        int[] permCounts = new int[alphabetLength+1], 
              counts     = new int[alphabetLength+1];

        foreach (char c in perm)
            permCounts[MapToInt(c)]++;

        // building the first window
        for (int i = 0; i < windowSize; i++)
        {
            counts[MapToInt(s[i])]++;

            if (counts.SequenceEqual(permCounts))
                return true;
        }

        for (int right = windowSize; right < n; right++)
        {
            counts[MapToInt(s[right])]++;
            counts[MapToInt(s[left++])]--;

            if (counts.SequenceEqual(permCounts))
                return true;
        }

        return false;
    }

    private static int MapToInt(char c) => c - 'a';
}