namespace Otus.BST.AVL.Trees.Logic
{
    public class AVLTree
    {
        public AVLNode Root { get; private set; }


        public void Inset(int value)
        {
            InsetWithoutBalancing(value);

            ReBalance(Root);
        }

        //for tests purposes
        public void InsetWithoutBalancing(int value)
        {
            if (Root == null)
            {
                Root = new AVLNode(value, null);
                return;
            }

            AddAVLNode(Root,value);
        }

        public AVLNode Search(int value)
        {
            return GetAVLNode(Root, value);
        }

        public void Remove(int value)
        {
            var AVLNodeToRemove = Search(value);
            if (AVLNodeToRemove == null)
                return;

            switch (AVLNodeToRemove.NodeType)
            {
                case NodeType.WithoutChildren:
                    ReplaceAVLNodeInParent(AVLNodeToRemove, null);
                    break;

                case NodeType.WithSingleChild:
                    var child = AVLNodeToRemove.GetSingleChildren;
                    ReplaceAVLNodeInParent(AVLNodeToRemove, child);
                    break;

                case NodeType.WithTwoChildren:
                    var minAVLNodeInSubtree = GetMinAVLNodeInSubtree(AVLNodeToRemove.RightChild);
                    ReplaceAVLNodeInParent(minAVLNodeInSubtree, null);

                    minAVLNodeInSubtree.Parent = AVLNodeToRemove.Parent;
                    minAVLNodeInSubtree.LeftChild = AVLNodeToRemove.LeftChild;
                    minAVLNodeInSubtree.RightChild = AVLNodeToRemove.RightChild;

                    ReplaceAVLNodeInParent(AVLNodeToRemove, minAVLNodeInSubtree);
                    break;
            }

            ReBalance(Root);
        }

        public void ReBalance(AVLNode node)
        {
            if (node.RightHeight - node.LeftHeight == 2)
            {
                var rightChild = node.RightChild;
                var balanceDifference = rightChild?.RightHeight - rightChild?.LeftHeight;

                if (balanceDifference < 0)
                {
                    DoBigRightRotation(node);
                }

                else
                {
                    DoSmallRightRotation(node.RightChild);
                }
            }
            else if (node.LeftHeight - node.RightHeight == 2)
            {
                var leftChild = node.LeftChild;
                var balanceDifference = leftChild?.RightHeight - leftChild?.LeftHeight;

                if (balanceDifference > 0)
                {
                    DoBigLeftRotation(node);
                }
                else
                {
                    DoSmallLeftRotation(node.LeftChild);
                }
            }
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
                ReplaceAVLNodeInParent(parent, rootToRotate);
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
                ReplaceAVLNodeInParent(parent, rootToRotate);
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

        private void AddAVLNode(AVLNode currentRoot, int value)
        {
            if (value < currentRoot.Value)
            {
                if (currentRoot.LeftChild == null)
                {
                    currentRoot.LeftChild = new AVLNode(value, currentRoot);
                    return;
                }

                AddAVLNode(currentRoot.LeftChild, value);
            }
            else
            {
                if (currentRoot.RightChild == null)
                {
                    currentRoot.RightChild = new AVLNode(value, currentRoot);
                    
                    return;
                }

                AddAVLNode(currentRoot.RightChild, value);
            }
        }

        private AVLNode GetAVLNode(AVLNode currentAVLNode, int value)
        {
            if (currentAVLNode == null)
                return null;

            if (value == currentAVLNode.Value)
                return currentAVLNode;

            var nextAVLNode = value < currentAVLNode.Value 
                ? currentAVLNode.LeftChild 
                : currentAVLNode.RightChild;

            return GetAVLNode(nextAVLNode, value);
        }

        private static void ReplaceAVLNodeInParent(AVLNode nodeToRemove, AVLNode newNode)
        {
            var parent = nodeToRemove.Parent;
            if (parent == null)
                return;

            if (parent.LeftChild == nodeToRemove)
            {
                parent.LeftChild = newNode;
            }
            else if (parent.RightChild == nodeToRemove)
            {
                parent.RightChild = newNode;
            }
        }

        private AVLNode GetMinAVLNodeInSubtree(AVLNode subtreeRoot)
        {
            var miAVLNode = subtreeRoot;

            while (subtreeRoot.LeftChild != null)
            {
                miAVLNode = subtreeRoot.LeftChild;
                subtreeRoot = miAVLNode;
            }

            return miAVLNode;
        }

        #endregion

    }
}
