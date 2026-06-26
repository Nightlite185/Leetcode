public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        List<IList<int>> ans = [];
        Stack<int> curr = [];

        void bt(int startNum)
        {
            if (curr.Count == k)
            {
                ans.Add([..curr]);
                return;
            }

            for (int i = startNum; i <= n; i++)
            {
                curr.Push(i);
                bt(i + 1);
                curr.Pop();
            }
        }

        bt(1);
        return ans;
    }
}