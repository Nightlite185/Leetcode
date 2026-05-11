public class Solution
{
    public ListNode? DeleteDuplicates(ListNode? head)
    {
        if (head is null) return head;

        var behind = head;
        var dummy = head?.next;

        while (dummy is not null && behind is not null)
        {
            if (behind.val == dummy.val)
                behind.next = dummy.next;

            else behind = behind.next;

            dummy = dummy.next;
        }

        return head!;
    }
}