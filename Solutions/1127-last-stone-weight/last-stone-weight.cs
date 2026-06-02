public class Solution
{
    private static readonly Comparer<int> DESCcomparer = 
        Comparer<int>.Create((x, y) => y.CompareTo(x));

    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> pq = new(
            items: stones.Select(x => (x, x)), 
            comparer: DESCcomparer);

        while (pq.Count >= 2)
        {
            int heaviest = pq.Dequeue(), maybeLighter = pq.Dequeue();

            if (heaviest > maybeLighter)
            {
                int remaining = heaviest - maybeLighter;
                pq.Enqueue(remaining, remaining);
            }
        }

        return pq.TryDequeue(out int last, out _) ? last : 0;
    }
}