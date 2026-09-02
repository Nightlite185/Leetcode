public class Solution
{
    public void SetZeroes(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        bool firstRow0 = false;
        
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0)
                {
                    if (r == 0) firstRow0 = true;
                    else grid[r][0] = 0;

                    grid[0][c] = 0;
                }
            }
        }

        for (int r = 1; r < rows; r++)
            for (int c = 1; c < cols; c++)
                if (grid[0][c] == 0 || grid[r][0] == 0)
                    grid[r][c] = 0;

        if (grid[0][0] == 0) 
            for (int r = 0; r < rows; r++)
                grid[r][0] = 0;

        if (firstRow0)
        {
            for (int c = 0; c < cols; c++)
                grid[0][c] = 0;
        }
    }
}