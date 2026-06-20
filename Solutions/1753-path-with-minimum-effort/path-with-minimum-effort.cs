public class Solution
{
    public int MinimumEffortPath(int[][] heights)
    {
        int n = heights.Length, m = heights[0].Length;
        int left = 0, right = 0;
        (int dx, int dy)[] dirs = [(1,0), (0,1), (-1,0), (0,-1)];
        
        for (int i = 0; i < n; i++)
            right = Math.Max(right, heights[i].Max());

        bool dfs(int x, int y, in int limit, bool[,] seen)
        {
            if (x == n-1 && y == m-1)
                return true;

            int curr = heights[x][y];

            foreach (var (dx, dy) in dirs)
            {
                int newX = x + dx, newY = y + dy;

                if (newX < 0 || newY < 0
                ||  newX >= n || newY >= m)
                    continue;

                if (Math.Abs(heights[newX][newY] - curr) > limit)
                    continue;

                if (seen[newX, newY])
                    continue;

                seen[newX, newY] = true;
                
                if (dfs(newX, newY, limit, seen))
                    return true;
            }

            return false;
        }

        while (left < right)
        {
            var seen = new bool[n,m];
            seen[0,0] = true;
            
            int mid = left + (right - left) / 2;

            if (dfs(x: 0, y: 0, limit: mid, seen))
                right = mid;

            else left = mid + 1;
        }

        return left;
    }
}