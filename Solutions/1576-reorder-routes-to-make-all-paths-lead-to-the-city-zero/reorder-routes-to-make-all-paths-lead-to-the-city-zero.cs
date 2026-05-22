using System.Collections;

public class Solution
{
    public int MinReorder(int n, int[][] connections)
    {
        var graph = new List<int>[n];
        HashSet<(int, int)> roads = [];
        var seen = new BitArray(length: n);
        int ans = 0;
        
        foreach(var pair in connections)
        {
            int c1 = pair[0], c2 = pair[1];

            graph[c1] ??= [];
            graph[c1].Add(c2);

            graph[c2] ??= [];
            graph[c2].Add(c1);

            roads.Add((c1, c2));        
        }

        void dfs(int node)
        {
            foreach (int neighbor in graph[node])
            {
                if (seen[neighbor]) continue;

                if (roads.Contains((node, neighbor)))
                    ans++;

                seen[neighbor] = true;
                dfs(neighbor);
            }
        }

        seen[0] = true;
        dfs(0);
        return ans;
    }
}