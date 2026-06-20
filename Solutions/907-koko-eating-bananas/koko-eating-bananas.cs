public class Solution
{
    public int MinEatingSpeed(int[] piles, int timeLimit)
    {
        int max = piles.Max();
        int left = 1, right = max;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (Check(piles, timeLimit, speed: mid))
                right = mid;

            else left = mid + 1;
        }

        return left;
    }

    private static bool Check(int[] piles, int timeLimit, int speed)
    {
        int timeElapsed = 0;

        foreach (int bananas in piles)
        {
            timeElapsed += (int)Math.Ceiling((double)bananas / speed);

            if (timeElapsed > timeLimit)
                return false;
        }

        return true;
    }
}