using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Trees;

namespace Problems.Tests.Trees
{
    [TestClass]
    public class TreeUtilsTests
    {
        [TestMethod]
        public void BuildTreeExtendedTest_1()
        {
            var values = new object[] { 1, 2, 3, null, 4, null, 5 };
            var root = TreeUtils.BuildBinaryTreeExt(values);

            var node = TreeUtils.First(root, n => n.val == 2);
            Assert.AreEqual(node.level, 1);
            Assert.AreEqual(node.parent, root);
            var parent = node;

            node = TreeUtils.First(root, n => n.val == 4);
            Assert.AreEqual(node.level, 2);
            Assert.AreEqual(node.parent, parent);

            node = TreeUtils.First(root, n => n.val == 3);
            Assert.AreEqual(node.level, 1);
            Assert.AreEqual(node.parent, root);
            parent = node;

            node = TreeUtils.First(root, n => n.val == 5);
            Assert.AreEqual(node.level, 2);
            Assert.AreEqual(node.parent, parent);
        }
    }
}
