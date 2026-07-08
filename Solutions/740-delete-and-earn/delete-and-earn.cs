public class Solution
{
    public int DeleteAndEarn(int[] nums)
    {
        var counts = nums.CountBy(x => x).ToDictionary();
        nums = [..nums.Distinct().Order()];

        int earn1 = 0, earn2 = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int currEarn = num * counts[num];

            if (i > 0 && num == nums[i-1] + 1)
            {
                int temp = Math.Max(earn1 + currEarn, earn2);
                
                earn1 = earn2;
                earn2 = temp;
            }

            else
            {
                int temp = earn2 + currEarn;

                earn1 = earn2;
                earn2 = temp;
            }
        }

        return earn2;
    }
}