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
            if (graph[node] is null)
                return;

            foreach(int neighbor in graph[node]!)
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

    private static List<int>?[] BuildGraph(int[][] isConnected)
    {
        int n = isConnected.Length;
        var graph = new List<int>?[n];

        for (int i = 0; i < n; i++)
        for (int j = i + 1; j < n; j++)
        {
            if (isConnected[i][j] == 0) 
                continue;

            graph[i] ??= [];
            graph[i]!.Add(j);

            graph[j] ??= [];
            graph[j]!.Add(i);
        }

        return graph;
    }
}