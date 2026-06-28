public class Solution
{
    public int TotalNQueens(int n)
    {
        int solutions = 0;
        HashSet<int> diags = [], antiDiags = [], cols = [];

        void bt(int row)
        {
            for (int col = 0; col < n; col++)
            {
                int diag = row + col;
                int antiDiag = row - col;

                if (diags.Contains(diag)
                || antiDiags.Contains(antiDiag)
                || cols.Contains(col))
                    continue;

                if (row == n - 1)
                {
                    solutions++;
                    return;
                }

                diags.Add(diag);
                antiDiags.Add(antiDiag);
                cols.Add(col);

                bt(row + 1);

                diags.Remove(diag);
                antiDiags.Remove(antiDiag);
                cols.Remove(col);
            }
        }

        bt(0);
        return solutions;
    }
}