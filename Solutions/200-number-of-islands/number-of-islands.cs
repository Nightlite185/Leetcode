using System.Collections;
using System.Collections.Immutable;

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int ans = 0;
        int n = grid.Length;
        int m = grid[0].Length;

        var seen = new BitArray[n];
        
        for (int i = 0; i < seen.Length; i++)
            seen[i] = new(length: m);
        
        bool isValid(int x, int y)
        {
            return x < n && x >= 0
                && y < m && y >= 0
                && grid[x][y] == '1';
        }

        void dfs(int x, int y)
        {
            foreach (var (dx, dy) in directions)
            {
                int nextX = x + dx;
                int nextY = y + dy;

                if (!isValid(nextX, nextY) || seen[nextX][nextY])
                    continue;

                seen[nextX][nextY] = true;
                dfs(nextX, nextY);
            }
        }

        for(int x = 0; x < n; x++)
        for(int y = 0; y < m; y++)
        {
            if (seen[x][y] || grid[x][y] == '0')
                continue;

            ans++;
            seen[x][y] = true;
            dfs(x, y);
        }

        return ans;
    }

    private static readonly ImmutableArray<(int dx, int dy)> directions = [
        (0, -1), (0, +1),
        (-1, 0), (+1, 0)];
}