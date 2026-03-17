using AlgorithmsTraining.Grapths;

namespace AlgorithmsTraining.Tests.Graphs
{
    internal static class GraphUtils
    {
        public static Node BuildGraph(int[][] adjacencyList, int returnNodeVal = 1)
        {
            if (0 == adjacencyList.Length) { return null; }

            var memo = new Dictionary<int, Node>();

            for (int i = 0; i < adjacencyList.Length; i++)
            {
                var node1 = memo.TryGetValue(adjacencyList[i][0], out Node? value1) ? value1 : new Node(adjacencyList[i][0]);
                var node2 = memo.TryGetValue(adjacencyList[i][1], out Node? value2) ? value2 : new Node(adjacencyList[i][1]);

                node1.neighbors.Add(node2);
                node2.neighbors.Add(node1);

                memo.TryAdd(node1.val, node1);
                memo.TryAdd(node2.val, node2);
            }

            return memo.TryGetValue(returnNodeVal, out var node) 
                ? node : throw new ArgumentException(nameof(returnNodeVal));
        }

        public static int[][] BuildConnectedGraphAdjacencyList(Node node)
        {
            var adjacencyList = new List<int[]>();
            var touched = new HashSet<int>();
            var visited = new HashSet<int>();
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (0 < queue.Count)
            {
                var current = queue.Dequeue();

                foreach (var neighbor in current.neighbors)
                {
                    if (!visited.Contains(neighbor.val))
                    {
                        adjacencyList.Add([current.val, neighbor.val]);
                        if (!touched.Contains(neighbor.val)) { queue.Enqueue(neighbor); }
                        touched.Add(neighbor.val);
                    }
                }

                visited.Add(current.val);
            }

            return [.. adjacencyList];
        }
    }
}
