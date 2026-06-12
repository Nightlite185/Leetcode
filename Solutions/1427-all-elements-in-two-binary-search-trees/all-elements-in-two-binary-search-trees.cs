public class Solution
{
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        var enum1 = InOrderEnumerate(root1).GetEnumerator();

        if (!enum1.MoveNext())
            return [..InOrderEnumerate(root2)];

        var enum2 = InOrderEnumerate(root2).GetEnumerator();

        if (!enum2.MoveNext())
            return [..InOrderEnumerate(root1)];
        
        List<int> ans = [];

        while (true)
        {
            if (enum1.Current <= enum2.Current)
            {
                ans.Add(enum1.Current);

                if (!enum1.MoveNext())
                {
                    ans.Add(enum2.Current);

                    while (enum2.MoveNext())
                        ans.Add(enum2.Current);

                    break;
                }
            }

            else
            {
                ans.Add(enum2.Current);

                if (!enum2.MoveNext())
                {
                    ans.Add(enum1.Current);

                    while (enum1.MoveNext())
                        ans.Add(enum1.Current);

                    break;
                }
            }
        }

        return ans;
    }

    private static IEnumerable<int> InOrderEnumerate(TreeNode? node)
    {
        if (node is null) yield break;

        foreach(int num in InOrderEnumerate(node.left))
            yield return num;

        yield return node.val;

        foreach(int num in InOrderEnumerate(node.right))
            yield return num;
    }

}