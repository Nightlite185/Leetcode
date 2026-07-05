public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        int n = s.Length;
        var memo = new bool?[n];
        
        bool dp(int i)
        {
            if (i == n) return true;
            if (memo[i] == false) return false;

            char firstChar = s[i];

            foreach(string w in wordDict)
            {
                int wordLen = w.Length;
                int remainingLen = n - i;

                //* if the first char doesnt match, dont even bother 
                //* with comparing the whole strings bc its O(n)

                if (wordLen > remainingLen
                || w[0] != firstChar) // * here *
                    continue;

                if (w == s[i .. (i + wordLen)])
                {
                    memo[i] = true;
                    
                    if (dp(i + wordLen))
                        return true;
                }
            }

            memo[i] = false;
            return false;
        }

        return dp(0);
    }
}