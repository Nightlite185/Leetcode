public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int max = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            int profit = prices[i] - prices[i-1];

            if (profit > 0)
                max += profit;
        }

        return max;
    }
}