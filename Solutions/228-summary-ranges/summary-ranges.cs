public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0)
            return [];

        List<string> ranges = [];
        int prev = nums[0];

        bool streak = false;
        int streakStartIdx = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];

            if (num == prev + 1)
            {
                if (!streak)
                {
                    streak = true;
                    streakStartIdx = i-1;
                }
            }

            else
            {
                if (!streak)
                    ranges.Add(prev.ToString());

                else
                {
                    streak = false;
                    ranges.Add(StrRange(nums[streakStartIdx], prev));
                }
            }

            prev = num;
        }

        ranges.Add(streak
            ? StrRange(nums[streakStartIdx], prev)
            : prev.ToString());

        return ranges;
    }

    private static string StrRange(int a, int b) => $"{a}->{b}";
}