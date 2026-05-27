public class Solution
{
    public int ShortestPath(int[][] grid, int k)
    {
        int n = grid.Length, 
            m = grid[0].Length, 
            currLvl = -1,
            killArrSize = k+1;

        if (n == 1 && m == 1) return 0;
        
        Span<(int x, int y)> dirs = [(0,1), (1,0), (-1,0), (0,-1)];
        var queue = new Queue<(int x, int y, int killsLeft)>();
        int[][][] seen = new int[n][][];
        queue.Enqueue((0, 0, k));

        for (int i = 0; i < n; i++)
        {
            seen[i] = new int[m][];
            
            for (int j = 0; j < m; j++)
                seen[i][j] = new int[killArrSize];
        }
        
        while(queue.Count > 0)
        {
            int lvlCount = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlCount; i++)
            {
                var (x, y, killsLeft) = queue.Dequeue();
                
                foreach (var (dx, dy) in dirs)
                {
                    int newX = x + dx, newY = y + dy,
                        localKillsLeft = killsLeft;

                    if (newX == n-1 && newY == m-1)
                        return currLvl + 1; // +1 bc we're now looking at the new neighbors, not curr lvl

                    if (!isValid(newX, newY)) continue;

                    if (grid[newX][newY] == 1)
                    {
                        if (localKillsLeft > 0)
                            localKillsLeft--;

                        else continue;
                    }

                    if (seen[newX][newY][localKillsLeft] == 1)
                        continue;

                    seen[newX][newY][localKillsLeft] = 1;
                    queue.Enqueue((newX, newY, localKillsLeft));
                }
            }
        }

        return -1;

        bool isValid(int x, int y)
        {
            return x >= 0 && y >= 0
                && x < n  && y < m;
        }
    }
}