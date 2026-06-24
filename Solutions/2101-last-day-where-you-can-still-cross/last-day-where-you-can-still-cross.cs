public class Solution
{
    private int n, m;
    private int?[,] floodForecast = null!;
    private static (int dx, int dy)[] dirs = [(0,1), (1,0), (-1,0), (0,-1)];
    public int LatestDayToCross(int n, int m, int[][] cells)
    {
        floodForecast = new int?[n+1,m+1];
        for (int i = 0; i < cells.Length; i++)
        {
            var floodCoords = cells[i];
            floodForecast[floodCoords[0], floodCoords[1]] = i+1;
        }

        this.n = n; this.m = m;

        int left = 0, right = n * m;

        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;

            if (Check(mid)) left = mid;
            else right = mid - 1;
        }

        return right;
    }

    private bool Check(int lastDay)
    {
        for (int i = 1; i <= m; i++)
        {
            if (floodForecast[1, i] <= lastDay)
                continue;

            if (Dfs(x: 1, y: i, seen: new bool[n+1, m+1], lastDay))
                return true;
        }

        return false;
    }

    private bool Dfs(int x, int y, bool[,] seen, in int lastDay)
    {
        foreach(var (dx, dy) in dirs)
        {
            int newX = x + dx, newY = y + dy;

            if (newX < 1 || newY < 1
             || newX > n || newY > m)
                continue;

            if (seen[newX, newY] || floodForecast[newX, newY] <= lastDay)
                continue;

            seen[newX, newY] = true;

            if ((newX == n && newY >= 1 && newY <= m) 
            || Dfs(newX, newY, seen, lastDay))
                return true;
         }

         return false;
    }
}