public class Solution {
    public int StrStr(string haystack, string needle)
    {
        int lastNeedleIdx = needle.Length - 1;
        int needleIdx = 0;

        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[needleIdx])
            {
                if (needleIdx == lastNeedleIdx)
                    return i - needleIdx;
                
                needleIdx++;

                continue;
            }

            i -= needleIdx;
            needleIdx = 0;
        }

        return -1;
    }
}
