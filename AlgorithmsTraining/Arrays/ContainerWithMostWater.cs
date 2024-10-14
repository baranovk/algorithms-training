using System;

namespace AlgorithmsTraining.Arrays
{
    /*
     Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines 
     are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms 
     a container, such that the container contains the most water.

    Note: You may not slant the container and n is at least 2.
     */
    public static class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            var max_height_left = 0;
            var next_height_right_index = height.Length - 1;
            var max_s = 0;

            // var heights = new [] {3, 1, 3};
            // i = 1
            // j = 2
            // max_height_left = 3
            // cur_height_left = 3
            // cur_max_height_right = 3
            // next_height_right_index = 2
            // max_s = 6
            for (var i = 0; i < height.Length - 1 && i < next_height_right_index; i++)
            {
                var cur_height_left = height[i];
                if (cur_height_left <= max_height_left) continue;
                max_height_left = cur_height_left;

                var cur_max_height_right = 0;

                for (var j = next_height_right_index; j > i; j--)
                {
                    if (height[j] > cur_max_height_right)
                    {
                        var s = (j - i) * Math.Min(cur_height_left, height[j]);
                        max_s = Math.Max(s, max_s);

                        cur_max_height_right = height[j];

                        if (j < next_height_right_index && height[j] <= max_height_left)
                        {
                            next_height_right_index = j;
                        }

                        if (cur_max_height_right >= cur_height_left) break;
                    }
                }
            }

            return max_s;
        }
    }
}
