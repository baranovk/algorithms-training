
namespace AlgorithmsTraining.Trees
{
    public class TreeNodeExt
    {
        public int val;
        public TreeNodeExt left;
        public TreeNodeExt right;
        public TreeNodeExt parent;
        public int level;

        public TreeNodeExt(int val = 0, TreeNodeExt parent = null, TreeNodeExt left = null, TreeNodeExt right = null, int level = 0)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.parent = parent;
            this.level = level;
        }
    }
}
