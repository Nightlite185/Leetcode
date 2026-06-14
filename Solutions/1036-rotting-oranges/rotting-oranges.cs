public class Solution
{
    private const int Rotten = 2, Fresh = 1;

    public int OrangesRotting(int[][] grid)
    {
        Queue<(int x, int y)> queue = [];
        (int dx, int dy)[] dirs = [(1,0), (0,1), (-1,0), (0,-1)];
        int n = grid.Length,
            m = grid[0].Length,
            minutesPassed = 0,
            freshCount = 0;

        bool InBounds(int x, int y)
        {
            return x >= 0 && x < n
                && y >= 0 && y < m;
        }

        for (int x = 0; x < n; x++)
        for (int y = 0; y < m; y++)
        {
            switch (grid[x][y])
            {
                case Rotten:
                    queue.Enqueue(new(x,y));
                    break;

                case Fresh: 
                    freshCount++;
                    break;
            }
        }

        if (freshCount == 0) return 0;

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            minutesPassed++;

            for (int i = 0; i < lvlSize; i++)
            {
                var (x, y) = queue.Dequeue();

                foreach(var (dx, dy) in dirs)
                {
                    int newX = x + dx, newY = y + dy;

                    if (!InBounds(newX, newY) || grid[newX][newY] != Fresh)
                        continue;

                    queue.Enqueue((newX, newY));
                    grid[newX][newY] = Rotten;
                    
                    if (--freshCount == 0)
                        return minutesPassed;
                }
            }
        }

        return -1;
    }
}