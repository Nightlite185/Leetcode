public class Solution
{
    private static readonly Dictionary<char, char> closeToOpen = new()
    {
        ['}'] = '{',
        [']'] = '[',
        [')'] = '('
    };

    public bool IsValid(string s)
    {
        Stack<char> stack = [];

        foreach(char c in s)
        {
            // if c is a closing brace
            if (closeToOpen.TryGetValue(c, out char opening))
            {
                // check if stack has corresponding opening one on top. 
                if (!stack.TryPop(out char top) || top != opening)
                    return false;
            }

            else stack.Push(c);
        }

        return stack.Count == 0;
    }
}