public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length, ans = 0;
        
        (int dx, int dy)[] dirs = [(0,1), (0,-1), (1,0), (-1,0)];
        bool[][] seen = new bool[n][];

        for (int i = 0; i < n; i++)
            seen[i] = new bool[m];

        for (int x = 0; x < n; x++)
        for (int y = 0; y < m; y++)
        {
            if (seen[x][y] || grid[x][y] == 0)
                continue;
            
            seen[x][y] = true;
            dfs(x, y);
        }

        return ans;

        #region helpers
        bool OutOfBounds(int x, int y)
        {
            return x >= n || x < 0
                || y >= m || y < 0;
        }

        void dfs(int x, int y)
        {
            foreach (var (dx, dy) in dirs)
            {
                int newX = x + dx, newY = y + dy;

                if (OutOfBounds(newX, newY) || grid[newX][newY] == 0)
                {
                    ans++; continue;
                }

                if (seen[newX][newY]) continue;

                seen[newX][newY] = true;
                dfs(newX, newY);
            }
        }
        #endregion
    }
}