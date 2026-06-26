using System.Text;

public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {                                               // 4 bc its the max count of letters mapped to one num
        List<string> ans = new(capacity: (int)Math.Pow(4, digits.Length));
        StringBuilder sb = new(capacity: digits.Length);
        var letters = GetLetters(digits);

        void bt(int i)
        {
            if (i == digits.Length)
            {
                ans.Add(sb.ToString());
                return;
            }

            foreach (char c in letters[i])
            {
                sb.Append(c);
                bt(i + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        bt(0);
        return ans;
    }

    private static string[] GetLetters(string digits)
    {
        var ans = new string[digits.Length];

        for (int i = 0; i < digits.Length; i++)
        {
            ans[i] = digits[i] switch
            {
                '2' => "abc",
                '3' => "def",
                '4' => "ghi",
                '5' => "jkl",
                '6' => "mno",
                '7' => "pqrs",
                '8' => "tuv",
                '9' => "wxyz",

                _ => ""
            };
        }

        return ans;
    }
}