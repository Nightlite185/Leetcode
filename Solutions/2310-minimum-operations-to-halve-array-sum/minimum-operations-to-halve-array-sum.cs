public class Solution
{
    public int HalveArray(int[] nums)
    {
        PriorityQueue<double, double> pq = new();
        double currSum = 0;
        int ops = 0;

        foreach(int num in nums)
        {
            currSum += num;
            pq.Enqueue(num, -num);
        }

        double halfSum = currSum / 2;

        while(currSum > halfSum)
        {
            ops++;
            
            var halved = pq.Dequeue() / 2;
            currSum -= halved;
            pq.Enqueue(halved, -halved);
        }

        return ops;
    }
}