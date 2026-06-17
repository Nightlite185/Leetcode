public class Solution
{
    public int NumOfMinutes(int n, int headID, int[] managers, int[] informTime)
    {
        var graph = new List<int>[n];
        int maxTimePath = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (i == headID) continue;

            // ith employee's manager
            int manager = managers[i];
            ref var subs = ref graph[manager];

            if (subs is null) subs = [i];
            else subs.Add(i);
        }

        void dfs(int node, int time)
        {
            var subs = graph[node];
            
            if (subs is null)
            {
                maxTimePath = Math.Max(maxTimePath, time);
                return;
            }

            time += informTime[node];

            foreach (int sub in subs)
                dfs(sub, time);
        }

        dfs(headID, 0);
        return maxTimePath;
    }
}