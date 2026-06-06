public class Solution
{
    public int Maximum69Number(int num)
    {
        Span<char> digits = num.ToString().ToCharArray();
        int firstSix = digits.IndexOf('6');

        if (firstSix == -1) return num;

        digits[firstSix] = '9';
        return int.Parse(digits);
    }
}