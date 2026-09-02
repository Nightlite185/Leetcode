public class Solution
{
    const int N = 9;
    public bool IsValidSudoku(char[][] board)
    {
        var cols = new HashSet<char>[N];
        var boxes = new HashSet<char>[3];

        for (int r = 0; r < N; r++)
        {
            var row = new HashSet<char>(capacity: N);

            for (int c = 0; c < N; c++)
            {
                char num = board[r][c];
                if (num == '.') continue;

                int boxNum = c / 3;
                cols[c]       ??= new(capacity: N);
                boxes[boxNum] ??= new(capacity: N);
                
                if (!row.Add(num)
                 || !cols[c].Add(num)
                 || !boxes[boxNum].Add(num))
                {
                    return false;
                }
            }

            // 0 or 2 or 5 bc we only keep 3 boxes at once.
            // so when we're done iterating over those, we clear them out.
            if (r is 2 or 5)
            {
                for (int i = 0; i < 3; i++)
                    boxes[i]?.Clear();
            }
        }

        return true;
    }
}