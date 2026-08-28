using System.Text;

public class Solution
{
    private readonly StringBuilder sb = new();
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var output = new List<string>();

        int l = 0,
            n = words.Length,
            wordsLen = 0,
            totalLen = 0,
            wordsCount = 0;
        
        for (int r = 0; r < n; r++)
        {
            var w = words[r];
            
            if (totalLen + w.Length + (wordsCount + 1 > 1 ? 1 : 0) > maxWidth)
            {
                r--;

                output.Add(buildLine(l, r));
                
                wordsLen = 0;
                totalLen = 0;
                wordsCount = 0;
                l = r + 1;
            }

            else
            {
                wordsCount++;
                wordsLen += w.Length;
                totalLen += w.Length;

                if (r == n-1)
                    output.Add(buildLine(l, r));

                // adding space on the left of that newly added word.
                if (wordsCount > 1) totalLen++;
            }
        }

        return output;
        
        string buildLine(int left, int right)
        {
            int gaps = wordsCount - 1;
            
            if (right == n-1 || wordsCount == 1) // special case if align left
            {
                sb.AppendJoin(' ', words.AsSpan(left, wordsCount));
                sb.Append(' ', repeatCount: maxWidth - sb.Length);
            }

            else
            {
                int remSpace = maxWidth - wordsLen;
                int spacePerGap = remSpace / gaps;
                int specialGapCount = remSpace % gaps;

                for (int i = 0; i <= gaps; i++)
                {
                    int spaces = spacePerGap
                        + (i < specialGapCount ? 1 : 0);

                    sb.Append(words[left]);

                    if (left < right)
                        sb.Append(' ', repeatCount: spaces);

                    left++;
                }
            }

            string res = sb.ToString();
            sb.Clear();
            return res;
        }
    }
}