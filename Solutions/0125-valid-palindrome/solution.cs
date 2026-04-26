public class Solution
{ 
    public bool IsPalindrome(string s)
    {
        string cleaned = new([..s.Where(char.IsLetterOrDigit)]);
        cleaned = cleaned.ToLowerInvariant();

        int j = cleaned.Length;

        for (int i = 0; i < cleaned.Length; i++)
        {
            j--;

            if (cleaned[i] != cleaned[j])
                return false;
        }

        return true;
    }
}
