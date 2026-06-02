public class Solution
{
    public int MinStoneSum(int[] piles, int k)
    {
        PriorityQueue<int, int> pq = new();
        int currSum = 0;

        foreach(int p in piles)
        {
            currSum += p;
            pq.Enqueue(p, -p);
        }

        for (int i = 0; i < k; i++)
        {
            int pile = pq.Dequeue();
            int taking = pile / 2;
            int remainder = pile - taking;

            pq.Enqueue(remainder, -remainder);

            currSum -= taking;
        }

        return currSum;
    }
}