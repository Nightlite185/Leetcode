public class KthLargest
{
    private readonly PriorityQueue<int, int> heap = new();
    private readonly int k;
    public KthLargest(int k, int[] nums)
    {
        foreach(int num in nums)
            heap.Enqueue(num, num);

        this.k = k;
    }

    public int Add(int val)
    {
        heap.Enqueue(val, val);

        while (heap.Count > k)
            heap.Dequeue();

        return heap.Peek();
    }
}