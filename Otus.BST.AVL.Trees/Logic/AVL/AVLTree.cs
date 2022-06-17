using Otus.BST.AVL.Trees.Logic.Base;

namespace Otus.BST.AVL.Trees.Logic.AVL
{
    public class AVLTree : BaseTree <AVLNode>
    {
        public override void Insert(int value)
        {
            InsetWithoutBalancing(value);

            ReBalance(Root);
        }

        //for tests purposes
        public void InsetWithoutBalancing(int value)
        {
          base.Insert(value);
        }

        public override void Remove(int value)
        { 
            base.Remove(value);

            ReBalance(Root);
        }

        public void DoSmallRightRotation(AVLNode rootToRotate)
        {
            var parent = rootToRotate.Parent;
            var grandFather = parent?.Parent;
            if (grandFather == null)
            {
                rootToRotate.Parent = null;
                Root = rootToRotate;
            }
            else
            {
                ReplaceNodeInParent(parent, rootToRotate);
                rootToRotate.Parent = grandFather;
                parent.Parent = rootToRotate;
            }

            var exLeftChild = rootToRotate.LeftChild;

            rootToRotate.LeftChild = parent;

            if (parent != null)
            {
                parent.RightChild = exLeftChild;
            }
        }

        public void DoSmallLeftRotation(AVLNode rootToRotate)
        {
            var parent = rootToRotate.Parent;
            var grandFather = parent?.Parent;
            if (grandFather == null)
            {
                rootToRotate.Parent = null;
                Root = rootToRotate;
            }
            else
            {
                ReplaceNodeInParent(parent, rootToRotate);
                rootToRotate.Parent = grandFather;
                parent.Parent = rootToRotate;
            }

            var exRightChild = rootToRotate.RightChild;

            rootToRotate.RightChild = parent;

            if (parent != null)
            {
                parent.LeftChild = exRightChild;
                parent.Parent = rootToRotate;
            }
        }

        public void DoBigRightRotation(AVLNode rootToRotate)
        {
            DoSmallRightRotation(rootToRotate);
            DoSmallLeftRotation(rootToRotate);
        }

        public void DoBigLeftRotation(AVLNode rootToRotate)
        {
            DoSmallLeftRotation(rootToRotate);
            DoSmallRightRotation(rootToRotate);
        }


        #region Support methods
        
        private void ReBalance(AVLNode node)
        {
            if (node.RightHeight - node.LeftHeight == 2)
            {
                var rightChild = node.RightChild as AVLNode;
                var balanceDifference = rightChild?.RightHeight - rightChild?.LeftHeight;

                if (balanceDifference < 0)
                {
                    DoBigRightRotation(node);
                }

                else
                {
                    DoSmallRightRotation(rightChild);
                }
            }
            else if (node.LeftHeight - node.RightHeight == 2)
            {
                var leftChild = node.LeftChild as AVLNode;
                var balanceDifference = leftChild?.RightHeight - leftChild?.LeftHeight;

                if (balanceDifference > 0)
                {
                    DoBigLeftRotation(node);
                }
                else
                {
                    DoSmallLeftRotation(leftChild);
                }
            }
        }

        #endregion
    }
}
