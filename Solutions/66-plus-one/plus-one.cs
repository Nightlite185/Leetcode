public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] + 1 < 10)
            {
                digits[i]++;
                return digits;
            }

            else digits[i] = 0;
        }

        int[] ans = new int[digits.Length + 1];
        ans[0] = 1;
        
        Array.Copy(digits, 0, ans, 1, digits.Length);
        return ans;
    }
}