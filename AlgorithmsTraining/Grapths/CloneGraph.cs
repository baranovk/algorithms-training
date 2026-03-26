namespace AlgorithmsTraining.Grapths
{
    /*
     * 133. Clone Graph
        
       Given a reference of a node in a connected undirected graph.

       Return a deep copy (clone) of the graph.

       Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

       Test case format:

       For simplicity, each node's value is the same as the node's index (1-indexed). For example, the first 
       node with val == 1, the second node with val == 2, and so on. The graph is represented in the test case 
       using an adjacency list.
       
       An adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes 
       the set of neighbors of a node in the graph.
       
       The given node will always be the first node with val = 1. You must return the copy of the given node as 
       a reference to the cloned graph.

       Example 1:

       Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
       Output: [[2,4],[1,3],[2,4],[1,3]]
       Explanation: There are 4 nodes in the graph.
       1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
       2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
       3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
       4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

       Example 2:

       Input: adjList = [[]]
       Output: [[]]
       Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.
       
       Example 3:
       
       Input: adjList = []
       Output: []
       Explanation: This an empty graph, it does not have any nodes.
       
       Constraints:
       
          [1] The number of nodes in the graph is in the range [0, 100].
          [2] 1 <= Node.val <= 100
          [3] Node.val is unique for each node.
          [4] There are no repeated edges and no self-loops in the graph.
          [5] The Graph is connected and all nodes can be visited starting from the given node.

          Runtime
          121 ms
          Beats 92.68%

          Memory
          47.71 MB
          Beats 69.78%
     */
    public static class CloneGraph
    {
        public static Node Solution(Node node)
        {
            var visitMemo = new VisitMemo();
            return Traverse(node, [], ref visitMemo);
        }

        private static Node Traverse(Node node, Dictionary<int, Node> clones, ref VisitMemo visitMemo)
        {
            if (null == node) { return null; }
            if (WasVisited(node.val, ref visitMemo)) { return clones[node.val]; }

            var clone = clones[node.val] = new Node(node.val);
            MarkVisited(node.val, ref visitMemo);

            for (int i = 0; i < node.neighbors.Count; i++)
            {
                var neighborClone = Traverse(node.neighbors[i], clones, ref visitMemo);
                clone.neighbors.Add(neighborClone);
            }
            
            return clone;
        }

        private static bool WasVisited(int i, ref VisitMemo visitMemo)
        {
            return 0 < ((i <= 64 ? visitMemo.Segment1 : visitMemo.Segment2) & (i <= 64 ? 1L << (i - 1) : 1L << (i - 65)));
        }

        private static void MarkVisited(int i, ref VisitMemo visitMemo)
        {
            if (i <= 64) { visitMemo.Segment1 |= 1L << (i - 1); } else { visitMemo.Segment2 |= 1L << (i - 65); }
        }

        private struct VisitMemo { public long Segment1; public long Segment2; }
    }
}
