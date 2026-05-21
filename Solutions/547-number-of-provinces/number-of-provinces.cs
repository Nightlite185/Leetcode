using System.Collections;

public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length;
        var seen = new BitArray(length: n);
        var graph = BuildGraph(isConnected);
        int ans = 0;

        void dfs(int node)
        {
            if (!graph.TryGetValue(node, out var neighbors))
                return;

            foreach(int neighbor in neighbors)
            {
                if (seen[neighbor])
                    continue;

                seen[neighbor] = true;
                dfs(neighbor);
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            if (!seen[i])
            {
                seen[i] = true;
                ans++;
                dfs(i);
            }
        }

        return ans;
    }

    private static Dictionary<int, List<int>> BuildGraph(int[][] isConnected)
    {
        Dictionary<int, List<int>> graph = [];
        int n = isConnected.Length;

        for (int i = 0; i < n; i++)
        for (int j = i + 1; j < n; j++)
        {
            if (isConnected[i][j] == 0) 
                continue;

            if (graph.TryGetValue(i, out var neighbors1))
                neighbors1.Add(j); 
            else graph[i] = [j];

            if (graph.TryGetValue(j, out var neighbors2))
                neighbors2.Add(i);
            else graph[j] = [i];
        }

        return graph;
    }
}