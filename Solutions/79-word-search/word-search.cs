public class Solution
{
    public bool Exist(char[][] grid, string target)
    {
        (int dx, int dy)[] dirs = [(1,0), (0,1), (-1,0), (0,-1)];
        int n = grid.Length, m = grid[0].Length;
        char start = target[0];

        if (target.Length > n*m) return false;

        bool bt(int x, int y, bool[,] seen, int nextIdx)
        {
            if (nextIdx >= target.Length)
                return true;

            foreach(var (dx, dy) in dirs)
            {
                int newX = x + dx, newY = y + dy;

                if (newX >= n || newX < 0
                || newY >= m || newY < 0)
                    continue;

                if (grid[newX][newY] != target[nextIdx])
                    continue;

                if (seen[newX, newY]) continue;
                seen[newX, newY] = true;

                if (bt(newX, newY, seen, nextIdx + 1))
                    return true;

                seen[newX, newY] = false;
            }

            return false;
        }
        
        for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
        {
            if (grid[i][j] != start)
                continue;

            var seen = new bool[n,m];
            seen[i,j] = true;

            if (bt(i, j, seen, 1))
                return true;
        }

        return false;
    }
}