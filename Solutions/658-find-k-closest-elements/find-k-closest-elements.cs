public class Solution
{
    public IList<int> FindClosestElements(int[] nums, int k, int x)
    {
        int[] ans = new int[k];

        var heap = new PriorityQueue<int, (int diff, int num)>(
            comparer: Comparer<(int diff, int num)>
            .Create((a, b) =>
            {
                if (a.diff == b.diff)
                    return b.num.CompareTo(a.num);

                return b.diff.CompareTo(a.diff);
            }));

        foreach(int num in nums)
        {
            int diff = Math.Abs(num - x);

            heap.Enqueue(num, (diff, num));

            if (heap.Count > k)
                heap.Dequeue();
        }

        for (int i = 0; heap.TryDequeue(out int num, out _); i++)
            ans[i] = num;

        ans.Sort();
        return ans;
    }
}