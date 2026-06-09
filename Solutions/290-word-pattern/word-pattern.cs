using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(separator: ' ');
        
        if (words.Length != pattern.Length)
            return false;

        int n = words.Length;

        Dictionary<char, string> patternWordMap = [];
        Dictionary<string, char> wordPatternMap = [];

        for (int i = 0; i < n; i++)
        {
            string word = words[i];
            char p = pattern[i];

            ref var linkedWord        = ref GetValueRefOrAddDefault(patternWordMap, p, out bool hadWord);
            ref var linkedPatternChar = ref GetValueRefOrAddDefault(wordPatternMap, word, out bool hadPattern);

            if (hadPattern != hadWord)
                return false;

            if (!hadPattern) // or !hadWord, makes no difference
            {
                linkedPatternChar = p;
                linkedWord = word;
            }

            else if (linkedPatternChar != p || linkedWord != word)
                return false;
        }

        return true;
    }
}