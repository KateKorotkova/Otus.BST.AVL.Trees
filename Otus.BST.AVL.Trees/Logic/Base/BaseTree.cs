namespace Otus.BST.AVL.Trees.Logic.Base
{
    public abstract class BaseTree<T> where T : BaseNode, new()
    {
        public T Root { get; protected set; }


        public virtual void Insert(int value)
        {
            if (Root == null)
            {
                Root = new T {Value = value};
                return;
            }

            AddNode(Root, value);
        }

        public T Get(int value)
        {
            return GetNode(Root, value);
        }

        public virtual void Remove(int value)
        {
            var nodeToRemove = Get(value);
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
                    var minNodeInSubtree = GetMinNodeInSubtree(nodeToRemove.RightChild);
                    ReplaceNodeInParent(minNodeInSubtree, null);

                    minNodeInSubtree.Parent = nodeToRemove.Parent;
                    minNodeInSubtree.LeftChild = nodeToRemove.LeftChild;
                    minNodeInSubtree.RightChild = nodeToRemove.RightChild;

                    ReplaceNodeInParent(nodeToRemove, minNodeInSubtree);
                    break;
            }
        }


        #region Support Methods

        protected void ReplaceNodeInParent(BaseNode nodeToRemove, BaseNode node)
        {
            var parent = nodeToRemove.Parent;
            if (parent == null)
                return;

            if (parent.LeftChild == nodeToRemove)
            {
                parent.LeftChild = node;
            }
            else if (parent.RightChild == nodeToRemove)
            {
                parent.RightChild = node;
            }
        }

        protected BaseNode GetMinNodeInSubtree(BaseNode subtreeRoot)
        {
            var miNode = subtreeRoot;

            while (subtreeRoot.LeftChild != null)
            {
                miNode = (T) subtreeRoot.LeftChild;
                subtreeRoot = miNode;
            }

            return miNode;
        }

        protected T GetNode(T currentNode, int value)
        {
            if (currentNode == null)
                return null;

            if (value == currentNode.Value)
                return currentNode;

            var nextNode = value < currentNode.Value
                ? currentNode.LeftChild
                : currentNode.RightChild;

            return GetNode((T) nextNode, value);
        }

        protected void AddNode(BaseNode currentRoot, int value)
        {
            if (value < currentRoot.Value)
            {
                if (currentRoot.LeftChild == null)
                {
                    currentRoot.LeftChild = new T
                    {
                        Value = value,
                        Parent =  currentRoot
                    };
                    return;
                }

                AddNode(currentRoot.LeftChild, value);
            }
            else
            {
                if (currentRoot.RightChild == null)
                {
                    currentRoot.RightChild = new T
                    {
                        Value = value,
                        Parent = currentRoot
                    };
                    return;
                }

                AddNode(currentRoot.RightChild, value);
            }
        }

        #endregion
    }
}
