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

            AddNode(Root,value);
        }

        public Node Search(int value)
        {
            return GetNode(Root, value);
        }

        public void Remove(int value)
        {
            var nodeToRemove = Search(value);

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
                    var minNodeInSubtree = GetMinNodeInSubtree(nodeToRemove.RightChild);
                    ReplaceNodeInParent(minNodeInSubtree, null);

                    minNodeInSubtree.Parent = nodeToRemove.Parent;
                    minNodeInSubtree.LeftChild = nodeToRemove.LeftChild;
                    minNodeInSubtree.RightChild = nodeToRemove.RightChild;

                    ReplaceNodeInParent(nodeToRemove, minNodeInSubtree);
                    break;
            }
        }


        #region Support methods

        private void AddNode(Node currentRoot, int value)
        {
            if (value < currentRoot.Value)
            {
                if (currentRoot.LeftChild == null)
                {
                    currentRoot.LeftChild = new Node(value, currentRoot);
                    return;
                }

                AddNode(currentRoot.LeftChild, value);
            }
            else
            {
                if (currentRoot.RightChild == null)
                {
                    currentRoot.RightChild = new Node(value, currentRoot);
                    
                    return;
                }

                AddNode(currentRoot.RightChild, value);
            }
        }

        private Node GetNode(Node currentNode, int value)
        {
            if (currentNode == null)
                return null;

            if (value == currentNode.Value)
                return currentNode;

            var nextNode = value < currentNode.Value 
                ? currentNode.LeftChild 
                : currentNode.RightChild;

            return GetNode(nextNode, value);
        }

        private static void ReplaceNodeInParent(Node nodeToRemove, Node node)
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
