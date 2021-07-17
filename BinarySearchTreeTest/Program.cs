using System;
using BinarySearchTree;

namespace BinarySearchTreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<BinarySearchTreeBenchmark>();
        }
    }
}