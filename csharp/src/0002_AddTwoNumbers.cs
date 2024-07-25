using System.Diagnostics.CodeAnalysis;

public class ListNode
{
    public int val { get; set; }
    public ListNode? next { get; set; }

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public record struct AddTwoNumbersSolution
{
    public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2, int carry = 0)
    {
        if (l1 == null && l2 == null && carry == 0)
            return null;

        var total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
        carry = total / 10;

        return new ListNode(total % 10, AddTwoNumbers(l1?.next, l2?.next, carry));
    }
}

public class ListNodeEqualityComparer : IEqualityComparer<ListNode>
{
    public bool Equals(ListNode? x, ListNode? y)
    {
        while (x != null && y != null)
        {
            if (x.val != y.val)
                return false;
            x = x.next;
            y = y.next;
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
        var solution = new AddTwoNumbersSolution();

        Assert.True(
            new ListNodeEqualityComparer().Equals(expected, solution.AddTwoNumbers(l1, l2))
        );
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new ListNode[]
        {
            new ListNode(2, new ListNode(3, new ListNode(1))),
            new ListNode(2),
            new ListNode(4, new ListNode(3, new ListNode(1)))
        };

        yield return new ListNode[]
        {
            new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(4))),
            new ListNode(7, new ListNode(0, new ListNode(8)))
        };
    }
}
