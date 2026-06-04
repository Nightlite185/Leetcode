public class Solution
{
    public string ReverseWords(string s)
    {
        var chars = s.ToCharArray();
        int wordStart = 0;
        int n = chars.Length;
        int rightBound = n-1;

        for (int i = 0; i < n; i++)
        {
            if (chars[i] == ' ')
            {
                ReverseWord(chars, startIdx: wordStart, endIdx: i-1);
                wordStart = i+1;
            }
        }

        ReverseWord(chars, startIdx: wordStart, endIdx: rightBound);
        return new string(chars);
    }

    private static void ReverseWord(char[] arr, int startIdx, int endIdx)
    {
        while (startIdx < endIdx)
        {
            (arr[startIdx], arr[endIdx]) = (arr[endIdx], arr[startIdx]);
            
            startIdx++;
            endIdx--;
        }
    }
}