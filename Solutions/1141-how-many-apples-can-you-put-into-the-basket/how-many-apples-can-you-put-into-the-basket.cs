public class Solution
{
    private const int MaxWeight = 5000;
    public int MaxNumberOfApples(int[] apples)
    {
        apples.Sort();
        int currWeight = 0;

        for (int i = 0; i < apples.Length; i++)
        {
            currWeight += apples[i];

            if (currWeight > MaxWeight)
                return i;
        }

        return apples.Length;
    }
}