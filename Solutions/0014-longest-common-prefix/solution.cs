public class Solution
{
    public string LongestCommonPrefix(string[] strings)
    {
        string firstStr = strings.FirstOrDefault() ?? "";
        
        if (strings.Length == 1)
            return firstStr;

        for (int i = 0; true; i++)
        {
            char prev = firstStr.ElementAtOrDefault(i);

            if (prev == default(char))
                return firstStr[..i];

            foreach(string str in strings.Skip(1))
            {
                char c = str.ElementAtOrDefault(i);
                
                if (c != prev)
                    return firstStr[..i]; 
            }
        }
    }
}
