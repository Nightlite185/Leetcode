public class MovingAverage(int size)
{
    private Queue<int> window = [];
    public double Next(int val)
    {
        window.Enqueue(val);

        while (window.Count > size)
            window.Dequeue();

        return window.Average();
    }
}