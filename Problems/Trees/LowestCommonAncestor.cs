using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Trees
{
    /*
     * https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
     *
     * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

       According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the 
       lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”
     */
    public class LowestCommonAncestor
    {
        public static TreeNode Solution(TreeNode root, TreeNode p, TreeNode q)
        {
            var currentLevel = 0;
            var treeLevels = new Dictionary<int, IList<TreeNode>> { { currentLevel, new List<TreeNode> { root } } };

            var addToTreeLevel = new Action<TreeNode, int>((node, level) => {
                if (!treeLevels.ContainsKey(level))
                {
                    treeLevels.Add(level, new List<TreeNode>());
                }
                treeLevels[level].Add(node);
            });
            
            var pLevel = root == p ? 0 : -1;
            var qLevel = root == q ? 0 : -1;

            while (pLevel < 0 || qLevel < 0)
            {
                foreach (var node in treeLevels[currentLevel])
                {
                    if (pLevel < 0 && node == p) pLevel = currentLevel;
                    if (qLevel < 0 && node == q) qLevel = currentLevel;

                    if (null != node.left) addToTreeLevel(node.left, currentLevel + 1);
                    if (null != node.right) addToTreeLevel(node.right, currentLevel + 1);
                }

                currentLevel++;
            }

            var pAncestor = p;
            var qAncestor = q;

            var findAncestor = new Func<int, TreeNode, TreeNode>((level, current) =>
            {
                if (!treeLevels.ContainsKey(--level)) return current;

                foreach (var node in treeLevels[level])
                {
                    if (null != node && (node.left == current || node.right == current)) return node;
                }

                return current;
            });

            while (pLevel > qLevel)
            {
                pAncestor = findAncestor(pLevel, pAncestor);
                pLevel--;
            }

            while (qLevel > pLevel)
            {
                qAncestor = findAncestor(qLevel, qAncestor);
                qLevel--;
            }

            currentLevel = (pLevel = qLevel) + 1;

            while (pAncestor != qAncestor)
            {
                currentLevel--;
                pAncestor = findAncestor(currentLevel, pAncestor);
                qAncestor = findAncestor(currentLevel, qAncestor); 
            }

            return pAncestor;
        }

        public static TreeNodeExt Solution(TreeNodeExt root, TreeNodeExt p, TreeNodeExt q)
        {
            var pAncestor = p;
            var qAncestor = q;

            while (pAncestor.level > qAncestor.level) pAncestor = pAncestor.parent;
            while (qAncestor.level > pAncestor.level) qAncestor = qAncestor.parent;

            while (pAncestor != qAncestor)
            {
                pAncestor = pAncestor.parent;
                qAncestor = qAncestor.parent;
            }

            return pAncestor;
        }
    }
}
