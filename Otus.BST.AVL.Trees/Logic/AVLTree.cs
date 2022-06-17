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
            var nodeToRemove = Search(value);
            if (nodeToRemove == null)
                return;

            switch (nodeToRemove.NodeType)
            {
                case NodeType.WithoutChildren:
                    ReplaceNodeInParent(nodeToRemove, null);
                    break;

                case NodeType.WithSingleChild:
                    var child = nodeToRemove.GetSingleChildren;
                    ReplaceNodeInParent(nodeToRemove, child);
                    break;

                case NodeType.WithTwoChildren:
                    var minNodeInSubtree = GetMinAVLNodeInSubtree(nodeToRemove.RightChild);
                    ReplaceNodeInParent(minNodeInSubtree, null);

                    minNodeInSubtree.Parent = nodeToRemove.Parent;
                    minNodeInSubtree.LeftChild = nodeToRemove.LeftChild;
                    minNodeInSubtree.RightChild = nodeToRemove.RightChild;

                    ReplaceNodeInParent(nodeToRemove, minNodeInSubtree);
                    break;
            }

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

        private AVLNode GetAVLNode(AVLNode currentNode, int value)
        {
            if (currentNode == null)
                return null;

            if (value == currentNode.Value)
                return currentNode;

            var nextNode = value < currentNode.Value 
                ? currentNode.LeftChild 
                : currentNode.RightChild;

            return GetAVLNode(nextNode, value);
        }

        private static void ReplaceNodeInParent(AVLNode nodeToRemove, AVLNode newNode)
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
            var miNode = subtreeRoot;

            while (subtreeRoot.LeftChild != null)
            {
                miNode = subtreeRoot.LeftChild;
                subtreeRoot = miNode;
            }

            return miNode;
        }

        #endregion
    }
}
