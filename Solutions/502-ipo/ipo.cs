public class Solution
{
    public int FindMaximizedCapital(int maxProjects, int currCapital, int[] profits, int[] projCosts)
    {
        PriorityQueue<int, int> heap = new();
        int ptr = 0, n = profits.Length;
        
        var projects = profits
            .Zip(projCosts)
            .OrderBy(x => x.Second)
            .ToArray();

        for (int i = 0; i < maxProjects; i++)
        {
            while (ptr < n && projects[ptr].Second <= currCapital)
            {
                int profit = projects[ptr++].First;
                heap.Enqueue(profit, -profit);
            }

            if (heap.Count == 0) return currCapital;

            currCapital += heap.Dequeue();
        }

        return currCapital;
    }
}