public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> heap = new();

        foreach(int x in nums)
            heap.Enqueue(x, -x);

        for (int i = 1; i < k; i++)
            heap.Dequeue();

        return heap.Dequeue();
    }
}