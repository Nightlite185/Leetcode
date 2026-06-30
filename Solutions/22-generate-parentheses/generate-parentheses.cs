using System.Text;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        int maxLength = 2*n;
        StringBuilder sb = new(value: "(", capacity: maxLength);
        List<string> ans = new(capacity: n);
        
        void bt(int openCount, int closeCount)
        {
            if (sb.Length == maxLength)
                ans.Add(sb.ToString());

            if (openCount < n)
            {
                sb.Append('(');
                bt(openCount + 1, closeCount);
                sb.Remove(sb.Length - 1, 1);
            }

            if (closeCount < openCount)
            {
                sb.Append(')');
                bt(openCount, closeCount + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        bt(1,0);
        return ans;
    }
}