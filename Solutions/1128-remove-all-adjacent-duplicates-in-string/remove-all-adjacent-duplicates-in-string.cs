public class Solution
{
    public string RemoveDuplicates(string s)
    {
        Stack<char> stack = new(
            capacity: Math.Max(1, s.Length / 2));

        foreach(char c in s)
        {
            if (stack.TryPeek(out char top) && top == c)
                stack.Pop();

            else stack.Push(c);
        }

        return new string([..stack.Reverse()]);
    }
}