using AlgorithmsTraining.Lists;
using static AlgorithmsTraining.Tests.Lists.ListUtils;

namespace AlgorithmsTraining.Tests.Lists;

internal class ReverseLinkedListIITests
{
    [Test]
    public void ReverseLinkedListII_Test_1()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        head = ReverseLinkedListII.ReverseBetween(head, 2, 4);

        Assert.That(GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(GetNodeValue(head, 1), Is.EqualTo(4));
        Assert.That(GetNodeValue(head, 2), Is.EqualTo(3));
        Assert.That(GetNodeValue(head, 3), Is.EqualTo(2));
        Assert.That(GetNodeValue(head, 4), Is.EqualTo(5));
    }

    [Test]
    public void ReverseLinkedListII_Test_2()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        head = ReverseLinkedListII.ReverseBetween(head, 1, 3);

        Assert.That(GetNodeValue(head, 0), Is.EqualTo(3));
        Assert.That(GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(GetNodeValue(head, 2), Is.EqualTo(1));
        Assert.That(GetNodeValue(head, 3), Is.EqualTo(4));
        Assert.That(GetNodeValue(head, 4), Is.EqualTo(5));
    }

    [Test]
    public void ReverseLinkedListII_Test_3()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        head = ReverseLinkedListII.ReverseBetween(head, 3, 5);

        Assert.That(GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(GetNodeValue(head, 2), Is.EqualTo(5));
        Assert.That(GetNodeValue(head, 3), Is.EqualTo(4));
        Assert.That(GetNodeValue(head, 4), Is.EqualTo(3));
    }
}
