using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists;

internal class RotateListTests
{
    [Test]
    public void RotateList_Test_1()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        head = RotateList.RotateRight(head, 2);
        
        Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 4);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 5);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 1);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 2);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 4), 3);
    }

    [Test]
    public void RotateList_Test_2()
    {
        var head = new ListNode(0, new ListNode(1, new ListNode(2)));
        head = RotateList.RotateRight(head, 4);

        Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 2);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 0);
        Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 1);
    }
}
