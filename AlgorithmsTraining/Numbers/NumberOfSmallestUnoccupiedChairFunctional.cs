﻿using BenchmarkDotNet.Attributes;
using AlgorithmsTraining.Functional;
using static AlgorithmsTraining.Functional.F;

namespace AlgorithmsTraining.Numbers
{
    /// <summary>
    /// Trying to implement algorithm in functional style - just for exercise
    /// Implementation is not pure functional: for example occupied chairs linked list is modified in TryPickOccupiedChair,
    /// but it is close to
    /// </summary>
    public class NumberOfSmallestUnoccupiedChairFunctional
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

        /*
         * Runtime: 368ms Beats 71.06%
         * Memory: 62.63 MB Beats 90.13%
         * 
         * Runtime: 364ms Beats 73.02%
         * Memory: 64.93 MB Beats 90.13%
         */

        #endregion

        private readonly struct State
        {
            public int NextFreeChair { get; init; }

            public LinkedList<OccupiedChair> OccupiedChairs { get; init; }

            public Option<int> TargetFriendChair { get; init; }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Times))]
        public int SmallestChair(int[][] times, int targetFriend)
            => times
                .Select((x, i) => new Friend { Number = i, ArrivalTime = x[0], LeavingiTime = x[1] })
                .OrderBy(x => x.ArrivalTime)
                .Aggregate(
                    new State { NextFreeChair = 0, OccupiedChairs = new LinkedList<OccupiedChair>(), TargetFriendChair = None },
                    (state, friend) =>
                    {
                        var chair = TryPickOccupiedChair(friend, state.OccupiedChairs)
                                    .Match(() => OccupyNextFreeChair(friend, state.OccupiedChairs, state.NextFreeChair), _ => _);

                        return new State
                        {
                            NextFreeChair = state.NextFreeChair == chair ? state.NextFreeChair + 1 : state.NextFreeChair,
                            OccupiedChairs = state.OccupiedChairs,
                            TargetFriendChair = friend.Number == targetFriend ? chair : None
                        };
                    },
                    state => None != state.TargetFriendChair)
                .TargetFriendChair
                .ValueUnsafe();

        public static IEnumerable<object[]> Times()
        {
            var times = new int[][] {
                new[] {33889, 98676}, new[] {80071, 89737}, new[] {44118, 52565}, new[] {52992, 84310},
                new[] {78492, 88209}, new[] {21695, 67063}, new[] {84622, 95452}, new[] {98048, 98856},
                new[] {98411, 99433}, new[] {55333, 56548}, new[] {65375, 88566}, new[] {55011, 62821},
                new[] {48548, 48656}, new[] {87396, 94825}, new[] {55273, 81868}, new[] { 75629, 91467 }
            };

            yield return new object[] { times, 6 };
        }

        private static Option<int> TryPickOccupiedChair(Friend friend, LinkedList<OccupiedChair> occupiedChairs)
        {
            if (null == occupiedChairs.First || occupiedChairs.First.Value.FreeTime > friend.ArrivalTime)
            {
                return None;
            }

            var minNode = occupiedChairs.First;

            for (
                var node = occupiedChairs.First.Next;
                null != node && node.Value.FreeTime <= friend.ArrivalTime;
                minNode = minNode.Value.Number > node.Value.Number ? node : minNode, node = node.Next
            ) ;

            var newOccupiedChair = new OccupiedChair { Number = minNode.Value.Number, FreeTime = friend.LeavingiTime };
            occupiedChairs.Remove(minNode);
            InsertOccupiedChair(newOccupiedChair, occupiedChairs);
            return newOccupiedChair.Number;
        }

        private static int OccupyNextFreeChair(Friend friend, LinkedList<OccupiedChair> occupiedChairs, int nextFreeChair)
        {
            var newOccupiedChair = new OccupiedChair { Number = nextFreeChair, FreeTime = friend.LeavingiTime };
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

        private readonly struct Friend
        {
            public int ArrivalTime { get; init; }

            public int LeavingiTime { get; init; }

            public int Number { get; init; }
        }
    }
}
