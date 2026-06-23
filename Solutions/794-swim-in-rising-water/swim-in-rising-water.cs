public class Solution
{
    private static readonly (int dx, int dy)[] dirs = [(0,1), (1,0), (0,-1), (-1,0)];
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length, right = n*n, left = 0;
        int exit = n-1;

        if (n == 1) return grid[0][0];

        while (left < right)
        {
            int maxSpendableTime = left + (right - left) / 2;

            if (check(maxSpendableTime))
                right = maxSpendableTime;

            else left = maxSpendableTime + 1;
        }

        return left;

        bool check(int maxTime)
        {
            int startingElev = grid[0][0];
            
            if (startingElev > maxTime)
                return false;

            var seen = new bool[n,n];

            bool dfs(int x, int y, int currTime)
            {
                foreach(var (dx, dy) in dirs)
                {
                    int newX = x + dx, newY = y + dy;

                    if (newX < 0 || newY < 0
                    ||  newX >= n || newY >= n)
                        continue;

                    int elev = grid[newX][newY];

                    if (elev > maxTime || seen[newX, newY])
                        continue;

                    seen[newX, newY] = true;

                    if (elev > currTime)
                        currTime = elev;
                        
                    if ((newX == exit && newY == exit)
                    || dfs(newX, newY, currTime))
                        return true;
                }

                return false;
            }

            return dfs(x: 0, y: 0, currTime: grid[0][0]);
        }
    }
}