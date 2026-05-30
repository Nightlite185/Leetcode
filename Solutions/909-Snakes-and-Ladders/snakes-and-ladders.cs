public class Solution
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length, maxSq = n*n;
        int currLvl = -1;
        bool[] seen = new bool[maxSq + 1];
        Queue<int> queue = [];
        seen[1] = true;
        queue.Enqueue(1);
        var flat = FlattenBoard(board);

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlSize; i++)
            {
                int curr = queue.Dequeue();

                for (int j = 1; j <= 6; j++)
                {
                    int sqAhead = curr + j;
                    int dest = flat[Math.Min(sqAhead, maxSq)];
                    
                    if (sqAhead == maxSq || dest == maxSq)
                        return currLvl + 1;

                    int enqueuable = dest == -1 
                        ? sqAhead : dest;

                    if (seen[enqueuable]) continue;
                    seen[enqueuable] = true;
                    queue.Enqueue(enqueuable);
                }
            }
        }

        return -1;
    }

    private static List<int> FlattenBoard(int[][] board)
    {
        int n = board.Length;
        bool rightToLeft = true;
        List<int> list = new(capacity: n * n + 1)
            { int.MinValue };

        for (int i = n-1; i >= 0; i--)
        {
            if (rightToLeft)
                list.AddRange(board[i]);

            else list.AddRange(board[i].Reverse());

            rightToLeft = !rightToLeft;
        }

        return list;
    }
}