using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == 1) return [nums[0]];

        var heap = new PriorityQueue<int, int>(initialCapacity: k + 1);
        var freq = new Dictionary<int, int>(capacity: nums.Length);
        int[] ans = new int[k];

        foreach (int num in nums)
            GetValueRefOrAddDefault(dictionary: freq, key: num, out _)++;

        foreach (var kvp in freq)
        {
            heap.Enqueue(kvp.Key, kvp.Value);

            if (heap.Count > k)
                heap.Dequeue();
        }

        for (int i = 0; heap.Count > 0; i++)
            ans[i] = heap.Dequeue();

        return ans;
    }
}