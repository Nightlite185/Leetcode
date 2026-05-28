public class Solution
{
    private const int NoColor = -1;
    private const int Red = 0;
    private const int Blue = 1;
    private const int None = -1;

    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        Queue<(int node, int prevColor)> queue = [];
        var graph = new List<(int other, int color)>?[n];
        int currLvl = -1;
        var ans = new int[n];
        var seen = new bool[n][];

        // 0th idx is always 0 (0 distance to itself, alternating irrelevant)
        Array.Fill(ans, value: -1, startIndex: 1, count: n - 1); // so we fill from 1st idx as never found

        // initializing seen matrix
        for (int i = 0; i < n; i++)
            seen[i] = new bool[2];

        // mapping edges to graph
        MapToGraph(graph, redEdges, Red);
        MapToGraph(graph, blueEdges, Blue);

        // if outdegree from node 0 is 0, return quickly.
        if (graph[0] is null) return ans;
        queue.Enqueue((0, NoColor));


        while (queue.Count > 0)
        {
            int lvlItems = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlItems; i++)
            {
                var (node, prevColor) = queue.Dequeue();
                var edges = graph[node];

                if (ans[node] == None)
                    ans[node] = currLvl;

                if (edges is null) continue;

                foreach (var (otherNode, edgeColor) in edges)
                {
                    if (edgeColor == prevColor 
                    || seen[otherNode][edgeColor])
                        continue;

                    seen[otherNode][edgeColor] = true;
                    queue.Enqueue((otherNode, edgeColor));
                }
            }
        }

        return ans;
    }

    private static void MapToGraph(List<(int neighbor, int color)>?[] graph, int[][] edges, int color)
    {
        foreach (var edge in edges)
        {
            int a = edge[0], b = edge[1];

            graph[a] ??= [];
            graph[a]!.Add((b, color));
        }
    }
}