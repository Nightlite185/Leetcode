public class Solution
{
    public int UniquePaths(int rows, int cols)
    {
        var memo = new int?[rows, cols];
        int rowBound = rows-1, colBound = cols - 1;
        
        int dp(int r, int c)
        {
            if (r >= rows || c >= cols)         return 0;
            if (r == rowBound && c == colBound) return 1;
            if (memo[r,c] is int m)             return m;

            int res = dp(r + 1, c) + dp(r, c + 1);
            memo[r,c] = res;
            
            return res;
        }

        return dp(0,0);
    }
}