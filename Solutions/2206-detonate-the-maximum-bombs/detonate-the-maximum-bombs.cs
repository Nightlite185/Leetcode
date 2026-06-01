using static System.Math;
public class Solution
{
    public int MaximumDetonation(int[][] bombs)
    {
        int n = bombs.Length;
        var graph = new List<int>[n];
        int maxChain = 1;

        for (int i = 0; i < n; i++)
        {
            var b1 = bombs[i];
            
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                var b2 = bombs[j];

                var (b2InB1sRange, b1InB2sRange) = 
                    InRange(b1, b2);

                if (b2InB1sRange)
                {
                    graph[i] ??= [];
                    graph[i].Add(j);
                }

                if (b1InB2sRange)
                {
                    graph[j] ??= [];
                    graph[j].Add(i);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            var seen = new bool[n];
            seen[i] = true;
            int localChain = 0;
            
            void dfs(int node)
            {
                localChain++;

                if (graph[node] is not List<int> neighbors)
                    return;

                foreach(var nei in neighbors)
                {
                    if (seen[nei]) continue;
                    seen[nei] = true;

                    dfs(nei);
                }
            }

            dfs(i);

            maxChain = Max(maxChain, localChain);
        }
    
        return maxChain;
    }

    private static (bool b2InB1sRange, bool b1InB2sRange) InRange(int[] b1, int[] b2)
    {
        //  x coord,     y coord,     ratio
        int b1x = b1[0], b1y = b1[1], b1r = b1[2]; // bomb 1
        int b2x = b2[0], b2y = b2[1], b2r = b2[2]; // bomb 2

        long a = Abs(b1x - b2x);
        long b = Abs(b1y - b2y);
        
        double distance = Sqrt(a*a + b*b);

        return (b2InB1sRange: b1r >= distance, 
                b1InB2sRange: b2r >= distance);
    }
}