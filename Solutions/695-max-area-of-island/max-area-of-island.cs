using System.Collections;
using System.Collections.Immutable;

public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        var seen = new BitArray[rows];
        int ans = 0;

        for (int i = 0; i < rows; i++)
            seen[i] = new(length: cols);

        bool isValid(int y, int x)
        {
            return y >= 0 && y < rows
                && x >= 0 && x < cols
                && grid[y][x] == 1;
        }

        int dfs(int y, int x)
        {
            if (!isValid(y, x) || seen[y][x])
                return 0;

            seen[y][x] = true;
            int size = 0;

            foreach(var (dy, dx) in directions)
                size += dfs(y + dy, x + dx);

            return size + 1;
        }

        for (int y = 0; y < rows; y++)
        for (int x = 0; x < cols; x++)
        {
            if (seen[y][x] || grid[y][x] == 0)
                continue;

            ans = Math.Max(ans, dfs(y, x));
        }

        return ans;
    }

    private static readonly ImmutableArray<(int, int)> directions =
        [(0, -1), (0, +1), (+1, 0), (-1, 0)];
}