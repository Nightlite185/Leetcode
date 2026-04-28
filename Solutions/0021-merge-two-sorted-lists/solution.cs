public class Solution
{
    public ListNode MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var dummy = new ListNode();
        var current = dummy;

        while (list1 is not null && list2 is not null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }

            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        // now that one of those lists has ran out of elements,
        // we just append the rest of the other one to current.
        current.next = (list1 is not null)
            ? list1
            : list2;

        return dummy.next!;
    }
}
