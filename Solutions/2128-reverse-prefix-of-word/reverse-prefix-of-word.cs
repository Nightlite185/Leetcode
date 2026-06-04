public class Solution
{
    public string ReversePrefix(string word, char target)
    {
        var chars = word.ToCharArray();

        for (int i = 0; i < word.Length; i++)
        {
            if (chars[i] != target)
                continue;

            int left = 0, right = i;

            while (left < right)
            {
                (chars[left], chars[right]) =
                (chars[right], chars[left]);

                left++; right--;
            }
            break;
        }

        return new string(chars);
    }
}