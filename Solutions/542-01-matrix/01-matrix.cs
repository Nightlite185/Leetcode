using System.Collections;

public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        Span<(int, int)> dirs = [ (0, 1), (1, 0), (-1, 0), (0, -1) ];
        int n = mat.Length, m = mat[0].Length, currLvl = -1;
        var queue = new Queue<(int x, int y)>();
        var seen = new BitArray[n];
        int[][] ans = new int[n][];
        
        for (int i = 0; i < n; i++)
        {
            // initializing ans and seen arrays
            seen[i] = new(length: m);
            ans[i] = new int[m];

            // adding starting points for out bfs (all the 1s)
            for (int j = 0; j < m; j++)
            {
                if (mat[i][j] == 0)
                    queue.Enqueue((i, j));
            }
        }

        bool isValid(int x, int y)
        {
            return x >= 0 && y >= 0
                && x < n && y < m
                && !seen[x][y];
        }
    
        while (queue.Count > 0)
        {
            currLvl++;
            int lvlCount = queue.Count;

            for (int i = 0; i < lvlCount; i++)
            {
                var (x, y) = queue.Dequeue();

                if (seen[x][y]) continue;
                seen[x][y] = true;

                if (mat[x][y] == 1)
                    ans[x][y] = currLvl;
                
                foreach(var (dx, dy) in dirs)
                {
                    int newX = x + dx, newY = y + dy;

                    if (isValid(newX, newY) && !seen[newX][newY])
                        queue.Enqueue((newX, newY));
                }
            }
        }

        return ans;
    }
}