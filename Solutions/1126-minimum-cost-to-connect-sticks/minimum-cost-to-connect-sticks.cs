public class Solution
{
    public int ConnectSticks(int[] sticks)
    {
        var heap = new PriorityQueue<int, int>();
        int cost = 0;

        foreach(int s in sticks)
            heap.Enqueue(s, s);

        while (heap.Count > 1)
        {
            int s1 = heap.Dequeue(), s2 = heap.Dequeue();
            int connected = s1 + s2;

            cost += connected;
            heap.Enqueue(connected, connected);
        }

        return cost;
    }
}