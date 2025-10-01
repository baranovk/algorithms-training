using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees;

internal class TreeTraversalTests
{
    [Test]
    public void BreadthFirstTraversal_Test_1()
    {
        var values = new object[] { 1, 2, 3, 4, 5, 6, 7 };
        var root = TreeUtils.BuildBinaryTree(values);
        var crawler = new BreadthFirstTreeCrawler(root);
        var expected = new object[] { 1, 2, 3, 4, 5, 6, 7, null, null, null, null, null, null, null, null };
        var values2 = new object[expected.Length];
        var index = -1;

        foreach (var node in crawler)
        {
            values2[++index] = node?.val;
        }

        Assert.That(values2, Is.EquivalentTo(expected));
    }

    [Test]
    public void BreadthFirstTraversal_Test_2()
    {
        var values = new object[] { 1, 2, null, null, 3, null, 5 };
        var root = TreeUtils.BuildBinaryTree(values);
        var crawler = new BreadthFirstTreeCrawler(root);
        var expected = new object[] { 1, 2, null, null, 3, null, 5, null, null };
        var values2 = new object[expected.Length];
        var index = -1;

        foreach (var node in crawler)
        {
            values2[++index] = node?.val;
        }

        Assert.That(values2, Is.EquivalentTo(expected));
    }

    [Test]
    public void DepthFirstTraversal_Test_1()
    {
        var values = new object[] { 1, 2, 3, 4, 5, 6, 7 };
        var root = TreeUtils.BuildBinaryTree(values);
        var crawler = new BreadthFirstTreeCrawler(root);
        var expected = new object[] { 1, 2, 4, null, null, 5, null, null, 3, 6, null, null, 7, null, null };
        var values2 = new object[expected.Length];
        var index = -1;

        foreach (var node in crawler)
        {
            values2[++index] = node?.val;
        }

        Assert.That(values2, Is.EquivalentTo(expected));
    }

    [Test]
    public void DepthFirstTraversal_Test_2()
    {
        var values = new object[] { 1, 2, null, null, 3, null, 5 };
        var root = TreeUtils.BuildBinaryTree(values);
        var crawler = new BreadthFirstTreeCrawler(root);
        var expected = new object[] { 1, 2, null, 3, null, 5, null, null, null };
        var values2 = new object[expected.Length];
        var index = -1;

        foreach (var node in crawler)
        {
            values2[++index] = node?.val;
        }

        Assert.That(values2, Is.EquivalentTo(expected));
    }
}
