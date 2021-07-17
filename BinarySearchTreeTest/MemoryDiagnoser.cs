using System;
using BenchmarkDotNet.Attributes;
using BinarySearchTree;

namespace BinarySearchTreeTest
{
    [MemoryDiagnoser]
    public class BinarySearchTreeBenchmark
    {
        private readonly IBinarySearchTree<int> _bst;

        public BinarySearchTreeBenchmark()
        {
            _bst = new BinerySearchTree<int>();
        }
        
        [Benchmark]
        public void InsertRandomDo()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                _bst.Insert(new Node<int>() {Key = rand.Next(100)});
            }
        }
        
        [Benchmark]
        public void InsertSortedDo()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                _bst.Insert(new Node<int>() {Key = i});
            }
        }
        
                
        [Benchmark]
        public void DeleteDo()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                _bst.TreeDelete(i);
            }
        }
        
        [Benchmark]
        public void SearchDo()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                _bst.TreeSearch(_bst.Root, i);
            }
        }
    }
}