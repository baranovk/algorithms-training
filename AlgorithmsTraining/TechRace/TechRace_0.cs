using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsTraining.TechRace
{
    public class TechRace_0
    {
        public static List<int> Solution(int[] properties)
        {
            if (1 == properties.Length) return properties.ToList();

            Array.Sort(properties);

            var mostPoorIndex = 0;
            var mostRichIndex = properties.Length - 1;

            while (mostPoorIndex < mostRichIndex && 3 * properties[mostPoorIndex] <= properties[mostRichIndex])
            {
                properties[mostRichIndex] -= properties[mostPoorIndex];
                properties[mostPoorIndex] = int.MinValue;

                var i = mostRichIndex;

                while (properties[i - 1] > properties[i])
                {
                    var t = properties[i];
                    properties[i] = properties[i - 1];
                    properties[i - 1] = t;
                }

                mostPoorIndex++;
            }

            return properties.Skip(mostPoorIndex).ToList();
        }

        public static int Solution_1(List<int> passersby)
        {
            if (1 == passersby.Count) return 0;

            passersby = passersby.Where(_ => _ > 0).ToList();
            var robbed = new List<int>();
            passersby.Sort();

            var mostPoorIndex = 0;
            var mostRichIndex = passersby.Count - 1;

            while (mostPoorIndex < mostRichIndex && 2 * passersby[mostPoorIndex] <= passersby[mostRichIndex])
            {
                passersby[mostRichIndex] -= passersby[mostPoorIndex];
                robbed.Add(passersby[mostRichIndex]);

                mostRichIndex--;
                mostPoorIndex++;
            }

            return robbed.Sum();
        }
    }
}
