public class Solution
{
    public int LadderLength(string beginWord, string target, IList<string> wordList)
    {
        HashSet<string> valid = [..wordList];
        if (!valid.Contains(target)) return 0;
        HashSet<string> beginSet = [beginWord], endSet = [target];

        int currLvl = 0;

        while(beginSet.Count > 0 && endSet.Count > 0)
        {
            currLvl++;

            if (endSet.Count > beginSet.Count)
                (beginSet, endSet) = (endSet, beginSet);

            var newBeginSet = new HashSet<string>();

            foreach(string word in beginSet)
            {
                foreach(string nei in GetNeighbors(word))
                {
                    if (endSet.Contains(nei))
                        return currLvl + 1;

                    if (valid.Remove(nei))
                        newBeginSet.Add(nei);
                }
            }

            beginSet = newBeginSet;
        }

        return 0;
    }

    private static IEnumerable<string> GetNeighbors(string word)
    {
        const int A = 'a', Z = 'z';
        var chars = word.ToCharArray();

        for (int i = 0; i < word.Length; i++)
        {
            char og = word[i];

            for (int charCode = A; charCode <= Z; charCode++)
            {
                if (charCode == og) continue;

                chars[i] = (char)charCode;
                yield return new string(chars);
            }

            chars[i] = og;
        }
    }
} 