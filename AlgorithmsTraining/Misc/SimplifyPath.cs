﻿using System.Runtime.CompilerServices;
using System.Text;

namespace AlgorithmsTraining.Misc;

/*
 * 71. Simplify Path
 * 
   You are given an absolute path for a Unix-style file system, which always begins with a slash '/'. 
   Your task is to transform this absolute path into its simplified canonical path.
   
   The rules of a Unix-style file system are as follows:
   
       A single period '.' represents the current directory.
       A double period '..' represents the previous/parent directory.
       Multiple consecutive slashes such as '//' and '///' are treated as a single slash '/'.
       Any sequence of periods that does not match the rules above should be treated as a valid directory or file name. For example, '...' 
       and '....' are valid directory or file names.
   
   The simplified canonical path should follow these rules:
   
       The path must start with a single slash '/'.
       Directories within the path must be separated by exactly one slash '/'.
       The path must not end with a slash '/', unless it is the root directory.
       The path must not have any single or double periods ('.' and '..') used to denote current or parent directories.
   
   Return the simplified canonical path.
 

   Example 1:
   
       Input: path = "/home/"
       Output: "/home"
   
       Explanation:
   
       The trailing slash should be removed.
   
   Example 2:
   
       Input: path = "/home//foo/"
       Output: "/home/foo"
   
       Explanation:
   
       Multiple consecutive slashes are replaced by a single one.
   
   Example 3:
   
       Input: path = "/home/user/Documents/../Pictures"
       Output: "/home/user/Pictures"
   
       Explanation:
   
       A double period ".." refers to the directory up a level (the parent directory).
   
   Example 4:
   
       Input: path = "/../"
       Output: "/"
   
       Explanation:
   
       Going one level up from the root directory is not possible.
   
   Example 5:
   
       Input: path = "/.../a/../b/c/../d/./"
       Output: "/.../b/d"
   
       Explanation:
   
       "..." is a valid name for a directory in this problem.
   
   Constraints:
   
      - 1 <= path.length <= 3000
      - path consists of English letters, digits, period '.', slash '/' or '_'.
      - path is a valid absolute Unix path.
   
   
 */
public static class SimplifyPath
{
    public static string Solution(string path)
    {
        var pathParts = new Stack<ReadOnlyMemory<char>>();
        var spath = path.AsMemory();

        for (int i = 0, folderBase = 0, folderLength = 0; i < spath.Length; i++)
        {
            switch (path[i])
            {
                case '/':
                    if (folderLength > 0) { pathParts.Push(spath.Slice(folderBase, folderLength)); }
                    ProcessSlashes(spath[i..], ref i);
                    folderBase = i;
                    folderLength = 0;
                    break;
                case '.':
                    ProcessPeriods(spath[i..], pathParts, ref i);
                    break;
                default:
                    folderLength++;
                    break;
            }
        }

        var resultStack = new Stack<ReadOnlyMemory<char>>();
        while (pathParts.Count > 0) { resultStack.Push(pathParts.Pop()); }

        return 0 == pathParts.Count ? "/" : resultStack.Aggregate(new StringBuilder(), (sb, part) => sb.Append($"/{part}")).ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ProcessSlashes(ReadOnlyMemory<char> path, ref int @base)
    {
        var slice = path[@base..];
        var span = slice.Span;
        var nextCharIndex = -1;

        while (++nextCharIndex < slice.Length && '/' == span[nextCharIndex]) ;
        @base += nextCharIndex;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ProcessPeriods(ReadOnlyMemory<char> path, Stack<ReadOnlyMemory<char>> pathParts, ref int @base)
    {
        var slice = path[@base..];
        var span = slice.Span;
        var nextCharIndex = -1;
        var periodCount = 0;

        while (++nextCharIndex < slice.Length && '.' == span[nextCharIndex]) { periodCount++; }

        switch (periodCount)
        {
            case 1:
                // nothing to do, current directory
                break;
            case 2:
                pathParts.TryPop(out _);
                break;
            default:
                pathParts.Push(slice[..periodCount]);
                break;
        }

        @base += nextCharIndex;
    }
}
