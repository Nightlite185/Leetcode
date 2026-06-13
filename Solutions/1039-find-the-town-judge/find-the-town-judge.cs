public class Solution
{
    public int FindJudge(int n, int[][] trust)
    {
        var indegrees = new int[n+2];
        var outdegrees = new int[n+2];
        int pplExceptJudge = n-1;
        
        foreach (var edge in trust)
        {
            int a = edge[0], b = edge[1];

            outdegrees[a]++;
            indegrees[b]++;
        }

        for (int person = 1; person <= n; person++)
        {
            // judge node has outdegree of 0 and indegree of n-1 (everyone trusts him)

            if (outdegrees[person] == 0 && indegrees[person] == pplExceptJudge)
                return person;
        }

        return -1;
    }
}