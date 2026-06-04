using static System.Math;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], double> heap = new();
        var ans = new int[k][];

        foreach(var p in points)
            heap.Enqueue(p, DistanceFrom0(x: p[0], y: p[1]));

        for(int i = 0; i < k; i++)
            ans[i] = heap.Dequeue();

        return ans;
    }

    private static double DistanceFrom0(int x, int y)
        => Sqrt(x*x + y*y);
}