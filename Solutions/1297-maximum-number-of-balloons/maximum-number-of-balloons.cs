public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        Dictionary<char, int> counts = [];
        int balloons = int.MaxValue;
        const string balon = "balon";

        foreach(char c in text)
            counts[c] = counts.GetValueOrDefault(c) + 1;

        int[] relevantLetters = [
            counts.GetValueOrDefault('b'),
            counts.GetValueOrDefault('a'),
            counts.GetValueOrDefault('l') / 2,
            counts.GetValueOrDefault('o') / 2,
            counts.GetValueOrDefault('n'),
        ];

        for (int i = 0; i < balon.Length; i++)
            balloons = Math.Min(balloons, relevantLetters[i]);

        return balloons;
    }
}