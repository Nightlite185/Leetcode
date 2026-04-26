public class Solution 
{
    public int Reverse(int x) 
    {
        var sb = new StringBuilder(
            new string([..x.ToString().Reverse()]));
        
        if (sb[^1] is '-' or '+')
        {
            sb.Remove(sb.Length-1, 1);

            if (int.IsNegative(x))
                sb.Insert(0, '-');
        }

        return int.TryParse(sb.ToString(), out int result)
            ? result
            : 0;
    }
}
