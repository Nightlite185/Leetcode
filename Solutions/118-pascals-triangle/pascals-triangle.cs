public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        int[][] triangle = new int[numRows][];
        triangle[0] = [1];
        if (numRows == 1) return triangle;
        triangle[1] = [1,1];

        for (int r = 3; r <= numRows; r++)
        {
            var currRow = triangle[r-1] = new int[r];
            var upperRow = triangle[r-2];
            int bound = r-2;
            
            // prefilling 0th and last idx with ones
            currRow[^1] = currRow[0] = 1;
            
            for (int add2 = 1; add2 <= bound; add2++)
            {
                int add1 = add2 - 1;
                int write = add2;

                currRow[write] = upperRow[add1] + upperRow[add2];
            }
        }

        return triangle;
    }
}