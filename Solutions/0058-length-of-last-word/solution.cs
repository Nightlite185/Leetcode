public class Solution {
    public int LengthOfLastWord(string sentence)
    {
        int count = 0;
        int i = sentence.Length -1;

        while (i >= 0 && sentence[i] == ' ')
            i--;

        while (i >= 0 && sentence[i] != ' ')
        {
            i--;
            count++;
        }

        return count;
    }
}
