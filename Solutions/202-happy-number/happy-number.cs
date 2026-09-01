public class Solution
{
    public bool IsHappy(int n)
    {
        HashSet<int> seen = [];

        while (n != 1)
        {
            int aggr = 0;

            while (n > 0)
            {
                int rem = n % 10;
                aggr += rem * rem;

                n /= 10;
            }

            if (!seen.Add(aggr))
                return false;
            
            n = aggr;
        }

        return true;
    }
}