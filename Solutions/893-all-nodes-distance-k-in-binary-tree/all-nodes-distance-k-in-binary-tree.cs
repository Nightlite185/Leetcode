using System.Collections;
using System.Collections.Immutable;

public class Solution
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        if (k > 500) return [];
        if (k == 0) return [target.val];

        int lvl = -1;
        Dictionary<int, ImmutableArray<int>> graph = [];
        BitArray seen = new(length: 500);
        Queue<int> queue = [];
        
        int dfs(TreeNode? node, int parentVal)
        {
            if (node?.val is not int val)
                return -1;

            graph[val] = [
                parentVal,
                dfs(node.left, val),
                dfs(node.right, val)
            ];

            return val;
        }

        dfs(root, -1);

        if (!graph.ContainsKey(target.val))
            return [];

        queue.Enqueue(target.val);

        while (queue.Count > 0)
        {
            int lvlCount = queue.Count;
            if (++lvl == k) return [..queue];

            for (int i = 0; i < lvlCount; i++)
            {
                int node = queue.Dequeue();

                if (seen[node]) continue;
                seen[node] = true;

                foreach (int neighbor in graph[node])
                {
                    if (neighbor == -1 || seen[neighbor])
                        continue;

                    queue.Enqueue(neighbor);
                }
            }
        }

        return [];
    }
}