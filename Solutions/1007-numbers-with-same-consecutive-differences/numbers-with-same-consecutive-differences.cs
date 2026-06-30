public class Solution
{
    public int[] NumsSameConsecDiff(int n, int diff)
    {
        List<int> ans = [];

        void backTrack(int currNum, int bAse, int lastDigit)
        {
            if (bAse < 0)
            {
                ans.Add(currNum);
                return;
            }

            int upperNeighbor = lastDigit + diff;
            int lowerNeighbor = lastDigit - diff;
            int newBase = bAse - 1;

            if (upperNeighbor <= 9)
            {
                int toAdd = GetNumber(
                    upperNeighbor, newBase);

                backTrack(currNum + toAdd, 
                        newBase, upperNeighbor);
            }

            if (lowerNeighbor >= 0)
            {
                int toAdd = GetNumber(
                    lowerNeighbor, newBase);

                backTrack(currNum + toAdd, 
                        newBase, lowerNeighbor);
            }
        }

        int initialBase = n-1;

        for (int i = 1; i <= 9; i++)
            backTrack(GetNumber(i, initialBase), initialBase, i);

        return ans.Distinct().ToArray();
    }

    private static int GetNumber(int digit, int Base)
    {
        if (Base == 0) return digit;

        return digit * (int)Math.Pow(10, Base);
    }
}