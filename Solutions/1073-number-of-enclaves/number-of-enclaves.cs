public class Solution
{
    private readonly static (int dx, int dy)[] dirs = [(1,0), (0,1), (-1,0), (0,-1)];
    public int NumEnclaves(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        int totalEnclaves = 0;

        bool[][] seen = new bool[n][];

        for (int i = 0; i < n; i++)
            seen[i] = new bool[m];

        bool inBound(int x, int y)
        {
            return x >= 0 && y >= 0
                && x < n  && y < m;
        }

        for (int x = 0; x < n; x++)
        for (int y = 0; y < m; y++)
        {
            bool touchesMapEdge = false;
            int landCount = 0;

            void dfs(int x, int y)
            {
                foreach(var (dx, dy) in dirs)
                {
                    int newX = x + dx, newY = y + dy;

                    if (inBound(newX, newY))
                    {
                        if (seen[newX][newY])
                            continue;

                        seen[newX][newY] = true;

                        if (grid[newX][newY] == 1)
                        {
                            landCount++;
                            dfs(newX, newY);
                        }
                    }

                    else touchesMapEdge = true;
                }
            }

            if (grid[x][y] == 0 || seen[x][y])
                continue;

            seen[x][y] = true;
            landCount++;

            dfs(x,y);

            if (!touchesMapEdge)
                totalEnclaves += landCount;
        }

        return totalEnclaves;
    }
}