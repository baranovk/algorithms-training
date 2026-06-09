namespace AlgorithmsTraining.Misc
{
    /*
     * 146. LRU Cache
     * 
     * Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

     Implement the LRUCache class:
     
         [1] LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
         [2] int get(int key) Return the value of the key if the key exists, otherwise return -1.
         [3] void put(int key, int value) Update the value of the key if the key exists. Otherwise,
             add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation,
             evict the least recently used key.
     
     The functions get and put must each run in O(1) average time complexity.

     Example 1:

     Input
     ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
     [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
     Output
     [null, null, null, 1, null, -1, null, -1, 3, 4]
     
     Explanation
     LRUCache lRUCache = new LRUCache(2);
     lRUCache.put(1, 1); // cache is {1=1}
     lRUCache.put(2, 2); // cache is {1=1, 2=2}
     lRUCache.get(1);    // return 1
     lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
     lRUCache.get(2);    // returns -1 (not found)
     lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
     lRUCache.get(1);    // return -1 (not found)
     lRUCache.get(3);    // return 3
     lRUCache.get(4);    // return 4
     
     Constraints:
     
        [1] 1 <= capacity <= 3000
        [2] 0 <= key <= 10^4
        [3] 0 <= value <= 10^5
        [4] At most 2 * 10^5 calls will be made to get and put.

        Runtime
        35 ms
        Beats 36.87%

        Memory
        175.02 MB
        Beats 36.87%

     */
    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
        private readonly LinkedList<KeyValuePair<int, int>> _list = new();

        public LRUCache(int capacity)
        {
            _cache = new(_capacity = capacity);
        }

        public int Get(int key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                if (null != node.Next)
                {
                    _list.Remove(node);
                    _list.AddLast(node);
                }

                return node.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _list.Remove(node);
                _list.AddLast(node);
                node.Value = new(key, value);
            }
            else if (_cache.Count == _capacity)
            {
                _cache.Remove(_list.First().Key);
                _cache[key] = new(new(key, value));
                _list.RemoveFirst();
                _list.AddLast(_cache[key]);
            }
            else
            {
                _cache[key] = new(new(key, value));
                _list.AddLast(_cache[key]);
            }
        }
    }
}
