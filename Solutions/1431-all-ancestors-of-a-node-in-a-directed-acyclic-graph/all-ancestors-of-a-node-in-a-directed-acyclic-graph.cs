public class Solution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var directAncestors = new List<int>?[n];
        var memo = new SortedSet<int>?[n];
        var ans = new int[n][];

        foreach (var edge in edges)
        {
            int anc = edge[0], child = edge[1];
            ref var ancestors = ref directAncestors[child];

            if (ancestors is null) ancestors = [anc];
            else ancestors.Add(anc);
        }
        
        for (int i = 0; i < n; i++)
            ans[i] = [..dfs(i)];
        
        return ans;


        SortedSet<int> dfs(int node)
        {
            ref var computed = ref memo[node];

            if (computed is not null)
                return computed;

            var result = new SortedSet<int>();
            var dirAncs = directAncestors[node];

            if (dirAncs is null) return result;

            foreach (var parent in dirAncs)
            {
                result.Add(parent);
                result.UnionWith(dfs(parent));
            }

            computed = result;
            return result;
        }
    }
}