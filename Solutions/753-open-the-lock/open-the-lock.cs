public class Solution
{
    private const string StartingCode = "0000";
    public int OpenLock(string[] deadends, string target)
    {
        if (target == StartingCode) return 0;

        HashSet<string> seen = [..deadends];

        if (seen.Contains(target)
         || seen.Contains(StartingCode))
            return -1;


        Queue<string> queue = [];
        queue.Enqueue(StartingCode);
        seen.Add(StartingCode);
        int currLvl = -1;

        while(queue.Count > 0)
        {
            int lvlSize = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlSize; i++)
            {
                string code = queue.Dequeue();

                foreach(string neighbor in GenerateNeighbors(code))
                {
                    if (neighbor == target)
                        return currLvl + 1;

                    if (seen.Contains(neighbor))
                        continue;

                    seen.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return -1;
    }

    private static IEnumerable<string> GenerateNeighbors(string code)
    {
        var chars = code.ToCharArray();
        
        for (int i = 0; i < 4; i++)
        {
            char og = chars[i];

            chars[i] = Decrement(og);
            yield return new string(chars);

            chars[i] = Increment(og);
            yield return new string(chars);

            chars[i] = og;
        }
    }

    private static char Increment(char c)
    {
        int digit = c - '0';
        digit++;

        return (char)((digit % 10) + '0');
    }

    private static char Decrement(char c)
    {
        int digit = c - '0';
        digit += 9; // +9 instead of -1 to avoid negative modulo

        return (char)((digit % 10) + '0');
    }
}