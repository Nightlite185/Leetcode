public class Solution
{
    const int A = 'a', Z = 'z';
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (beginWord == endWord) return 0;
        
        HashSet<string> valid = [..wordList];

        if (!valid.Contains(endWord)) return 0;

        Queue<string> queue = [];
        queue.Enqueue(beginWord);
        int currLvl = 0;

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlSize; i++)
            {
                string word = queue.Dequeue();

                foreach (string nei in GetNeighbors(word))
                {
                    if (!valid.Remove(nei))
                        continue;

                    if (nei == endWord) 
                        return currLvl + 1;

                    queue.Enqueue(nei);
                }
            }
        }

        return 0;
    }

    private static IEnumerable<string> GetNeighbors(string word)
    {
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