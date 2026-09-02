public class Solution
{
    public IList<int> SpiralOrder(int[][] grid)
    {
        int r = 0, c = 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int n = rows * cols;
        var output = new List<int>(capacity: n);
        int dir = 0;

        while (true)
        {
            output.Add(grid[r][c]);

            if (output.Count == n)  
                break;

            grid[r][c] = int.MinValue;
            Move();
        }

        return output;

        void Move()
        {
            (int r, int c) next = dir switch
            {
                0 => new(r, c+1), // right
                1 => new(r+1, c), // down
                2 => new(r, c-1), // left
                3 => new(r-1, c)  // up
            };

            // if already been there
            if (!inBounds(next.r, next.c) || grid[next.r][next.c] == int.MinValue)
            {
                // we flip the direction, modulo for wrap around.
                dir = (dir + 1) % 4;
                Move();
            }

            else
            {
                r = next.r;
                c = next.c;
            }
        }

        bool inBounds(int x, int y)
        {
            return x >= 0   && y >= 0
                && x < rows && y < cols;
        }
    }
}