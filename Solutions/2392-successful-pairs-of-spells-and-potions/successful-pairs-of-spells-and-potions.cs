public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        var ans = new int[spells.Length];
        potions.Sort();

        for (int i = 0; i < spells.Length; i++)
        {
            int left = 0, right = potions.Length;
            int spell = spells[i];

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                long num = potions[mid] * (long)spell;

                if (num < success)
                    left = mid + 1;

                else right = mid;
            }

            ans[i] = potions.Length - left;
        }

        return ans;
    }
}