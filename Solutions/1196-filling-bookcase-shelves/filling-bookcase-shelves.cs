public class Solution
{
    const int WidthIdx = 0;
    const int HeightIdx = 1;
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        var memo = new int[books.Length];

        int dp(int i)
        {
            if (i >= books.Length) return 0;
            if (memo[i] != 0) return memo[i];

            int currWidth = 0;
            int maxHeight = 0;
            int j;
            int minCount = int.MaxValue;

            for (j = i; j < books.Length; j++)
            {
                int h = books[j][HeightIdx];
                int w = books[j][WidthIdx];

                currWidth += w;

                if (currWidth > shelfWidth)
                    break;

                maxHeight = Math.Max(maxHeight, h);
                minCount = Math.Min(minCount, dp(j+1) + maxHeight);
            }

            memo[i] = minCount;
            return minCount;
        }

        return dp(0);
    }
}