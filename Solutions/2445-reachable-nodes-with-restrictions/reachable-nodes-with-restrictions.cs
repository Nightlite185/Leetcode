using System.Collections;

public class Solution
{
    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
        // 'bad' represents seen and "restricted" nodes
        var bad = new BitArray(length: n);
        var graph = new List<int>[n];
        int ans = 0;
        
        foreach(int r in restricted)
            bad[r] = true;

        foreach (var pair in edges)
        {
            int a = pair[0], b = pair[1];

            graph[a] ??= [];
            graph[b] ??= [];

            graph[a].Add(b);
            graph[b].Add(a);
        }
    
        void dfs(int node)
        {
            ans++;

            var neighbors = graph[node];
            if (neighbors is null) return;
            
            bad[node] = true;

            foreach (int n in neighbors)
            {
                if (bad[n]) continue;

                bad[n] = true; // marking as seen
                dfs(n);
            }
        }

        dfs(0);
        return ans;
    }
}