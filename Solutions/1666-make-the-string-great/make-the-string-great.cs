public class Solution
{
    public string MakeGood(string s)
    {
        Stack<char> stack = [];

        foreach (char curr in s)
        {
            if (!stack.TryPeek(out char top)
            || char.ToLowerInvariant(top) != char.ToLowerInvariant(curr)
            || char.IsUpper(curr) != char.IsLower(top))
            {
                stack.Push(curr);
            }

            else stack.TryPop(out _);
        }

        return new string([..stack.Reverse()]);
    }
}