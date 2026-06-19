public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length, cols = matrix[0].Length;
        int right = rows * cols - 1, left = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int row = mid / cols, col = mid % cols;
            int num = matrix[row][col];

            if (num == target)
                return true;

            else if (num > target)
                right = mid - 1;

            else left = mid + 1;
        }

        return false;
    }
}