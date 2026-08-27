public class Solution
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;
        var ans = new int[n];
        Array.Fill(ans, 1);

        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i-1])
                ans[i] = ans[i-1] + 1;
        }

        for (int i = n-2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i+1])
                ans[i] = Math.Max(ans[i], ans[i+1] + 1);
        }

        return ans.Sum();
    }
}