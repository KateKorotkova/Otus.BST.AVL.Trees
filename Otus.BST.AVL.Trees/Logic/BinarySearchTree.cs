namespace Otus.BST.AVL.Trees.Logic
{
    public class BinarySearchTree
    {
        public Node Root { get; private set; }


        public void Inset(int value)
        {
            if (Root == null)
            {
                Root = new Node(value, null);
                return;
            }

            FillNode(Root,value);
        }

        public Node Search(int value)
        {
            return GetNode(Root, value);
        }

        public void Remove(int value)
        {
            var nodeToRemove = Search(value);
            
            if (nodeToRemove.WithoutChildren)
            {
                UpdateParentPointers(nodeToRemove, null);
            }
            else if (nodeToRemove.WithSingleChildren)
            {
                var child = nodeToRemove.GetSingleChildren;
                UpdateParentPointers(nodeToRemove, child);
            }
            else
            {
                var minNodeInSubtree = GetMinNodeInSubtree(nodeToRemove.RightChild);
                UpdateParentPointers(minNodeInSubtree, null);

                minNodeInSubtree.Parent = nodeToRemove.Parent;
                minNodeInSubtree.LeftChild = nodeToRemove.LeftChild;
                minNodeInSubtree.RightChild = nodeToRemove.RightChild;
                
                UpdateParentPointers(nodeToRemove, minNodeInSubtree);
            }
        }


        #region Support methods

        private void FillNode(Node currentNode, int value)
        {
            if (value < currentNode.Value)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new Node(value, currentNode);
                    return;
                }

                FillNode(currentNode.LeftChild, value);
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new Node(value, currentNode);
                    
                    return;
                }

                FillNode(currentNode.RightChild, value);
            }
        }

        private Node GetNode(Node currentNode, int value)
        {
            if (currentNode == null)
                return null;

            if (value == currentNode.Value)
                return currentNode;

            if (value < currentNode.Value)
            {
                return GetNode(currentNode.LeftChild, value);
            }
            else
            {
                return GetNode(currentNode.RightChild, value);
            }
        }

        private static void UpdateParentPointers(Node nodeToRemove, Node node)
        {
            var parent = nodeToRemove.Parent;
            
            if (parent.LeftChild == nodeToRemove)
            {
                parent.LeftChild = node;
            }
            else if (parent.RightChild == nodeToRemove)
            {
                parent.RightChild = node;
            }
        }

        private Node GetMinNodeInSubtree(Node subtreeRoot)
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
