public class Solution
{
    public int Rob(int[] houses)
    {
        int n = houses.Length;
        if (n == 1) return houses[0];

        int twoBack = houses[0];
        int oneBack = Math.Max(twoBack, houses[1]);
        
        for (int i = 2; i < n; i++)
        {
            int temp = oneBack;

            oneBack = Math.Max(
                oneBack,              // skip
                houses[i] + twoBack); // take

            twoBack = temp;
        }

        return oneBack;
    }
}
