public class Solution
{
    public string SimplifyPath(string s)
    {
        var stack = new Stack<char>(s.Length);
        int i = s.Length - 1;

        bool insideName = false;
        int skipNextDirs = 0;
        int dotCount = 0;

        for (i = i; i >= 0; i--)
        {
            char c = s[i];

            if (c == '.')
            {
                if (insideName && skipNextDirs == 0)
                    stack.Push(c);

                else dotCount++;
            }

            else if (c == '/')
            {
                int _dotCount = dotCount; // copying dot count, before resetting the real one - to stay DRY
                bool wasInsideName = insideName; // same here
                insideName = false;
                dotCount = 0;

                switch (_dotCount)
                {
                    case 1:
                        stack.TryPop(out _); // removing the last slash bc it just led to a single dot.
                        break;

                    case 2:
                        skipNextDirs++;
                        continue;

                    case > 2 when skipNextDirs == 0: // valid directory name
                        stack.PushMultiple('.', _dotCount);
                        break;
                }

                if ((wasInsideName || _dotCount > 2) && skipNextDirs > 0)
                    skipNextDirs--;

                // path cant end with a slash, so we just skip
                if (!stack.TryPeek(out char top))
                    continue;

                else if (top != '/')
                    stack.Push(c);
            }

            else // if c is part of dir name
            {
                insideName = true;

                if (skipNextDirs > 0)
                    continue;

                stack.PushMultiple('.', dotCount);
                dotCount = 0;
                
                stack.Push(c);
            }
        }

        if (!stack.TryPeek(out char topp) || topp != '/')
            stack.Push('/'); // path always needs to start with '/'

        return new string([..stack]);
    }
}

internal static class StackExtensions
{
    internal static void PushMultiple<T>(this Stack<T> stack, T item, int times)
    {
        for (int i = 0; i < times; i++)
            stack.Push(item);
    }
}