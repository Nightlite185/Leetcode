public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var window = new HashSet<char>();
        int left = 0, longest = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (!window.Add(c)) // found duplicate
            {
                while (c != s[left])
                {
                    window.Remove(s[left]);
                    left++;
                }

                left++;
            }

            longest = Math.Max(longest, i - left + 1);
        }

        return longest;
    }
}