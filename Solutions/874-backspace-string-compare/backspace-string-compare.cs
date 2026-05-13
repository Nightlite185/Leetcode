public class Solution
{
    public bool BackspaceCompare(string s1, string s2)
    {
        int ptr1 = s1.Length - 1, 
            ptr2 = s2.Length - 1;

        char? c1 = ' ', c2 = ' ';

        while (c1 is not null && c2 is not null)
        {
            c1 = TryGetNext(ref ptr1, s1, 0);
            c2 = TryGetNext(ref ptr2, s2, 0);

            if (c1 != c2) return false;
        }

        return ptr1 <= 0 && ptr2 <= 0;
    }

    private static char? TryGetNext(ref int ptr, string s, int delCountInARow)
    {
        if (ptr < 0) return null;

        char c = s[ptr];
        ptr--;
        
        if (c == '#')
            return TryGetNext(ref ptr, s, ++delCountInARow);

        else if (delCountInARow > 0)
            return TryGetNext(ref ptr, s, --delCountInARow);

        else return c;
    }
}