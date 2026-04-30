using System.Text;

public class Solution
{
    public string Convert(string s, int rowCount)
    {
        if (rowCount == 1 || s.Length <= rowCount) 
            return s;

        var sb = new StringBuilder();

        for (int row = 1; row <= rowCount; row++)
        {
            int idx = row - 1;

            bool edgeRow = (row == 1 || row == rowCount);
            bool belowMe = true;

            while (idx < s.Length)
            {
                sb.Append(s[idx]);

                if (edgeRow)
                    idx += (rowCount - 1) * 2;

                else
                {
                    idx += belowMe
                        ? (rowCount - row) * 2
                        : (row - 1) * 2;

                    belowMe = !belowMe;
                }
            }
        }

        return sb.ToString();
    }
}