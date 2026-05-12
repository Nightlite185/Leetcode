public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head is null) return null;

        ListNode prev = null;
        var curr = head;

        while (curr is not null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}