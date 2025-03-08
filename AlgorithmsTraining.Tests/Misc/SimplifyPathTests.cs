using AlgorithmsTraining.Misc;

namespace AlgorithmsTraining.Tests.Misc;

internal class SimplifyPathTests
{
    [TestCase("/", "/")]
    [TestCase("/test", "/test")]
    [TestCase("/test/..", "/")]
    [TestCase("/home/", "/home")]
    [TestCase("/home//foo/", "/home/foo")]
    [TestCase("/home/user/Documents/../Pictures", "/home/user/Pictures")]
    [TestCase("/../", "/")]
    [TestCase("/.../a/../b/c/../d/./", "/.../b/d")]
    [TestCase("///test", "/test")]
    [TestCase("///test//test1", "/test/test1")]
    [TestCase("///test/test1//..", "/test")]
    [TestCase("///test/test1//../test2/...//test3", "/test/test2/.../test3")]
    [TestCase("/..hidden", "/..hidden")]
    [TestCase("/.hidden", "/.hidden")]
    [TestCase("/...hidden", "/...hidden")]
    [TestCase("/hello../world", "/hello../world")]
    public void Solution_Should_SimplifyPaths(string path, string resultPath)
    {
        Assert.That(SimplifyPath.Solution(path), Is.EqualTo(resultPath));
    }
}
