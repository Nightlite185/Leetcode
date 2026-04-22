public class Solution 
{
    public int MaxProfit(int[] prices)
    {
        int lowest = prices[0];
        int safeBuy = 0;

        int sell = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            int p = prices[i];

            if (p < lowest) lowest = p;

            else if (p - lowest >= sell - safeBuy)
            {
                sell = p;
                safeBuy = lowest;
            }
        }

        if (sell <= 0 || sell <= safeBuy) return 0;

        return sell - safeBuy;
    }
}
