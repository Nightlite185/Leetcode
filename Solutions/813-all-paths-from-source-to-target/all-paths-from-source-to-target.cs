public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        List<IList<int>> ans = [];
        List<int> curr = [0];
        int targetNode = graph.Length - 1;

        void bt(int node)
        {
            if (node == targetNode)
            {
                ans.Add([..curr]);
                return;
            }

            foreach (int x in graph[node])
            {
                curr.Add(x);
                bt(x);
                curr.RemoveAt(curr.Count - 1);
            }
        }

        bt(0);
        return ans;
    }
}