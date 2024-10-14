using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace AlgorithmsTraining.Tests
{
    public class BaseTest
    {
        public static string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static void DebugArray<T>(T[] arr)
        {
            var sb = new StringBuilder();

            foreach (var t in arr)
            {
                sb.Append($"{t}\t");
            }

            Debug.WriteLine(sb.ToString());
            sb.Clear();
        }

        public static void DebugArray(string s, int[,] arr)
        {
            Debug.WriteLine(s);
            Debug.WriteLine("");

            var sb = new StringBuilder();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sb.Append($"{arr[i, j]}\t");
                }

                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

        public static void DebugArray<T>(T[,] arr)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sb.Append($"{arr[i, j]}\t");
                }

                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }
        }
    }
}
