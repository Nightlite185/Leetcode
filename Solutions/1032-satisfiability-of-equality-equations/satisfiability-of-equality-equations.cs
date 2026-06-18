public class Solution
{
    const int CharsArrSize = 27;
    public bool EquationsPossible(string[] equations)
    {
        var graph = new bool[CharsArrSize][];
        var inequalities = new List<string>();
        
        for (int i = 0; i < CharsArrSize; i++)
            graph[i] = new bool[CharsArrSize];

        foreach(string eq in equations)
        {
            var (var1, var2) = GetVariablesAsInts(eq);

            if (eq[1] == '=')
            {
                graph[var1][var2] = true;

                if (var1 != var2)
                    graph[var2][var1] = true;
            }

            else inequalities.Add(eq);
        }

        foreach (string ineq in inequalities)
        {
            var (var1, var2) = GetVariablesAsInts(ineq);
            var seen = new bool[CharsArrSize];

            if (!dfs(var1, var2, seen)) return false;
        }

        return true;

        bool dfs(int var1Const, int var2, bool[] charsSeen)
        {
            if (var2 == var1Const) return false;
            var arr = graph[var2];

            for (int i = 0; i < CharsArrSize; i++)
            {
                if (!arr[i] || charsSeen[i]) continue;
                charsSeen[i] = true;

                if (!dfs(var1Const, i, charsSeen))
                    return false;
            }

            return true;
        }
    }

    private static (int var1, int var2) GetVariablesAsInts(string equation)
        => (equation[0] - 'a', equation[3] - 'a');
}