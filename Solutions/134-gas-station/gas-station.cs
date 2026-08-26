using System.Numerics;

public class Solution
{
    public int CanCompleteCircuit(int[] stations, int[] cost)
    {
        if (stations.Sum() < cost.Sum())
            return -1;
            
        int currGas = 0;
        int res = 0;

        for (int i = 0; i < stations.Length; i++)
        {
            currGas += stations[i] - cost[i];

            if (currGas < 0)
            {
                res = i+1;
                currGas = 0;
            }
        }

        return res;
    }
}