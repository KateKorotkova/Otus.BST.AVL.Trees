namespace Otus.BST.AVL.Trees.Logic
{
    public class BinarySearchTree
    {
        public Node Root { get; private set; }


        public void Inset(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            FillNode(Root,value);
        }


        #region Support methods

        private void FillNode(Node currentNode, int value)
        {
            if (value < currentNode.Value)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new Node(value);
                    return;
                }

                FillNode(currentNode.LeftChild, value);
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new Node(value);
                    
                    return;
                }

                FillNode(currentNode.RightChild, value);
            }
        }

        #endregion

    }
}
