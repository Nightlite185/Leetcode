public class Solution
{
    public ListNode? RemoveNthFromEnd(ListNode? head, int n)
    {
        var dummy = new ListNode(0, head);
        ListNode? fast = dummy, slow = dummy;

        // <= and not < so slow ptr lands on node right before the one to delete.
        for (int i = 0; i <= n; i++)
            fast = fast?.next;

        while (fast is not null)
        {
            fast = fast?.next;
            slow = slow?.next;
        }

        slow!.next = slow.next?.next;

        return dummy?.next;
    }
}