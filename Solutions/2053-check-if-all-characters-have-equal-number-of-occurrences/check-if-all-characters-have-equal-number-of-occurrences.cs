public class Solution
{
    public bool AreOccurrencesEqual(string s)
    {
        return s.CountBy(c => c)
            .Select(c => c.Value)
            .ToHashSet().Count == 1;
    }
}