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

        [Test]
        public void Can_Search_In_Binary_Search_Tree()
        {
            var tree = CreateTree();

            var firstElement = tree.Search(20);
            var secondElement = tree.Search(15);
            var thirdElement = tree.Search(34);
            var fifthElement = tree.Search(32);
            var sixthElement = tree.Search(100500);

            Assert.That(firstElement.Value, Is.EqualTo(20));
            Assert.That(secondElement.Value, Is.EqualTo(15));
            Assert.That(thirdElement.Value, Is.EqualTo(34));
            Assert.That(fifthElement.Value, Is.EqualTo(32));
            Assert.That(sixthElement?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_List_In_Binary_Search_Tree()
        {
            var tree = CreateTree();

            tree.Remove(15);

            //to better tests should get value by hands
            var removedValue = tree.Search(15);

            Assert.That(removedValue?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_Node_With_One_Child_From_Right_In_Binary_Search_Tree()
        {
            var tree = CreateTree();

            tree.Remove(19);

            //to better tests should get value by hands
            var removedValue = tree.Search(19);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(15));
        }

        [Test]
        public void Can_Remove_Node_With_Two_Children_In_Binary_Search_Tree()
        {
            var tree = CreateTree();

            tree.Remove(10);

            //to better tests should get value by hands
            var removedValue = tree.Search(10);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(15));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(19));
            Assert.That(tree.Root.LeftChild.RightChild.LeftChild?.Value, Is.Null);
        }

        [Test]
        public void Can_Remove_Node_With_One_Child_From_Left_In_Binary_Search_Tree()
        {
            var tree = CreateTree();

            tree.Remove(3);

            //to better tests should get value by hands
            var removedValue = tree.Search(3);

            Assert.That(removedValue?.Value, Is.Null);
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(5));
        }


        #region Support methods

        private BinarySearchTree CreateTree()
        {
            //to better tests should feel tree by hands

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
            tree.Inset(5);

            return tree;
        }
        

        #endregion
    }
}