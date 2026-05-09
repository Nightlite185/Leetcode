public class Solution
{
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, int> digitSums = [];
        int maxSum = -1;

        foreach (int currNum in nums)
        {
            int digitSum = SumDigits(currNum);

            if (digitSums.TryGetValue(digitSum, out int highestNum))
            {
                maxSum = Math.Max(maxSum, currNum + highestNum);
                digitSums[digitSum] = Math.Max(currNum, highestNum);
            }

            else digitSums[digitSum] = currNum;
        }

        return maxSum;
    }

    private int SumDigits(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}