public class Solution
{
    private const char Wall = '+', Empty = '.';
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int currLvl = -1, n = maze.Length, m = maze[0].Length, xBound = n-1, yBound = m-1;
        Span<(int dx, int dy)> directions = [(0,1), (1,0), (0,-1), (-1,0)];
        Queue<(int x, int y)> queue = [];
        queue.Enqueue((entrance[0], entrance[1]));
        bool[][] seen = new bool[n][];

        for (int i = 0; i < n; i++)
            seen[i] = new bool[m];

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            currLvl++;
            
            for (int i = 0; i < lvlSize; i++)
            {
                var (x, y) = queue.Dequeue();

                foreach(var (dx, dy) in directions)
                {
                    int nextX = x + dx, nextY = y + dy;

                    if (!isValid(nextX, nextY) || seen[nextX][nextY])
                        continue;

                    if (isExit(nextX, nextY))
                        return currLvl + 1;

                    seen[nextX][nextY] = true;
                    queue.Enqueue((nextX, nextY));
                }
            }
        }

        return -1;

        // this is called only after confirming that coords given are not in seen and theyre valid
        bool isExit(int x, int y)
        {
            return (x == xBound || x == 0 
                 || y == yBound || y == 0)
                 && (entrance[0] != x || entrance[1] != y);
        }

        bool isValid(int x, int y)
        {
            return x >= 0 && y >= 0
                && x < n && y < m
                && maze[x][y] != Wall;
        }
    }
}