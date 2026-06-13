public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length, ans = 0;
        
        (int dx, int dy)[] dirs = [(0,1), (0,-1), (1,0), (-1,0)];
        
        for (int x = 0; x < n; x++)
        for (int y = 0; y < m; y++)
        {
            if (grid[x][y] == 0)
                continue;

            CheckNeighbors(x, y);
        }

        return ans;

        #region helpers
        bool OutOfBounds(int x, int y)
        {
            return x >= n || x < 0
                || y >= m || y < 0;
        }
        
        void CheckNeighbors(int x, int y)
        {
            foreach (var (dx, dy) in dirs)
            {
                int newX = x + dx, newY = y + dy;

                if (OutOfBounds(newX, newY)
                || grid[newX][newY] == 0)
                {
                    ans++; continue;
                }
            }
        }
        #endregion
    }
}