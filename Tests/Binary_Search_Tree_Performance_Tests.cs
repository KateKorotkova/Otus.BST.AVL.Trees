using System;
using NUnit.Framework;
using Otus.BST.AVL.Trees.Logic.Binary;

namespace Tests
{
    public class Binary_Search_Tree_Performance_Tests
    {
        private readonly Random _random = new Random();


        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Searching_Tests_For_Random_Tree(int treeSize)
        {
            var tree = CreateRandomTree(treeSize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < treeSize / 10; i++)
            {
                var res = tree.Get(_random.Next());
            }
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void Searching_Tests_For_Ordered_Tree(int treeSize)
        {
            var tree = CreateOrderedTree(treeSize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < treeSize / 10; i++)
            {
                var res = tree.Get(_random.Next());
            }
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }


        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Removing_Tests_For_Random_Tree(int treeSize)
        {
            var tree = CreateRandomTree(treeSize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < treeSize / 10; i++)
            {
                tree.Remove(_random.Next());
            }
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void Removing_Tests_For_Ordered_Tree(int treeSize)
        {
            var tree = CreateOrderedTree(treeSize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < treeSize / 10; i++)
            {
                tree.Remove(_random.Next());
            }
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }



        #region Support methods

        private BinarySearchTree CreateRandomTree(int count)
        {
            var tree = new BinarySearchTree();

            for(var i = 0; i < count; i++)
            {
                tree.Insert(_random.Next());
            }

            return tree;
        }

        private BinarySearchTree CreateOrderedTree(int count)
        {
            var tree = new BinarySearchTree();

            var elements = new int [count];

            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = _random.Next();
            }

            Array.Sort(elements);

            for (var i = 0; i < elements.Length; i++)
            {
                tree.Insert(elements[i]);
            }

            return tree;
        }

        #endregion
    }
}