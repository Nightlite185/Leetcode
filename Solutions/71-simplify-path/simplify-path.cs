public class Solution
{
    public string SimplifyPath(string path)
    {
        Stack<string> stack = [];
        string[] pieces = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach(string piece in pieces)
        {
            if (piece == ".") 
                continue;

            else if (piece == "..") 
                stack.TryPop(out _);

            else stack.Push(piece);
        }

        return '/' + string.Join('/', stack.Reverse());
    }
}