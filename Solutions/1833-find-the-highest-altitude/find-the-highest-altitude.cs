public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int curr = 0, ans = 0;

        for (int i = 0; i < gain.Length; i++)
        {
            curr += gain[i];
            ans = Math.Max(ans, curr);
        }

        return ans;
    }
}