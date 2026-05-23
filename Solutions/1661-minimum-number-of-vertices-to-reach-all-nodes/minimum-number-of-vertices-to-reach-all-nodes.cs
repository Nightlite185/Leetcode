using System.Collections;

public class Solution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        BitArray accessibleFromOutside = new(length: n);
        List<int> ans = [];

        foreach (var pair in edges)
            accessibleFromOutside[pair[1]] = true;

        for (int i = 0; i < n; i++)
        {
            if (!accessibleFromOutside[i])
                ans.Add(i);
        }

        return ans;
    }
}