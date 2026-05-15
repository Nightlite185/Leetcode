public class MovingAverage(int size)
{
    private double currSum = 0;
    private int count = 0;
    private readonly Queue<int> window = [];

    public double Next(int val)
    {
        window.Enqueue(val);

        currSum += val;
        count++;

        while (window.Count > size)
            currSum -= window.Dequeue();

        return currSum / Math.Min(size, count);
    }
}