namespace csharp.src;

public class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}

public record struct AddTwoNumbersSolution
{
    public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2, int carry = 0)
    {
        if (l1 == null && l2 == null && carry == 0)
        {
            return null;
        }

        var total = (l1 != null ? l1.Val : 0) + (l2 != null ? l2.Val : 0) + carry;
        carry = total / 10;

        return new ListNode(total % 10, AddTwoNumbers(l1?.Next, l2?.Next, carry));
    }
}

public class ListNodeEqualityComparer : IEqualityComparer<ListNode>
{
    public bool Equals(ListNode? x, ListNode? y)
    {
        while (x != null && y != null)
        {
            if (x.Val != y.Val)
            {
                return false;
            }

            x = x.Next;
            y = y.Next;
        }

        return x == null && y == null;
    }

    public int GetHashCode([DisallowNull] ListNode obj)
    {
        throw new NotImplementedException();
    }
}

public class AddTwoNumbersSolutionTests
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Tests(ListNode l1, ListNode l2, ListNode expected)
    {
        Assert.True(
            new ListNodeEqualityComparer().Equals(
                expected,
                AddTwoNumbersSolution.AddTwoNumbers(l1, l2)
            )
        );
    }

    public static TheoryData<ListNode, ListNode, ListNode> GetTestData =>
        new()
        {
            {
                new ListNode(2, new ListNode(3, new ListNode(1))),
                new ListNode(2),
                new ListNode(4, new ListNode(3, new ListNode(1)))
            },
            {
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))),
                new ListNode(7, new ListNode(0, new ListNode(8)))
            },
        };
}
