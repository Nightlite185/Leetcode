public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int curr = 0, left = 0;

        for (int i = 0; i < k; i++)
            if (IsVowel(s[i])) curr++;

        int ans = curr;

        for (int right = k; right < s.Length; right++)
        {
            if (IsVowel(s[right]))
                curr++;

            if (IsVowel(s[left++]))
                curr--;

            ans = Math.Max(ans, curr);
        }

        return ans;
    }

    private static bool IsVowel(char c)
        => c is 'a' or 'i' or 'u' or 'e' or 'o';
}