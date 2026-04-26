public class Solution 
{
    private readonly static Dictionary<char, int> map = new()
    {
        ['I'] = 1, ['V'] = 5,
        ['X'] = 10, ['L'] = 50,
        ['C'] = 100, ['D'] = 500,
        ['M'] = 1000
    };

    public int RomanToInt(string roman)
    {
        int result = 0, prev = 0;

        for (int i = roman.Length - 1; i >= 0 ; i--)
        {
            int current = map[roman[i]];

            result += (current >= prev)
                ? + current
                : - current;

            prev = current;
        }

        return result;
    }
}
