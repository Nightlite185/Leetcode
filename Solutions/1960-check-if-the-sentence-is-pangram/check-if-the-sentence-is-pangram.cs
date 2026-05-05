public class Solution
{
    const byte EngLettersCount = 26;
    
    public bool CheckIfPangram(string sentence)
        => sentence.ToHashSet().Count == EngLettersCount;
}