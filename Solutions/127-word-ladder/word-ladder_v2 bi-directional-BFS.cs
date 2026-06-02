public class Solution
{
    public int LadderLength(string beginWord, string target, IList<string> wordList)
    {
        HashSet<string> beginSet = [beginWord], endSet = [target], valid = [..wordList];
        int currLvl = -1;

        while(beginSet.Count > 0 && endSet.Count > 0)
        {
            currLvl++;

            if (endSet.Count > beginSet.Count)
                (beginSet, endSet) = (endSet, beginSet);

            var newBeginSet = new HashSet<string>();

            foreach(string word in beginSet)
            {
                if (endSet.Contains(word))
                    return currLvl + 1;

                foreach(string nei in GetNeighbors(word))
                {
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