using System.Collections;

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
            return true;

        var graph = new List<int>[n];
        BitArray seen = new(length: n);
        
        foreach(var pair in edges)
        {
            int a = pair[0], b = pair[1];

            graph[a] ??= [];
            graph[b] ??= [];

            graph[a].Add(b);
            graph[b].Add(a);
        }
    
        bool dfs(int node)
        {
            if (graph[node] is not List<int> neighbors)
                return false;

            seen[node] = true;

            foreach (var neighbor in neighbors)
            {
                if (seen[neighbor]) continue;
                seen[neighbor] = true;

                if (neighbor == destination || dfs(neighbor))
                    return true;
            }

            return false;
        }

        return dfs(source);
    }
}