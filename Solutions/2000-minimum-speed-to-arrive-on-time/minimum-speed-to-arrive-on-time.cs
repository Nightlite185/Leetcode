public class Solution
{
    public int MinSpeedOnTime(int[] dist, double timeLeft)
    {
        if (dist.Length > Math.Ceiling(timeLeft)) return -1;
        int left = 1, right = (int)Math.Pow(10,7);

        while (left < right)
        {
            int speed = left + (right - left) / 2;

            if (check(speed, timeLeft))
                right = speed;

            else left = speed + 1;
        }

        return left;

        bool check(int speed, in double timeLeft)
        {
            double time = 0;

            foreach (int d in dist)
            {
                time = Math.Ceiling(time);
                time += (double)d / speed;
            }

            return time <= timeLeft;
        }
    }
}