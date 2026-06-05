public class Solution
{
    public int EqualSubstring(string s1, string s2, int maxCost)
    {
        int left = 0, ans = 0, currCost = 0;

        int getCost(int i) => Math.Abs(s1[i] - s2[i]);

        for (int right = 0; right < s1.Length; right++)
        {
            currCost += getCost(right);

            while (currCost > maxCost)
                currCost -= getCost(left++);

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}