using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Trees
{
    public class HouseRobber_III
    {
        /*
           https://leetcode.com/problems/house-robber-iii/

           Links:
           https://leetcode.com/problems/house-robber-iii/discuss/499449/337-House-Robber-III-Py-All-in-One-By-Talse
           http://py-algorithm.blogspot.com/2011/09/blog-post_14.html
           https://translated.turbopages.org/proxy_u/en-ru.ru.6b9bc563-6268feb1-36b7f66a-74722d776562/https/en.wikipedia.org/wiki/Greedy_coloring#Algorithm
           http://urban-sanjoo.narod.ru/colours.html

         * The thief has found himself a new place for his thievery again. There is only one entrance to this area, called root.

           Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that all houses in this 
           place form a binary tree. It will automatically contact the police if two directly-linked houses were broken into on the same night.

           Given the root of the binary tree, return the maximum amount of money the thief can rob without alerting the police.

           Input: root = [3,2,3,null,3,null,1]
           Output: 7
           Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.

           Input: root = [3,4,5,1,3,null,1]
           Output: 9
           Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.

           Constraints:

           1. The number of nodes in the tree is in the range [1, 10^4].
           2. 0 <= Node.val <= 10^4

         */
        public static int Rob(TreeNode root)
        {
            return RobAsync(root, false).Result;
        }

        private static object _memoizationLocker = new object();
        private static Dictionary<int, Task<int>> _memoization = new Dictionary<int, Task<int>>();

        public static async Task<int> RobAsync(TreeNode currentNode, bool isPrevNodeRobbed, int sum = 0)
        {
            if (null == currentNode) return 0;

            if (isPrevNodeRobbed)
            {
                return sum + (await Task.WhenAll(RobAsync(currentNode.left, false), RobAsync(currentNode.right, false))).Sum();
            }

            // if NOT isPrevNodeRobbed we can:
            // 1. rob current node
            // 2. do NOT rob current node
            Task<int> robbedSumCalculationTask;
            Task<int> notRobbedSumCalculationTask;

            // 1. rob current node
            var hash = GetRobVariantHashCode(currentNode, true);

            lock (_memoizationLocker)
            {
                if (!_memoization.TryGetValue(hash, out robbedSumCalculationTask))
                {
                    robbedSumCalculationTask = Task.Run(
                        async () =>
                            currentNode.val + (await Task.WhenAll(RobAsync(currentNode.left, true), RobAsync(currentNode.right, true))).Sum()
                    );

                    _memoization.Add(hash, robbedSumCalculationTask);
                }
            }

            // 2. do NOT rob current node
            hash = GetRobVariantHashCode(currentNode, false);

            lock (_memoizationLocker)
            {
                if (!_memoization.TryGetValue(hash, out notRobbedSumCalculationTask))
                {
                    notRobbedSumCalculationTask = Task.Run(
                        async () => (await Task.WhenAll(RobAsync(currentNode.left, false), RobAsync(currentNode.right, false))).Sum()
                    );

                    _memoization.Add(hash, notRobbedSumCalculationTask);
                }
            }

            await Task.WhenAll(robbedSumCalculationTask, notRobbedSumCalculationTask);
            return sum + Math.Max(robbedSumCalculationTask.Result, notRobbedSumCalculationTask.Result);
        }

        private static int GetRobVariantHashCode(TreeNode node, bool isRobbed)
        {
            var hash = 861551;
            hash = hash * 563837 + node.GetHashCode();
            hash = hash * 563837 + node.val;
            hash = isRobbed ? hash * 51229 + 34939 : hash;
            return hash;
        }     
    }
}
