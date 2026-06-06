public class Solution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        people.Sort();

        int ans = 0, light = 0, heavy = people.Length - 1;

        while (light <= heavy)
        {
            int sum = people[light] + people[heavy--];

            if (sum <= limit)
                light++;

            ans++;
        }

        return ans;
    }
}