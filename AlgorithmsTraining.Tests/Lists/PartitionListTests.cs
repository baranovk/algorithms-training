using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists;

internal class PartitionListTests
{
    [Test]
    public void PartitionList_Test_1()
    {
        var head = new ListNode(1, new ListNode(1, new ListNode(1)));
        head = PartitionList.Partition(head, 2);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(1));
    }

    [Test]
    public void PartitionList_Test_2()
    {
        var head = new ListNode(2, new ListNode(1, new ListNode(1)));
        head = PartitionList.Partition(head, 2);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(2));
    }

    [Test]
    public void PartitionList_Test_3()
    {
        var head = new ListNode(1, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(5, new ListNode(2))))));
        head = PartitionList.Partition(head, 3);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 2), Is.EqualTo(2));
        Assert.That(ListUtils.GetNodeValue(head, 3), Is.EqualTo(4));
        Assert.That(ListUtils.GetNodeValue(head, 4), Is.EqualTo(3));
        Assert.That(ListUtils.GetNodeValue(head, 5), Is.EqualTo(5));
    }

    [Test]
    public void PartitionList_Test_4()
    {
        var head = new ListNode(2, new ListNode(1));
        head = PartitionList.Partition(head, 2);

        Assert.That(ListUtils.GetNodeValue(head, 0), Is.EqualTo(1));
        Assert.That(ListUtils.GetNodeValue(head, 1), Is.EqualTo(2));
    }
}
