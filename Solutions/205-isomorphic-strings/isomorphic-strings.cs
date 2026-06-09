using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public bool IsIsomorphic(string s1, string s2)
    {
        int n = s1.Length;
        Dictionary<char, int> firstSeen1 = [], firstSeen2 = [];

        FillDict(firstSeen1, s1);
        FillDict(firstSeen2, s2);

        for (int i = 0; i < n; i++)
        {
            if (firstSeen1[s1[i]] != firstSeen2[s2[i]])
                return false;
        }

        return true;
    }

    private static void FillDict(Dictionary<char, int> firstSeen, string s)
    {
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            char c = s[i];

            ref int val = ref GetValueRefOrAddDefault(
                firstSeen, c, out bool exists);

            if (!exists) val = i;
        }
    }
}