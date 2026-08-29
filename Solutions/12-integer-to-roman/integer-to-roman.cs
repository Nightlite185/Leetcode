using System.Text;

public class Solution
{
    public string IntToRoman(int target)
    {
        StringBuilder sb = new();
        (string, int)[] romans = [
            ("M", 1000), ("CM", 900), ("D", 500),
            ("CD", 400), ("C", 100), ("XC", 90),
            ("L", 50), ("XL", 40), ("X", 10), 
            ("IX", 9), ("V", 5), ("IV", 4), ("I", 1)
        ];

        for (int i = 0; i < romans.Length; i++)
        {
            (string sym, int unit) = romans[i];

            int count = target / unit;

            if (count <= 0) continue;
            
            for (int j = 0; j < count; j++)
                sb.Append(sym);

            target %= unit;
        }

        return sb.ToString();
    }
}