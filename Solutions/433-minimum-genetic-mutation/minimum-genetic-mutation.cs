public class Solution
{
    const char A = 'A', C = 'C', G = 'G', T = 'T';
    const int GeneLength = 8;
    public int MinMutation(string startGene, string target, string[] validGenes)
    {
        if (startGene == target) return 0;
        if (validGenes.Length == 0) return -1;

        HashSet<string> seen = [];
        HashSet<string> validSet = [..validGenes];
        Queue<string> queue = [];
        queue.Enqueue(startGene);
        int currLvl = -1;

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            currLvl++;

            for (int i = 0; i < lvlSize; i++)
            {
                string gene = queue.Dequeue();

                foreach(string neighbor in GetNeighbors(gene))
                {
                    if (!validSet.Contains(neighbor))
                        continue;

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

    private static IEnumerable<string> GetNeighbors(string gene)
    {
        var mutableGene = gene.ToCharArray();
        char[] variations;
        
        for (int i = 0; i < GeneLength; i++)
        {
            char og = gene[i];

            variations = og switch
            {
                A => [C, T, G],
                C => [A, T, G],
                T => [A, G, C],
                G => [C, T, A],

                _ => throw new ArgumentOutOfRangeException(gene)
            };
        
            foreach(char other in variations)
            {
                mutableGene[i] = other;
                yield return new string(mutableGene);

                mutableGene[i] = og;
            }
        }
    }
}