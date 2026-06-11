public class Solution
{
    public int GetDecimalValue(ListNode? head)
    {
        int num = 0;

        while (head is not null)
        {
            num = (num << 1) | head.val;
            head = head?.next;
        }

        return num;
    }
}