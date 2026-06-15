public class Solution
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        if (roads.Length == 0) return 0;

        var degrees = new int[n];
        var isConnected = new bool[n,n];

        foreach (var road in roads)
        {
            int c1 = road[0], c2 = road[1];

            degrees[c1]++;
            degrees[c2]++;

            isConnected[c1, c2] = true;
            isConnected[c2, c1] = true;
        }
    
        int maxRank = 0;
        
        for (int i = 0;   i < n; i++)
        for (int j = i+1; j < n; j++)
        {
            int rank = degrees[i] + degrees[j] 
                - (isConnected[i,j] ? 1 : 0);

            maxRank = Math.Max(maxRank, rank);
        }

        return maxRank;
    }
}