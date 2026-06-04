public class Solution
{
    public string ReverseOnlyLetters(string s)
    {
        const int leftBound = 0;
        var chars = s.ToCharArray();
        int n = s.Length, left = 0, right = n-1;
        int rightBound = n-1;

        while (true)
        {
            while (left <= rightBound && !char.IsLetter(chars[left]))
                left++;

            while (right >= leftBound && !char.IsLetter(chars[right]))
                right--;

            if (left > n || right < 0 || left >= right)
                break;

            (chars[left], chars[right]) =
            (chars[right], chars[left]);

            left++; right--;
        }

        return new string(chars);
    }
}