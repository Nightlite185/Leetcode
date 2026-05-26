using System.Collections;
using System.Collections.Immutable;

public class Solution
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1 
        || grid[^1][^1] == 1) return -1;
        
        if (grid.Length == 1) return 1;

        int n = grid.Length, path = 1;
        var seen = new BitArray[n];

        for (int i=0; i<n; i++) // init the seen BitArrays
            seen[i] = new BitArray(length: n);

        Queue<(int x, int y)> queue = [];
        queue.Enqueue((0,0));

        bool isValid(int x, int y)
        {
            return x >= 0 && y >= 0
                && x < n && y < n && 
                grid[x][y] == 0;
        }

        // returns whether any new lvl coords are at destination
        bool handleLvl(int x, int y)
        {
            foreach(var (dx, dy) in directions)
            {
                int newX = x + dx, newY = y + dy;

                if (!isValid(newX, newY) || seen[newX][newY])
                    continue;

                if (newX == n-1 && newX == newY)
                    return true;

                seen[newX][newY] = true;
                queue.Enqueue((newX, newY));
            }

            return false;
        }

        while (queue.Count > 0)
        {
            int lvlCount = queue.Count;
            path++;

            for (int i = 0; i < lvlCount; i++)
            {
                var (x, y) = queue.Dequeue();

                if (handleLvl(x, y))
                    return path;
            }
        }

        return -1;
    }

    private readonly static ImmutableArray<(int, int)> directions = [
        (0, 1), (1, 0), (0,-1), (-1, 0), // N, E, S, W
        (1, 1), (-1, -1), (1,-1), (-1, 1)]; // diagonals
}