using NUnit.Framework;
using Otus.BST.AVL.Trees.Logic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Insert_To_Binary_Search_Tree()
        {
            var tree = new BinarySearchTree();
            tree.Inset(20);
            tree.Inset(10);
            tree.Inset(3);
            tree.Inset(40);
            tree.Inset(99);
            tree.Inset(34);
            tree.Inset(32);
            tree.Inset(19);
            tree.Inset(15);

            Assert.That(tree.Root.Value, Is.EqualTo(20));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(10));
            Assert.That(tree.Root.RightChild.Value, Is.EqualTo(40));
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(3));
            Assert.That(tree.Root.RightChild.LeftChild.Value, Is.EqualTo(34));
            Assert.That(tree.Root.RightChild.RightChild.Value, Is.EqualTo(99));
            Assert.That(tree.Root.RightChild.LeftChild.LeftChild.Value, Is.EqualTo(32));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(19));
            Assert.That(tree.Root.LeftChild.RightChild.LeftChild.Value, Is.EqualTo(15));
        }
    }
}