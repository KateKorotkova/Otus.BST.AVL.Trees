using NUnit.Framework;
using Otus.BST.AVL.Trees.Logic;

namespace Tests
{
    public class AVLTreeTests
    {
        [Test]
        public void Can_Do_Small_Left_Rotation_From_Root()
        {
            var tree = new AVLTree();
            tree.Inset(80);
            tree.Inset(100);
            tree.Inset(50);
            tree.Inset(40);
            tree.Inset(60);

            var rootToRotate = tree.Search(50);
            tree.DoSmallLeftRotation(rootToRotate);

            Assert.That(tree.Root.Value, Is.EqualTo(50));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(40));
            Assert.That(tree.Root.RightChild.Value, Is.EqualTo(80));
            Assert.That(tree.Root.RightChild.RightChild.Value, Is.EqualTo(100));
            Assert.That(tree.Root.RightChild.LeftChild.Value, Is.EqualTo(60));
        }

        [Test]
        public void Can_Do_Small_Left_Rotation_Not_From_Root()
        {
            var tree = new AVLTree();
            tree.Inset(200);
            tree.Inset(80);
            tree.Inset(100);
            tree.Inset(50);
            tree.Inset(40);
            tree.Inset(60);

            var rootToRotate = tree.Search(50);
            tree.DoSmallLeftRotation(rootToRotate);

            Assert.That(tree.Root.Value, Is.EqualTo(200));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(50));
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(40));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(80));
            Assert.That(tree.Root.LeftChild.RightChild.RightChild.Value, Is.EqualTo(100));
            Assert.That(tree.Root.LeftChild.RightChild.LeftChild.Value, Is.EqualTo(60));
        }

        [Test]
        public void Can_Do_Small_Right_Rotation_From_Root()
        {
            var tree = new AVLTree();
            tree.Inset(80);
            tree.Inset(70);
            tree.Inset(100);
            tree.Inset(90);
            tree.Inset(110);

            var rootToRotate = tree.Search(100);
            tree.DoSmallRightRotation(rootToRotate);

            Assert.That(tree.Root.Value, Is.EqualTo(100));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(80));
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(70));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(90));
            Assert.That(tree.Root.RightChild.Value, Is.EqualTo(110));
        }

        [Test]
        public void Can_Do_Small_Right_Rotation_Not_From_Root()
        {
            var tree = new AVLTree();
            tree.Inset(200);
            tree.Inset(80);
            tree.Inset(70);
            tree.Inset(100);
            tree.Inset(90);
            tree.Inset(110);

            var rootToRotate = tree.Search(100);
            tree.DoSmallRightRotation(rootToRotate);

            Assert.That(tree.Root.Value, Is.EqualTo(200));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(100));
            Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(80));
            Assert.That(tree.Root.LeftChild.LeftChild.LeftChild.Value, Is.EqualTo(70));
            Assert.That(tree.Root.LeftChild.LeftChild.RightChild.Value, Is.EqualTo(90));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(110));
        }

        //[Test]
        //public void Can_Insert_To_Binary_Search_Tree()
        //{
        //    var tree = new BinarySearchTree();
        //    tree.Inset(20);
        //    tree.Inset(10);
        //    tree.Inset(3);
        //    tree.Inset(40);
        //    tree.Inset(99);
        //    tree.Inset(34);
        //    tree.Inset(32);
        //    tree.Inset(19);
        //    tree.Inset(15);

        //    Assert.That(tree.Root.Value, Is.EqualTo(20));
        //    Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(10));
        //    Assert.That(tree.Root.RightChild.Value, Is.EqualTo(40));
        //    Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(3));
        //    Assert.That(tree.Root.RightChild.LeftChild.Value, Is.EqualTo(34));
        //    Assert.That(tree.Root.RightChild.RightChild.Value, Is.EqualTo(99));
        //    Assert.That(tree.Root.RightChild.LeftChild.LeftChild.Value, Is.EqualTo(32));
        //    Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(19));
        //    Assert.That(tree.Root.LeftChild.RightChild.LeftChild.Value, Is.EqualTo(15));
        //}

        //[Test]
        //public void Can_Search_In_Binary_Search_Tree()
        //{
        //    var tree = CreateTree();

        //    var firstElement = tree.Search(20);
        //    var secondElement = tree.Search(15);
        //    var thirdElement = tree.Search(34);
        //    var fifthElement = tree.Search(32);
        //    var sixthElement = tree.Search(100500);

        //    Assert.That(firstElement.Value, Is.EqualTo(20));
        //    Assert.That(secondElement.Value, Is.EqualTo(15));
        //    Assert.That(thirdElement.Value, Is.EqualTo(34));
        //    Assert.That(fifthElement.Value, Is.EqualTo(32));
        //    Assert.That(sixthElement?.Value, Is.Null);
        //}

        //[Test]
        //public void Can_Remove_List_In_Binary_Search_Tree()
        //{
        //    var tree = CreateTree();

        //    tree.Remove(15);

        //    //to better tests should get value by hands
        //    var removedValue = tree.Search(15);

        //    Assert.That(removedValue?.Value, Is.Null);
        //}

        //[Test]
        //public void Can_Remove_Node_With_One_Child_From_Right_In_Binary_Search_Tree()
        //{
        //    var tree = CreateTree();

        //    tree.Remove(19);

        //    //to better tests should get value by hands
        //    var removedValue = tree.Search(19);

        //    Assert.That(removedValue?.Value, Is.Null);
        //    Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(15));
        //}

        //[Test]
        //public void Can_Remove_Node_With_Two_Children_In_Binary_Search_Tree()
        //{
        //    var tree = CreateTree();

        //    tree.Remove(10);

        //    //to better tests should get value by hands
        //    var removedValue = tree.Search(10);

        //    Assert.That(removedValue?.Value, Is.Null);
        //    Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(15));
        //    Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(19));
        //    Assert.That(tree.Root.LeftChild.RightChild.LeftChild?.Value, Is.Null);
        //}

        //[Test]
        //public void Can_Remove_Node_With_One_Child_From_Left_In_Binary_Search_Tree()
        //{
        //    var tree = CreateTree();

        //    tree.Remove(3);

        //    //to better tests should get value by hands
        //    var removedValue = tree.Search(3);

        //    Assert.That(removedValue?.Value, Is.Null);
        //    Assert.That(tree.Root.LeftChild.LeftChild.Value, Is.EqualTo(5));
        //}


        #region Support methods

        private BinarySearchTree CreateTree()
        {
            //to better tests should feel tree by hands

            var tree = new BinarySearchTree();

            var elements = new[] {20, 10, 3, 40, 99, 34, 32, 19, 15, 5};
            
            foreach (var element in elements)
            {
                tree.Inset(element);
            }

            return tree;
        }

        #endregion
    }
}