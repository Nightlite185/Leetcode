using System.Text;

public class Solution
{
    public int EqualPairs(int[][] grid)
    {
        Dictionary<string, int> rows = [], cols = [];
        StringBuilder sb = new();
        int pairs = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            // adding the row to dict
            string strRow = string.Join(',', grid[i]);
            rows[strRow] = rows.GetValueOrDefault(strRow) + 1;
            
            // adding column to dict
            for (int j = 0; j < grid.Length; j++)
                sb.Append(grid[j][i])
                .Append(',');

            sb.Remove(sb.Length - 1, 1); // removing that last comma

            string column = sb.ToString();
            cols[column] = cols.GetValueOrDefault(column) + 1;

            sb.Clear();
        }

        foreach (var row in rows)
        {
            if (cols.TryGetValue(row.Key, out int colCount))
                pairs += (row.Value * colCount);
        }

        return pairs;
    }
}