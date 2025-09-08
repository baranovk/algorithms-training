using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists;

internal class RemoveDuplicatesFromSortedListIITests
{
    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_1()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3)));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(3));
    }

    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_2()
    {
        var head = new ListNode(1, new ListNode(1, new ListNode(1)));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(head, Is.Null);
    }

    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_3()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(3))));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(3));
    }

    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_4()
    {
        var head = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3))));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(3));
    }

    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_5()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(4, new ListNode(4, new ListNode(5)))))));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(5));
    }

    [Test]
    public void RemoveDuplicatesFromSortedListII_Test_6()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(4, new ListNode(4, new ListNode(5)))))));
        head = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(5));
    }
}
