using System.Collections;

public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        var seen = new BitArray(n);
        var graph = new List<int>[n];
        int ans = 0;

        foreach (var pair in edges)
        {
            int a = pair[0], b = pair[1];

            graph[a] ??= [];
            graph[a].Add(b);

            graph[b] ??= [];
            graph[b].Add(a);
        }

        void dfs(int node)
        {
            seen[node] = true;

            if (graph[node] is not List<int> neighbors)
                return;

            foreach(var n in neighbors)
            {
                if (seen[n]) continue;
                dfs(n);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (seen[i]) continue;

            seen[i] = true;
            ans++;
            dfs(i);
        }
        
        return ans;
    }
}