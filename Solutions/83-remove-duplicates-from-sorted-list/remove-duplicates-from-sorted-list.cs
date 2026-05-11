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
            {
                behind.next = dummy.next;
                dummy = dummy.next;
            }

            else
            {
                dummy = dummy.next;
                behind = behind.next;
            }
        }

        return head!;
    }
}