using NUnit.Framework;
using Otus.BST.AVL.Trees.Logic.Binary;

namespace Tests
{
    public class Binary_Search_Tree_Tests
    {
        [Test]
        public void Can_Insert()
        {
            var tree = new BinarySearchTree();
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(3);
            tree.Insert(40);
            tree.Insert(99);
            tree.Insert(34);
            tree.Insert(32);
            tree.Insert(19);
            tree.Insert(15);

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

        [Test]
        public void Can_Search()
        {
            var tree = CreateTree();

            var firstElement = tree.Get(20);
            var secondElement = tree.Get(15);
            var thirdElement = tree.Get(34);
            var fifthElement = tree.Get(32);
            var sixthElement = tree.Get(100500);

            Assert.That(firstElement.Value, Is.EqualTo(20));
            Assert.That(secondElement.Value, Is.EqualTo(15));
            Assert.That(thirdElement.Value, Is.EqualTo(34));
            Assert.That(fifthElement.Value, Is.EqualTo(32));
            Assert.That(sixthElement?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_List()
        {
            var tree = CreateTree();

            tree.Remove(15);

            //to better tests should get value by hands
            var removedValue = tree.Get(15);

            Assert.That(removedValue?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_Node_With_One_Child_From_Right()
        {
            var tree = CreateTree();

            tree.Remove(19);

            //to better tests should get value by hands
            var removedValue = tree.Get(19);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(15));
        }

        [Test]
        public void Can_Remove_Node_With_Two_Children()
        {
            var tree = CreateTree();

            tree.Remove(10);

            //to better tests should get value by hands
            var removedValue = tree.Get(10);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(15));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(19));
            Assert.That(tree.Root.LeftChild.RightChild.LeftChild?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_Node_With_One_Child_From_Left()
        {
            var tree = CreateTree();

            tree.Remove(3);

            //to better tests should get value by hands
            var removedValue = tree.Get(3);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(5));
        }


        #region Support methods

        private BinarySearchTree CreateTree()
        {
            //to better tests should feel tree by hands

            var tree = new BinarySearchTree();

            var elements = new[] {20, 10, 3, 40, 99, 34, 32, 19, 15, 5};
            
            foreach (var element in elements)
            {
                tree.Insert(element);
            }

            return tree;
        }

        #endregion
    }
}