public class Solution
{
    public int SmallestDivisor(int[] nums, int threshold)
    {
        int right = 1_000_000;
        int left = 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (withinTreshold(mid))
                right = mid;

            else left = mid + 1;
        }

        return left;

        bool withinTreshold(int divisor)
        {
            double sum = 0;

            foreach(int num in nums)
                sum += Math.Ceiling((double)num / divisor);

            return sum <= threshold;
        }
    }
}