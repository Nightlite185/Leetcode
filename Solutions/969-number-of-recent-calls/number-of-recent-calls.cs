public class RecentCounter
{
    private const short howRecent = 3000;
    private Queue<int> queue = [];

    public int Ping(int t)
    {
        queue.Enqueue(t);

        while (queue.TryPeek(out int end)
            && end < (t - howRecent))
        {
            queue.Dequeue();
        }

        return queue.Count;
    }
}