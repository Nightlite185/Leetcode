public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0)
            return [];

        if (nums.Length == 1) 
            return [nums[0].ToString()];

        List<string> ranges = [];
        int prev = nums[0];
        bool streak = false;
        int streakStartIdx = 0;

        for (int i = 1; i <= nums.Length; i++)
        {
            int num = nums.ElementAtOrDefault(i);

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
                    ranges.Add($"{nums[streakStartIdx]}->{prev}");
                }
            }

            prev = num;
        }

        return ranges;
    }
}