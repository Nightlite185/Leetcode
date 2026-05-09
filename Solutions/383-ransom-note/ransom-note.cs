using static System.Runtime.CompilerServices.Unsafe;
using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> charPool = new(magazine.Length);
        
        foreach(char c in magazine)
        {
            ref int value = ref GetValueRefOrAddDefault(
                charPool, c, out bool exists);

            value++;
        }

        foreach(char c in ransomNote)
        {
            ref int value = ref GetValueRefOrNullRef(charPool, c);
            
            if (IsNullRef(ref value) || value == 0)
                return false;

            value--;
        }

        return true;
    }
}