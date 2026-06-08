public class Solution
{
    const int maxValue = 100;
    public int NumIdenticalPairs(int[] nums)
    {
        int n = nums.Length;
        int pairs = 0;

        var valueToIdx = new List<int>[maxValue + 1];

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];

            var list = valueToIdx[num];

            if (list is null)
                valueToIdx[num] = [i];

            else
            {
                pairs += list.Count;
                list.Add(i);
            }
        }

        return pairs;
    }
}