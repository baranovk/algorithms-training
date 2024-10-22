using System.Collections.Generic;

namespace AlgorithmsTraining.Numbers
{
    public static class NumberOfSmallestUnoccupiedChair
    {
        #region Description

        /*
         * https://leetcode.com/problems/the-number-of-the-smallest-unoccupied-chair/description
         * There is a party where n friends numbered from 0 to n - 1 are attending. There is an infinite number of chairs in this 
         * party that are numbered from 0 to infinity. When a friend arrives at the party, they sit on the unoccupied chair with the smallest number.

           For example, if chairs 0, 1, and 5 are occupied when a friend comes, they will sit on chair number 2.

           When a friend leaves the party, their chair becomes unoccupied at the moment they leave. If another friend arrives at that same moment, 
           they can sit in that chair.

           You are given a 0-indexed 2D integer array times where times[i] = [arrivali, leavingi], indicating the arrival and leaving times 
           of the ith friend respectively, and an integer targetFriend. All arrival times are distinct.

           Return the chair number that the friend numbered targetFriend will sit on. 

           Example 1:

           Input: times = [[1,4],[2,3],[4,6]], targetFriend = 1
           Output: 1
           Explanation: 
           - Friend 0 arrives at time 1 and sits on chair 0.
           - Friend 1 arrives at time 2 and sits on chair 1.
           - Friend 1 leaves at time 3 and chair 1 becomes empty.
           - Friend 0 leaves at time 4 and chair 0 becomes empty.
           - Friend 2 arrives at time 4 and sits on chair 0.
           Since friend 1 sat on chair 1, we return 1.

           Example 2:

           Input: times = [[3,10],[1,5],[2,6]], targetFriend = 0
           Output: 2
           Explanation: 
           - Friend 1 arrives at time 1 and sits on chair 0.
           - Friend 2 arrives at time 2 and sits on chair 1.
           - Friend 0 arrives at time 3 and sits on chair 2.
           - Friend 1 leaves at time 5 and chair 0 becomes empty.
           - Friend 2 leaves at time 6 and chair 1 becomes empty.
           - Friend 0 leaves at time 10 and chair 2 becomes empty.
           Since friend 0 sat on chair 2, we return 2. 

           Constraints:

           n == times.length
           2 <= n <= 10^4
           times[i].length == 2
           1 <= arrival_i < leaving_i <= 10^5
           0 <= targetFriend <= n - 1
           Each arrivali time is distinct.
         */

        #endregion

        public static int SmallestChair(int[][] times, int targetFriend)
        {
            var friends = times
                .Select((x, i) => new Friend { Number = i, ArrivalTime = x[0], LeavingiTime = x[1] })
                .OrderBy(x => x.ArrivalTime)
                .ToArray();

            var freeChairs = new Stack<int>(Enumerable.Range(0, times.Length).Reverse());
            var occipiedChairs = new LinkedList<OccupiedChair>();

            foreach (var friend in friends)
            {
                var chair = PickChairFor(friend, occipiedChairs, freeChairs);
                if (friend.Number == targetFriend) return chair;
            }

            return default;
        }

        private static int PickChairFor(Friend friend, LinkedList<OccupiedChair> occupiedChairs, Stack<int> freeChairs)
        {
            OccupiedChair newOccupiedChair;

            if (null != occupiedChairs.First && occupiedChairs.First.Value.FreeTime <= friend.ArrivalTime)
            {
                var minNode = occupiedChairs.First;

                for (
                    var node = occupiedChairs.First.Next;
                    null != node && node.Value.FreeTime <= friend.ArrivalTime;
                    minNode = minNode.Value.Number > node.Value.Number ? node : minNode, node = node.Next
                );

                newOccupiedChair = new OccupiedChair { Number = minNode.Value.Number, FreeTime = friend.LeavingiTime };
                occupiedChairs.Remove(minNode);
            }
            else
            {
                newOccupiedChair = new OccupiedChair { Number = freeChairs.Pop(), FreeTime = friend.LeavingiTime };
            }

            InsertOccupiedChair(newOccupiedChair, occupiedChairs);
            return newOccupiedChair.Number;
        }

        private static void InsertOccupiedChair(OccupiedChair chair, LinkedList<OccupiedChair> occupiedChairs)
        {
            var newNode = new LinkedListNode<OccupiedChair>(chair);

            for (var node = occupiedChairs.First; node != null; node = node.Next)
            {
                if (chair.FreeTime < node.Value.FreeTime)
                {
                    occupiedChairs.AddBefore(node, newNode);
                    return;
                }
                else if (chair.FreeTime == node.Value.FreeTime && chair.Number < node.Value.Number)
                {
                    occupiedChairs.AddBefore(node, newNode);
                    return;
                }
                else if (chair.FreeTime == node.Value.FreeTime && chair.Number > node.Value.Number)
                {
                    occupiedChairs.AddAfter(node, newNode);
                    return;
                }

            }
                
            occupiedChairs.AddLast(newNode);
        }
        
        private readonly struct OccupiedChair
        {
            public int Number { get; init; }

            public int FreeTime { get; init; }
        }
    }

    public readonly struct Friend
    {
        public int ArrivalTime { get; init; }

        public int LeavingiTime { get; init; }

        public int Number { get; init; }
    }
}
