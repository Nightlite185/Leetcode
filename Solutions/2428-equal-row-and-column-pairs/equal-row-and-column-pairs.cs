using System.Diagnostics.CodeAnalysis;
public class Solution
{
    private class ArrComparer: IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
            => x.SequenceEqual(y);

        public int GetHashCode([DisallowNull] int[] obj)
        {
            HashCode hash = new();

            foreach(int num in obj)
                hash.Add(num);

            return hash.ToHashCode();
        }
    }
    
    public int EqualPairs(int[][] grid)
    {
        Dictionary<int[], int> rows = new(new ArrComparer());
        int pairs = 0;

        foreach (int[] row in grid)
            rows[row] = rows.GetValueOrDefault(row) + 1;

        for (int i = 0; i < grid.Length; i++)
        {
            int[] col = new int[grid.Length];

            for (int j = 0; j < grid.Length; j++)
                col[j] = grid[j][i];

            if (rows.TryGetValue(col, out int matchRows))
                pairs += matchRows;
        }

        return pairs;
    }
}