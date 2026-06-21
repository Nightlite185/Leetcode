public class Solution
{
    public int MaximizeSweetness(int[] nums, int cuts)
    {
        int maxPieces = cuts + 1;
        int right = nums.Sum();
        int left = 1;

        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;

            if (check(mid)) left = mid;

            else right = mid - 1;
        }

        return right;

        bool check(int minSum)
        {
            int piecesCount = 0;
            int pieceSum = 0;

            foreach(int num in nums)
            {
                pieceSum += num;

                if (pieceSum >= minSum)
                {
                    piecesCount++;
                    pieceSum = 0;
                }
            }

            return piecesCount >= maxPieces;
        }
    }
}