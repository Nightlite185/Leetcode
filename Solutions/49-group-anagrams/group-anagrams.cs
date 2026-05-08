public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] words)
    {
        if (words.Length == 0) return [];

        Dictionary<string, List<string>> wordMap = [];

        foreach(string word in words)
        {
            var ordered = new string([..word.Order()]);

            if (wordMap.TryGetValue(ordered, out var anagrams))
                anagrams.Add(word);

            else wordMap[ordered] = [word];
        }

        return [..wordMap.Values];
    }
}